using SDRSharp.Radio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SDRSharp.Plugin.SignalRecorder
{
    public class SignalRecorderProcessor : IIQProcessor, INotifyPropertyChanged
    {
        public SignalRecorderProcessor()
        {
            // initial values
            SelectedFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            RecordingTime = 10;
            SampleCount = 0;
            _line = new StringBuilder();
        }

        private int _recordingTime;
        private int _samplesToBeSaved;
        private bool _recordingEnabled;
        private bool _recording;
        private string _selectedFolder;
        private StringBuilder _line;

        public double SampleRate { get; set; }

        public double SampleCount { get; set; }

        public int ThresholdDb { get; set; }

        public int RecordingTime
        {
            get => _recordingTime;
            set
            {
                _recordingTime = value;
                ResetSamplesToBeSaved();
            }
        }

        // plugin enabled from the SDRSharp menu
        public bool Enabled { get; set; }

        public bool RecordingEnabled
        {
            get => _recordingEnabled;
            set
            {
                if (!value) _recording = false;
                // if enabled create a new file name
                else FileName = Path.Combine(SelectedFolder, "SigRec_" + DateTime.Now.ToString("yyyyMMddHHmmssff") + ".csv");

                _recordingEnabled = value;
                RaisePropertyChanged(nameof(RecordingEnabled));
                RaisePropertyChanged(nameof(RecordingDisabled));
                RaisePropertyChanged(nameof(RecordingStatus));
            }
        }

        public bool RecordingDisabled { get => !RecordingEnabled; }

        public bool Recording
        {
            get => _recording;
            set
            {
                _recording = value;
                RaisePropertyChanged(nameof(RecordingStatus));
                RaisePropertyChanged(nameof(NotRecording));
            }
        }

        public bool NotRecording { get => !Recording; }

        public bool AutoRecord { get; set; }

        public bool ISaveEnabled { get; set; }

        public bool QSaveEnabled { get; set; }

        public bool ModSaveEnabled { get; set; }

        public bool ArgSaveEnabled { get; set; }

        public string SelectedFolder
        {
            get => _selectedFolder;
            set
            {
                _selectedFolder = value;
                RaisePropertyChanged(nameof(SelectedFolder));
            }
        }

        public string FileName { get; set; }

        public string RecordingStatus
        {
            get
            {
                if(RecordingEnabled)
                {
                    if (Recording) return "Recording";
                    else return "Waiting";
                }
                return "";
            }
        }

        #region Implementation of INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }


        #endregion

        public unsafe void Process(Complex* buffer, int length)
        {
            if (RecordingEnabled)
            {
                using (StreamWriter file = new StreamWriter(FileName, append: true))
                {
                    for (int i = 0; i < length; i++)
                    {
                        float modulus = buffer[i].Modulus();
                        float db = 20 * (float)Math.Log10(modulus);

                        if (db > ThresholdDb && RecordingEnabled && !Recording)
                        {
                            Recording = true;

                            _line.Append("Sample time[ms]").Append('\t');
                            if (ISaveEnabled) _line.Append("I").Append('\t');
                            if (QSaveEnabled) _line.Append("Q").Append('\t');
                            if (ModSaveEnabled) _line.Append("Modulus").Append('\t');
                            if (ArgSaveEnabled) _line.Append("Argument").Append('\t');
                            _line.Append('\n');
                        }

                        if (Recording)
                        {
                            _line.Append(SampleCount++/SampleRate*1000).Append('\t');
                            if (ISaveEnabled) _line.Append(buffer[i].Imag).Append('\t');
                            if (QSaveEnabled) _line.Append(buffer[i].Real).Append('\t');
                            if (ModSaveEnabled) _line.Append(modulus).Append('\t');
                            if (ArgSaveEnabled) _line.Append(buffer[i].Argument()).Append('\t');
                            _line.Append('\n');

                            // if neither full signal recording is selected
                            // nor a signal is detected, countdown the samples
                            if (!AutoRecord || db < ThresholdDb) _samplesToBeSaved--;
                            else ResetSamplesToBeSaved();

                            if (_samplesToBeSaved <= 0)
                            {
                                Recording = false;
                                RecordingEnabled = false;
                                SampleCount = 0;
                            }
                        }
                    }

                    if(_line.Length > 0) file.Write(_line);
                    _line.Clear();
                }
            }
        }

        private void ResetSamplesToBeSaved()
        {
            _samplesToBeSaved = (int)(SampleRate / 1000 * RecordingTime);
        }

        public bool PlotValuesFromCsv()
        {
            // check if in the selected folder there is a valid file to be plotted
            var fileList = new DirectoryInfo(SelectedFolder).GetFiles("SigRec_*.csv");
            if (fileList.Any())
            {
                var lastFile = fileList.Last().FullName;
                var data = new List<double[]>();
                var headers = new List<string>();

                // read the csv file
                using (var reader = new StreamReader(lastFile))
                {
                    // read the header
                    headers = reader.ReadLine().Split('\t').ToList();

                    while (!reader.EndOfStream)
                    {
                        var values = reader.ReadLine().Split('\t');
                        var dataRow = new double[headers.Count];

                        // cycle over the columns
                        for (int ind = 0; ind < headers.Count; ind++)
                        {
                            double.TryParse(values[ind], out var v);
                            dataRow[ind] = v;
                        }

                        data.Add(dataRow);
                    }
                }

                // create a ScottPlot
                var plt = new ScottPlot.Plot();

                plt.Title("Recorded data");
                plt.XLabel(headers[0]);
                plt.SetOuterViewLimits(data.First()[0] - 0.02 * data.Last()[0], data.Last()[0] + 0.02 * data.Last()[0]);

                for (int ind = 1; ind < headers.Count; ind++)
                {
                    plt.AddSignalXY(data.Select(x => x[0]).ToArray(), data.Select(x => x[ind]).ToArray(), label: headers[ind]);
                }

                plt.Legend(location: ScottPlot.Alignment.UpperRight);

                // launch it in a PlotViewer
                var pltForm = new ScottPlot.FormsPlotViewer(plt);
                pltForm.TopMost = true;
                pltForm.Show();

                return true;
            }
            else return false;
        }
    }
}
