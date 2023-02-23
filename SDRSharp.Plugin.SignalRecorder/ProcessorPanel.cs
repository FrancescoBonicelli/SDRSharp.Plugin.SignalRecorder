using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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

            #region data bindings
            SelectedFolderLabel.DataBindings.Add("Text", processor, nameof(processor.SelectedFolder));
            StartRecordingCheckBox.DataBindings.Add("Checked", processor, nameof(processor.RecordingEnabled));
            RecordingStatusLabel.DataBindings.Add("Text", processor, nameof(processor.RecordingStatus));

            // if recording enabled -> disable the file related buttons
            ChangeFolderBtn.DataBindings.Add("Enabled", _processor, nameof(processor.RecordingDisabled));
            ICheckBox.DataBindings.Add("Enabled", _processor, nameof(processor.NotRecording));
            QCheckBox.DataBindings.Add("Enabled", _processor, nameof(processor.NotRecording));
            ModCheckBox.DataBindings.Add("Enabled", _processor, nameof(processor.NotRecording));
            ArgCheckBox.DataBindings.Add("Enabled", _processor, nameof(processor.NotRecording));
            #endregion

            #region event bindings, labels initial value
            ThresholdValue.ValueChanged += new EventHandler(ThresholdValueChanged);
            ThresholdValueChanged();

            ChangeFolderBtn.MouseClick += new MouseEventHandler(ChangeFolderBtnClicked);

            AutoRecordCheckBox.MouseClick += new MouseEventHandler(AutoRecordBtnClicked);

            RecordingTimeValue.TextChanged += new EventHandler(RecordingTimeChanged);
            RecordingTimeChanged();
            TimePerFileValue.TextChanged += new EventHandler(TimePerFileChanged);
            TimePerFileChanged();

            ICheckBox.MouseClick += new MouseEventHandler(ICheckBoxClicked);
            QCheckBox.MouseClick += new MouseEventHandler(QCheckBoxClicked);
            ModCheckBox.MouseClick += new MouseEventHandler(ModCheckBoxClicked);
            ArgCheckBox.MouseClick += new MouseEventHandler(ArgCheckBoxClicked);

            StartRecordingCheckBox.MouseClick += new MouseEventHandler(RecordingBtnClicked);

            PlotBtn.MouseClick += new MouseEventHandler(PlotBtnClicked);
            PlotReportLabel.Text = "";
            #endregion

            #region tooltips
            // Create the ToolTip
            ToolTip toolTip1 = new ToolTip();

            toolTip1.SetToolTip(ThresholdLabel, "Signal level above which recording starts");
            toolTip1.SetToolTip(FolderLabel, "Folder where the recorded data is stored");
            toolTip1.SetToolTip(AutoRecordCheckBox, "If checked the recording continues as long as the signal is greather than the threshold");
            toolTip1.SetToolTip(RecordingTimeLabel, "How long the recording lasts");
            toolTip1.SetToolTip(DataLabel, "Data to be saved");
            toolTip1.SetToolTip(StartRecordingCheckBox, "Recording enable (the recording starts when the signal exceeds the threshold");
            #endregion
        }

        #region threshold
        private void ThresholdValueChanged(object sender, System.EventArgs e)
        {
            ThresholdValueChanged();
        }

        private void ThresholdValueChanged()
        {
            _processor.ThresholdDb = ThresholdValue.Value - 100;
            ThresholdValueLabel.Text = _processor.ThresholdDb.ToString();
        }
        #endregion

        #region folder
        private void ChangeFolderBtnClicked(object sender, MouseEventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                _processor.SelectedFolder = folderBrowserDialog1.SelectedPath;
            };
        }
        #endregion

        #region recording time
        private void AutoRecordBtnClicked(object sender, MouseEventArgs e)
        {
            _processor.AutoRecord = AutoRecordCheckBox.Checked;

            ToolTip toolTip1 = new ToolTip();

            RecordingTimeLabel.Text = AutoRecordCheckBox.Checked ? "Low Signal Time [ms]:" : "Recording Time [ms]:";
            toolTip1.SetToolTip(RecordingTimeLabel, AutoRecordCheckBox.Checked ?
                                "How long the signal can stay lower than the treshold before stopping the recording" :
                                "How long the recording lasts");
        }

        private void RecordingTimeChanged(object sender, EventArgs e)
        {
            RecordingTimeChanged();
        }

        private void TimePerFileChanged(object sender, EventArgs e)
        {
            TimePerFileChanged();
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
                _processor.RecordingEnabled = false;
                RecordingTimeErrorLabel.Text = "Error";
            }
        }

        private void TimePerFileChanged()
        {
            try
            {
                _processor.TimePerFile = Convert.ToInt32(TimePerFileValue.Text);
                TimePerFileErrorLabel.Text = "";
            }
            catch
            {
                _processor.RecordingEnabled = false;
                TimePerFileErrorLabel.Text = "Error";
            }
        }
        #endregion

        #region recording data
        private void ICheckBoxClicked(object sender, MouseEventArgs e)
        {
            _processor.ISaveEnabled = ICheckBox.Checked;
        }

        private void QCheckBoxClicked(object sender, MouseEventArgs e)
        {
            _processor.QSaveEnabled = QCheckBox.Checked;
        }

        private void ModCheckBoxClicked(object sender, MouseEventArgs e)
        {
            _processor.ModSaveEnabled = ModCheckBox.Checked;
        }

        private void ArgCheckBoxClicked(object sender, MouseEventArgs e)
        {
            _processor.ArgSaveEnabled = ArgCheckBox.Checked;
        }
        #endregion

        #region recording btn
        private void RecordingBtnClicked(object sender, MouseEventArgs e)
        {
            _processor.RecordingEnabled = !_processor.RecordingEnabled;

            // process the recording time
            RecordingTimeChanged();
        }
        #endregion

        #region plot btn
        private void PlotBtnClicked(object sender, MouseEventArgs e)
        {
            PlotReportLabel.Text = _processor.PlotValuesFromCsv() ? "" : "No valid file in " + _processor.SelectedFolder;
        }
        #endregion

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void ModCheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void DataLabel_Click(object sender, EventArgs e)
        {

        }

        private void QCheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ArgCheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void RecordingStatusLabel_Click(object sender, EventArgs e)
        {

        }

        private void StartRecordingCheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ICheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void PlotBtn_Click(object sender, EventArgs e)
        {

        }

        private void PlotReportLabel_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
