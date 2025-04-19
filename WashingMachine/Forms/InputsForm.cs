using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WashingMachine
{
    public partial class InputsForm : Form
    {
        public InputsForm()
        {
            InitializeComponent();
            numericUpDown_Pollution.Parent.Controls.Add(chart3);
            numericUpDown_Quantity.Parent.Controls.Add(chart2);
            numericUpDown_Sensivity.Parent.Controls.Add(chart1);

            trackBar_Pollution.Parent.Controls.Add(chart3);
            trackBar_Quantity.Parent.Controls.Add(chart2);
            trackBar_Sensitive.Parent.Controls.Add(chart1);
        }

        private void button_minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void numericUpDown_Inputs_ValueChanged(object sender, EventArgs e)
        {
            if (!(sender as Control).Focused) return;
            NumericUpDown activeNumericUpDown = (sender as NumericUpDown);

            updateTrackBarValue(activeNumericUpDown);
            setChartValueFromNumericUpDown(activeNumericUpDown);
        }

        private void trackBar_Inputs_Value_Scroll(object sender, EventArgs e)
        {
            if(!(sender as Control).Focused) return;
            TrackBar activeTrackBar = (sender as TrackBar);

            updateNumericUpDownValue(activeTrackBar);
            setChartValueFromTrackBar(activeTrackBar);
        }

        private void setChartValueFromNumericUpDown(NumericUpDown activeNumericUpDown)
        {
            Chart activeChart = activeNumericUpDown.Parent.Controls
                .OfType<Chart>()
                .FirstOrDefault(c => c.Tag.ToString().Equals(activeNumericUpDown.Tag?.ToString()));
            var temp = (double)activeNumericUpDown.Value;
            double x = temp > 0 ? temp : 0.03;

            activeChart.Series[3].Points[0].XValue = x;

            string linestr = ""; // TODO: Burasi mantik
            activeChart.Series[3].Label = linestr.Length > 5 ? linestr.Substring(0,5) : linestr;
        }

        private void setChartValueFromTrackBar(TrackBar activeTrackBar)
        {
            Chart activeChart = activeTrackBar.Parent.Controls
                .OfType<Chart>()
                .FirstOrDefault(c => c.Tag.ToString().Equals(activeTrackBar.Tag?.ToString()));
            var temp = (double)activeTrackBar.Value/1000;
            double x = temp > 0 ? temp : 0.03;

            activeChart.Series[3].Points[0].XValue = x;

            string linestr = ""; // TODO: Burasi mantik
            activeChart.Series[3].Label = linestr.Length > 5 ? linestr.Substring(0, 5) : linestr;
        }

        private void updateTrackBarValue(NumericUpDown activeNumericUpDown)
        {
            TrackBar activeTrackBar = activeNumericUpDown.Parent.Controls
                .OfType<TrackBar>()
                .FirstOrDefault(c => c.Tag.ToString().Equals(activeNumericUpDown.Tag?.ToString()));
            var temp = (double)activeNumericUpDown.Value * 1000;
            double x = temp > 0 ? temp : 30;
            activeTrackBar.Value = (int)x;
        }

        private void updateNumericUpDownValue(TrackBar activeTrackBar)
        {
            NumericUpDown activeNumericUpDown = activeTrackBar.Parent.Controls
                .OfType<NumericUpDown>()
                .FirstOrDefault(c => c.Tag.ToString().Equals(activeTrackBar.Tag?.ToString()));
            var temp = (double)activeTrackBar.Value / 1000;

            double x = temp > 0 ? temp : 0.03;

            activeNumericUpDown.Value = (decimal)x;
        }

        private void calculate()
        {
           
        }

        private void button_startFuzzification_Click(object sender, EventArgs e)
        {
            calculate();
        }

        
    }
}
