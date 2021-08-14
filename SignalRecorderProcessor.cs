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
        private double _sampleRate;
        private int _thresholdDb;
        private int _recordingTime;
        private int _samplesToBeSaved;
        private bool _enabled;
        private bool _recordingEnabled;
        private bool _recording;
        private bool _autoRecord;
        private string _selectedFolder;
        private string _fileName;

        public double SampleRate
        {
            get => _sampleRate;
            set
            {
                _sampleRate = value;
            }
        }

        public int ThresholdDb
        {
            get => _thresholdDb;
            set => _thresholdDb = value;
        }

        public int RecordingTime
        {
            get => _recordingTime;
            set
            {
                _recordingTime = value;
                _samplesToBeSaved = (int)(SampleRate / 1000 * value);
            }
        }

        // plugin enabled from the SDRSharp menu
        public bool Enabled
        {
            get => _enabled;
            set => _enabled = value;
        }

        public bool RecordingEnabled
        {
            get => _recordingEnabled;
            set
            {
                if (!value) _recording = false;
                // if enabled create a new file name
                else FileName = Path.Combine(SelectedFolder, DateTime.Now.ToString("yyyyMMddHHmmssffff") + "_" + SampleRate.ToString() + ".csv");
                
                _recordingEnabled = value;
                RaisePropertyChanged("RecordingEnabled");
            }
        }

        public bool AutoRecord
        {
            get => _autoRecord;
            set => _autoRecord = value;
        }

        public string SelectedFolder
        {
            get => _selectedFolder;
            set
            {
                _selectedFolder = value;
                RaisePropertyChanged("SelectedFolder");
            }
        }

        public string FileName
        {
            get => _fileName;
            set => _fileName = value;
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

                        if (db > ThresholdDb && RecordingEnabled) _recording = true;

                        if (_recording)
                        {
                            file.WriteLine(modulus);

                            _samplesToBeSaved--;

                            // if full signal recording and signal readed, reset the samples
                            if (AutoRecord && db > ThresholdDb) RecordingTime = RecordingTime;

                            if (_samplesToBeSaved <= 0)
                            {
                                _recording = false;
                                RecordingEnabled = false;
                            }
                        }
                    }
                }
            }
        }
    }
}
