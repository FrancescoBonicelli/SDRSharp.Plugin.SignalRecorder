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

        private void PlotFromFilename(string fileName)
        {
            var data = new List<double[]>();
            var headers = new List<string>();

            // read the csv file
            using (var reader = new StreamReader(fileName))
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
            var plt = formsPlot.Plot;

            plt.XLabel(headers[0]);
            plt.SetOuterViewLimits(data.First()[0] - 0.02 * data.Last()[0], data.Last()[0] + 0.02 * data.Last()[0]);

            for (int ind = 1; ind < headers.Count; ind++)
            {
                plt.AddSignalXY(data.Select(x => x[0]).ToArray(), data.Select(x => x[ind]).ToArray(), label: headers[ind]);
            }

            plt.Legend(location: ScottPlot.Alignment.UpperRight);
        }
    }
}
