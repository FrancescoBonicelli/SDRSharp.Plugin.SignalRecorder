using ScottPlot.Plottable;
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
    public partial class PlotForm : Form
    {
        public PlotForm(string fileName)
        {
            InitializeComponent();

            PlotFromFilename(fileName);
        }

        Dictionary<string, SignalPlotXY> PlotDictionary = new Dictionary<string, SignalPlotXY>();

        private void PlotFromFilename(string fileName)
        {
            var data = new List<double[]>();
            var headers = new List<string>();

            #region read the csv file
            using (var reader = new StreamReader(fileName))
            {
                // read the header
                headers = reader.ReadLine().Split('\t').ToList();

                // read the data
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
            #endregion

            #region populate the ScottPlot
            var plt = formsPlot.Plot;

            plt.XLabel(headers[0]);
            // set time limits
            plt.SetOuterViewLimits(data.First()[0] - 0.02 * data.Last()[0], data.Last()[0] + 0.02 * data.Last()[0]);

            // iterate over the readed data columns, plot them and add the plots to the global dictionary
            // add the relative visibility buttons
            CheckBox cb;
            for (int ind = 1; ind < headers.Count; ind++)
            {
                var name = headers[ind];
                PlotDictionary.Add(name, plt.AddSignalXY(data.Select(x => x[0]).ToArray(), data.Select(x => x[ind]).ToArray(), label: name));
                cb = new CheckBox();
                cb.Checked = true;
                cb.Text = name;
                cb.CheckedChanged += new EventHandler(CbCheckChanged);
                flowLayoutPanel.Controls.Add(cb);
            }

            plt.Legend(location: ScottPlot.Alignment.UpperRight);
            #endregion
        }

        private void CbCheckChanged(object sender, EventArgs e)
        {
            var cb = sender as CheckBox;

            SignalPlotXY plt;

            if(PlotDictionary.TryGetValue(cb.Text, out plt))
            {
                plt.IsVisible = cb.Checked;
                formsPlot.Refresh();
            }
        }
    }
}
