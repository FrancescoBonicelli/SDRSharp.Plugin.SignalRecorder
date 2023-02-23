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
        private int _timePerFile;
        private int _samplesToBeSaved;
        private int _samplesPerFile;
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

        public int TimePerFile
        {
            get => _timePerFile;
            set
            {
                _timePerFile = value;
                ResetSamplesPerFile();
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
                else UpdateFileName();

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
                if (RecordingEnabled)
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
                //using (StreamWriter file = new StreamWriter(FileName, append: true))
                const int BufferSize = 65536;  // 64 Kilobytes
                StreamWriter file = new StreamWriter(FileName, append: true, Encoding.UTF8, BufferSize);

                for (int i = 0; i < length; i++)
                {
                    float modulus = buffer[i].Modulus();
                    float db = 20 * (float)Math.Log10(modulus);

                    if (db > ThresholdDb && RecordingEnabled && !Recording)
                    {
                        Recording = true;

                        MakeFileHeader();
                        file.Write(_line);
                        _line.Clear();
                    }

                    if (Recording)
                    {
                        _line.Append(SampleCount++ / SampleRate * 1000);
                        if (ISaveEnabled) _line.Append('\t').Append(buffer[i].Imag);
                        if (QSaveEnabled) _line.Append('\t').Append(buffer[i].Real);
                        if (ModSaveEnabled) _line.Append('\t').Append(modulus);
                        if (ArgSaveEnabled) _line.Append('\t').Append(buffer[i].Argument());
                        _line.Append('\n');
                        file.Write(_line);
                        _line.Clear();

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

                        if(_samplesPerFile > 0) _samplesPerFile--;
                        if(_samplesPerFile == 0 && Recording)
                        {
                            file.Close();
                            UpdateFileName();
                            ResetSamplesPerFile();
                            file = new StreamWriter(FileName, append: true, Encoding.UTF8, BufferSize);
                            MakeFileHeader();
                            file.Write(_line);
                            _line.Clear();
                        }
                    }
                }

                file.Close();
            }
        }

        private void ResetSamplesToBeSaved()
        {
            _samplesToBeSaved = (int)(SampleRate / 1000 * RecordingTime);
        }

        private void ResetSamplesPerFile()
        {
            _samplesPerFile = (int)(SampleRate / 1000 * TimePerFile);
        }

        private void UpdateFileName()
        {
            FileName = Path.Combine(SelectedFolder, "SigRec_" + DateTime.Now.ToString("yyyyMMddHHmmssff") + ".csv");
        }

        private void MakeFileHeader()
        {
            _line.Append("Sample time[ms]");
            if (ISaveEnabled) _line.Append('\t').Append("I");
            if (QSaveEnabled) _line.Append('\t').Append("Q");
            if (ModSaveEnabled) _line.Append('\t').Append("Modulus");
            if (ArgSaveEnabled) _line.Append('\t').Append("Argument");
            _line.Append('\n');
        }

        public bool PlotValuesFromCsv()
        {
            // check if in the selected folder there is a valid file to be plotted
            var fileList = new DirectoryInfo(SelectedFolder).GetFiles("SigRec_*.csv");
            if (fileList.Any())
            {
                try
                {
                    var lastFile = fileList.Last().FullName;

                    new PlotForm(lastFile).ShowDialog();

                    return true;
                }
                catch
                {
                    return false;
                }
            }
            else return false;
        }
    }
}
