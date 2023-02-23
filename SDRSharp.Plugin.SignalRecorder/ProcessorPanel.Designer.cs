
namespace SDRSharp.Plugin.SignalRecorder
{
    partial class ProcessorPanel
    {
        /// <summary> 
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione componenti

        /// <summary> 
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare 
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.ThresholdLabel = new System.Windows.Forms.Label();
            this.ThresholdValue = new System.Windows.Forms.TrackBar();
            this.ThresholdValueLabel = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.SelectedFolderLabel = new System.Windows.Forms.Label();
            this.ChangeFolderBtn = new System.Windows.Forms.Button();
            this.FolderLabel = new System.Windows.Forms.Label();
            this.RecordingTimeLabel = new System.Windows.Forms.Label();
            this.RecordingTimeValue = new System.Windows.Forms.TextBox();
            this.RecordingTimeErrorLabel = new System.Windows.Forms.Label();
            this.StartRecordingCheckBox = new System.Windows.Forms.CheckBox();
            this.AutoRecordCheckBox = new System.Windows.Forms.CheckBox();
            this.label0 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.DataLabel = new System.Windows.Forms.Label();
            this.ICheckBox = new System.Windows.Forms.CheckBox();
            this.QCheckBox = new System.Windows.Forms.CheckBox();
            this.ModCheckBox = new System.Windows.Forms.CheckBox();
            this.ArgCheckBox = new System.Windows.Forms.CheckBox();
            this.RecordingStatusLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.PlotBtn = new System.Windows.Forms.Button();
            this.PlotReportLabel = new System.Windows.Forms.Label();
            this.TimePerFileLabel = new System.Windows.Forms.Label();
            this.TimePerFileValue = new System.Windows.Forms.TextBox();
            this.TimePerFileErrorLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ThresholdValue)).BeginInit();
            this.SuspendLayout();
            // 
            // ThresholdLabel
            // 
            this.ThresholdLabel.AutoSize = true;
            this.ThresholdLabel.Location = new System.Drawing.Point(0, 0);
            this.ThresholdLabel.Name = "ThresholdLabel";
            this.ThresholdLabel.Size = new System.Drawing.Size(74, 20);
            this.ThresholdLabel.TabIndex = 0;
            this.ThresholdLabel.Text = "Threshold";
            // 
            // ThresholdValue
            // 
            this.ThresholdValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ThresholdValue.Location = new System.Drawing.Point(80, 0);
            this.ThresholdValue.Maximum = 100;
            this.ThresholdValue.Name = "ThresholdValue";
            this.ThresholdValue.Size = new System.Drawing.Size(121, 56);
            this.ThresholdValue.TabIndex = 1;
            this.ThresholdValue.Value = 50;
            // 
            // ThresholdValueLabel
            // 
            this.ThresholdValueLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ThresholdValueLabel.AutoSize = true;
            this.ThresholdValueLabel.Location = new System.Drawing.Point(208, 0);
            this.ThresholdValueLabel.Name = "ThresholdValueLabel";
            this.ThresholdValueLabel.Size = new System.Drawing.Size(31, 20);
            this.ThresholdValueLabel.TabIndex = 3;
            this.ThresholdValueLabel.Text = "-50";
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.RootFolder = System.Environment.SpecialFolder.MyDocuments;
            // 
            // SelectedFolderLabel
            // 
            this.SelectedFolderLabel.AutoSize = true;
            this.SelectedFolderLabel.Location = new System.Drawing.Point(0, 93);
            this.SelectedFolderLabel.Name = "SelectedFolderLabel";
            this.SelectedFolderLabel.Size = new System.Drawing.Size(49, 20);
            this.SelectedFolderLabel.TabIndex = 4;
            this.SelectedFolderLabel.Text = "folder";
            // 
            // ChangeFolderBtn
            // 
            this.ChangeFolderBtn.Location = new System.Drawing.Point(137, 58);
            this.ChangeFolderBtn.Name = "ChangeFolderBtn";
            this.ChangeFolderBtn.Size = new System.Drawing.Size(115, 29);
            this.ChangeFolderBtn.TabIndex = 5;
            this.ChangeFolderBtn.Text = "Change Folder";
            this.ChangeFolderBtn.UseVisualStyleBackColor = true;
            // 
            // FolderLabel
            // 
            this.FolderLabel.AutoSize = true;
            this.FolderLabel.Location = new System.Drawing.Point(0, 62);
            this.FolderLabel.Name = "FolderLabel";
            this.FolderLabel.Size = new System.Drawing.Size(134, 20);
            this.FolderLabel.TabIndex = 6;
            this.FolderLabel.Text = "Saving Folder Path:";
            // 
            // RecordingTimeLabel
            // 
            this.RecordingTimeLabel.AutoSize = true;
            this.RecordingTimeLabel.Location = new System.Drawing.Point(0, 184);
            this.RecordingTimeLabel.Name = "RecordingTimeLabel";
            this.RecordingTimeLabel.Size = new System.Drawing.Size(150, 20);
            this.RecordingTimeLabel.TabIndex = 7;
            this.RecordingTimeLabel.Text = "Recording Time (ms):";
            // 
            // RecordingTimeValue
            // 
            this.RecordingTimeValue.Location = new System.Drawing.Point(161, 181);
            this.RecordingTimeValue.Name = "RecordingTimeValue";
            this.RecordingTimeValue.Size = new System.Drawing.Size(40, 27);
            this.RecordingTimeValue.TabIndex = 8;
            this.RecordingTimeValue.Text = "10";
            this.RecordingTimeValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // RecordingTimeErrorLabel
            // 
            this.RecordingTimeErrorLabel.AutoSize = true;
            this.RecordingTimeErrorLabel.Location = new System.Drawing.Point(208, 184);
            this.RecordingTimeErrorLabel.Name = "RecordingTimeErrorLabel";
            this.RecordingTimeErrorLabel.Size = new System.Drawing.Size(41, 20);
            this.RecordingTimeErrorLabel.TabIndex = 9;
            this.RecordingTimeErrorLabel.Text = "Error";
            // 
            // StartRecordingCheckBox
            // 
            this.StartRecordingCheckBox.AutoSize = true;
            this.StartRecordingCheckBox.Location = new System.Drawing.Point(0, 394);
            this.StartRecordingCheckBox.Name = "StartRecordingCheckBox";
            this.StartRecordingCheckBox.Size = new System.Drawing.Size(148, 24);
            this.StartRecordingCheckBox.TabIndex = 10;
            this.StartRecordingCheckBox.Text = "Enable Recording";
            this.StartRecordingCheckBox.UseVisualStyleBackColor = true;
            this.StartRecordingCheckBox.CheckedChanged += new System.EventHandler(this.StartRecordingCheckBox_CheckedChanged);
            // 
            // AutoRecordCheckBox
            // 
            this.AutoRecordCheckBox.AutoSize = true;
            this.AutoRecordCheckBox.Location = new System.Drawing.Point(0, 139);
            this.AutoRecordCheckBox.Name = "AutoRecordCheckBox";
            this.AutoRecordCheckBox.Size = new System.Drawing.Size(150, 24);
            this.AutoRecordCheckBox.TabIndex = 11;
            this.AutoRecordCheckBox.Text = "Full Signal Record";
            this.AutoRecordCheckBox.UseVisualStyleBackColor = true;
            // 
            // label0
            // 
            this.label0.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label0.Location = new System.Drawing.Point(0, 46);
            this.label0.Name = "label0";
            this.label0.Size = new System.Drawing.Size(255, 2);
            this.label0.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(0, 125);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(255, 2);
            this.label1.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(0, 267);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(255, 2);
            this.label2.TabIndex = 14;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Location = new System.Drawing.Point(0, 384);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(255, 2);
            this.label3.TabIndex = 15;
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // DataLabel
            // 
            this.DataLabel.AutoSize = true;
            this.DataLabel.Location = new System.Drawing.Point(0, 280);
            this.DataLabel.Name = "DataLabel";
            this.DataLabel.Size = new System.Drawing.Size(44, 20);
            this.DataLabel.TabIndex = 16;
            this.DataLabel.Text = "Data:";
            this.DataLabel.Click += new System.EventHandler(this.DataLabel_Click);
            // 
            // ICheckBox
            // 
            this.ICheckBox.AutoSize = true;
            this.ICheckBox.Location = new System.Drawing.Point(0, 313);
            this.ICheckBox.Name = "ICheckBox";
            this.ICheckBox.Size = new System.Drawing.Size(35, 24);
            this.ICheckBox.TabIndex = 17;
            this.ICheckBox.Text = "I";
            this.ICheckBox.UseVisualStyleBackColor = true;
            this.ICheckBox.CheckedChanged += new System.EventHandler(this.ICheckBox_CheckedChanged);
            // 
            // QCheckBox
            // 
            this.QCheckBox.AutoSize = true;
            this.QCheckBox.Location = new System.Drawing.Point(122, 313);
            this.QCheckBox.Name = "QCheckBox";
            this.QCheckBox.Size = new System.Drawing.Size(42, 24);
            this.QCheckBox.TabIndex = 18;
            this.QCheckBox.Text = "Q";
            this.QCheckBox.UseVisualStyleBackColor = true;
            this.QCheckBox.CheckedChanged += new System.EventHandler(this.QCheckBox_CheckedChanged);
            // 
            // ModCheckBox
            // 
            this.ModCheckBox.AutoSize = true;
            this.ModCheckBox.Location = new System.Drawing.Point(0, 344);
            this.ModCheckBox.Name = "ModCheckBox";
            this.ModCheckBox.Size = new System.Drawing.Size(88, 24);
            this.ModCheckBox.TabIndex = 19;
            this.ModCheckBox.Text = "Modulus";
            this.ModCheckBox.UseVisualStyleBackColor = true;
            this.ModCheckBox.CheckedChanged += new System.EventHandler(this.ModCheckBox_CheckedChanged);
            // 
            // ArgCheckBox
            // 
            this.ArgCheckBox.AutoSize = true;
            this.ArgCheckBox.Location = new System.Drawing.Point(122, 344);
            this.ArgCheckBox.Name = "ArgCheckBox";
            this.ArgCheckBox.Size = new System.Drawing.Size(97, 24);
            this.ArgCheckBox.TabIndex = 20;
            this.ArgCheckBox.Text = "Argument";
            this.ArgCheckBox.UseVisualStyleBackColor = true;
            this.ArgCheckBox.CheckedChanged += new System.EventHandler(this.ArgCheckBox_CheckedChanged);
            // 
            // RecordingStatusLabel
            // 
            this.RecordingStatusLabel.AutoSize = true;
            this.RecordingStatusLabel.Location = new System.Drawing.Point(161, 395);
            this.RecordingStatusLabel.Name = "RecordingStatusLabel";
            this.RecordingStatusLabel.Size = new System.Drawing.Size(49, 20);
            this.RecordingStatusLabel.TabIndex = 21;
            this.RecordingStatusLabel.Text = "Status";
            this.RecordingStatusLabel.Click += new System.EventHandler(this.RecordingStatusLabel_Click);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Location = new System.Drawing.Point(0, 430);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(255, 2);
            this.label4.TabIndex = 22;
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // PlotBtn
            // 
            this.PlotBtn.Location = new System.Drawing.Point(0, 444);
            this.PlotBtn.Name = "PlotBtn";
            this.PlotBtn.Size = new System.Drawing.Size(252, 29);
            this.PlotBtn.TabIndex = 23;
            this.PlotBtn.Text = "Plot Last Recorded Data";
            this.PlotBtn.UseVisualStyleBackColor = true;
            this.PlotBtn.Click += new System.EventHandler(this.PlotBtn_Click);
            // 
            // PlotReportLabel
            // 
            this.PlotReportLabel.AutoSize = true;
            this.PlotReportLabel.Location = new System.Drawing.Point(3, 485);
            this.PlotReportLabel.Name = "PlotReportLabel";
            this.PlotReportLabel.Size = new System.Drawing.Size(80, 20);
            this.PlotReportLabel.TabIndex = 24;
            this.PlotReportLabel.Text = "PlotReport";
            this.PlotReportLabel.Click += new System.EventHandler(this.PlotReportLabel_Click);
            // 
            // TimePerFileLabel
            // 
            this.TimePerFileLabel.AutoSize = true;
            this.TimePerFileLabel.Location = new System.Drawing.Point(0, 224);
            this.TimePerFileLabel.Name = "TimePerFileLabel";
            this.TimePerFileLabel.Size = new System.Drawing.Size(163, 20);
            this.TimePerFileLabel.TabIndex = 7;
            this.TimePerFileLabel.Text = "Max Time per File (ms):";
            // 
            // TimePerFileValue
            // 
            this.TimePerFileValue.Location = new System.Drawing.Point(161, 221);
            this.TimePerFileValue.Name = "TimePerFileValue";
            this.TimePerFileValue.Size = new System.Drawing.Size(40, 27);
            this.TimePerFileValue.TabIndex = 8;
            this.TimePerFileValue.Text = "-1";
            this.TimePerFileValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TimePerFileErrorLabel
            // 
            this.TimePerFileErrorLabel.AutoSize = true;
            this.TimePerFileErrorLabel.Location = new System.Drawing.Point(208, 224);
            this.TimePerFileErrorLabel.Name = "TimePerFileErrorLabel";
            this.TimePerFileErrorLabel.Size = new System.Drawing.Size(41, 20);
            this.TimePerFileErrorLabel.TabIndex = 9;
            this.TimePerFileErrorLabel.Text = "Error";
            // 
            // ProcessorPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PlotReportLabel);
            this.Controls.Add(this.PlotBtn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.RecordingStatusLabel);
            this.Controls.Add(this.ArgCheckBox);
            this.Controls.Add(this.ModCheckBox);
            this.Controls.Add(this.QCheckBox);
            this.Controls.Add(this.ICheckBox);
            this.Controls.Add(this.DataLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label0);
            this.Controls.Add(this.AutoRecordCheckBox);
            this.Controls.Add(this.StartRecordingCheckBox);
            this.Controls.Add(this.TimePerFileErrorLabel);
            this.Controls.Add(this.RecordingTimeErrorLabel);
            this.Controls.Add(this.TimePerFileValue);
            this.Controls.Add(this.RecordingTimeValue);
            this.Controls.Add(this.TimePerFileLabel);
            this.Controls.Add(this.RecordingTimeLabel);
            this.Controls.Add(this.FolderLabel);
            this.Controls.Add(this.ChangeFolderBtn);
            this.Controls.Add(this.SelectedFolderLabel);
            this.Controls.Add(this.ThresholdValueLabel);
            this.Controls.Add(this.ThresholdValue);
            this.Controls.Add(this.ThresholdLabel);
            this.Name = "ProcessorPanel";
            this.Size = new System.Drawing.Size(255, 529);
            ((System.ComponentModel.ISupportInitialize)(this.ThresholdValue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ThresholdLabel;
        private System.Windows.Forms.TrackBar ThresholdValue;
        private System.Windows.Forms.Label ThresholdValueLabel;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label SelectedFolderLabel;
        private System.Windows.Forms.Button ChangeFolderBtn;
        private System.Windows.Forms.Label FolderLabel;
        private System.Windows.Forms.Label RecordingTimeLabel;
        private System.Windows.Forms.TextBox RecordingTimeValue;
        private System.Windows.Forms.Label RecordingTimeErrorLabel;
        private System.Windows.Forms.CheckBox StartRecordingCheckBox;
        private System.Windows.Forms.CheckBox AutoRecordCheckBox;
        private System.Windows.Forms.Label label0;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label DataLabel;
        private System.Windows.Forms.CheckBox ICheckBox;
        private System.Windows.Forms.CheckBox QCheckBox;
        private System.Windows.Forms.CheckBox ModCheckBox;
        private System.Windows.Forms.CheckBox ArgCheckBox;
        private System.Windows.Forms.Label RecordingStatusLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button PlotBtn;
        private System.Windows.Forms.Label PlotReportLabel;
        private System.Windows.Forms.Label TimePerFileLabel;
        private System.Windows.Forms.TextBox TimePerFileValue;
        private System.Windows.Forms.Label TimePerFileErrorLabel;
    }
}
