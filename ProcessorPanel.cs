using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SDRSharp.Plugin.SignalRecorder
{
    public partial class ProcessorPanel : UserControl
    {
        private SignalRecorderProcessor _processor;

        public ProcessorPanel(SignalRecorderProcessor processor)
        {
            _processor = processor;

            InitializeComponent();

            SelectedFolderLabel.DataBindings.Add("Text", processor, "SelectedFolder");
            StartRecordingCheckBox.DataBindings.Add("Checked", processor, "RecordingEnabled");

            ThresholdValue.ValueChanged += new EventHandler(ThresholdValueChanged);
            ThresholdValueChanged();

            ChangeFolderBtn.MouseClick += new MouseEventHandler(ChangeFolderBtnClicked);

            AutoRecordCheckBox.MouseClick += new MouseEventHandler(AutoRecordBtnClick);

            RecordingTimeValue.TextChanged += new EventHandler(RecordingTimeChanged);
            RecordingTimeChanged();

            StartRecordingCheckBox.MouseClick += new MouseEventHandler(RecordingBtnClicked);
        }

        private void RecordingBtnClicked(object sender, MouseEventArgs e)
        {
            _processor.RecordingEnabled = !_processor.RecordingEnabled;
            RecordingTimeChanged();
        }

        private void RecordingTimeChanged(object sender, EventArgs e)
        {
            RecordingTimeChanged();
        }

        private void AutoRecordBtnClick(object sender, MouseEventArgs e)
        {
            _processor.AutoRecord = AutoRecordCheckBox.Checked;

            RecordingTimeLabel.Text = AutoRecordCheckBox.Checked ? "Low Signal Time [ms]:" : "Recording Time [ms]:";
        }

        private void RecordingTimeChanged()
        {
            try
            {
                _processor.RecordingTime = Convert.ToInt32(RecordingTimeValue.Text);
                RecordingTimeErrorLabel.Text = "";
            }
            catch
            {
                RecordingTimeErrorLabel.Text = "Error";
            }
        }

        private void ChangeFolderBtnClicked(object sender, MouseEventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                _processor.SelectedFolder = folderBrowserDialog1.SelectedPath;
            };
        }

        private void ThresholdValueChanged(object sender, System.EventArgs e)
        {
            ThresholdValueChanged();
        }
        
        private void ThresholdValueChanged()
        {
            _processor.ThresholdDb = ThresholdValue.Value - 100;
            ThresholdValueLabel.Text = _processor.ThresholdDb.ToString();
        }
    }
}
