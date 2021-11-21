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
    public partial class PlotForm : Form
    {
        public PlotForm()
        {
            InitializeComponent();
        }

        public PlotForm(string fileName) : this()
        {
            TestLabel.Text = fileName;
        }
    }
}
