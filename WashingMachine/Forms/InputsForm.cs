using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using WashingMachine.Forms;
using WashingMachine.FuzzyLogicEngine;
using WashingMachine.PanelHelper;

namespace WashingMachine
{
    public partial class InputsForm : Form
    {
        private InputPanelHelper inputPanelHelper;

        private const int DWMWA_USE_IMMERSIVE_DARK_MODE = 20;
        public InputsForm()
        {
            InitializeComponent();
            loadIcon();
            inputPanelHelper = new InputPanelHelper(this);

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterScreen;

            setParentControls();
            fuzzificateWithSettedInputs();

            IntPtr hWnd = this.Handle;
            int attrValue = 2; // 2 = dark mode, 1 = light mode
            DwmSetWindowAttribute(hWnd, DWMWA_USE_IMMERSIVE_DARK_MODE, ref attrValue, sizeof(int));
        }
        [DllImport("dwmapi.dll", CharSet = CharSet.Unicode, SetLastError = true)]

        private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);

        private void fuzzificateWithSettedInputs()
        {
            inputPanelHelper.calculate
                ((double)numericUpDown_Sensivity.Value, (double)numericUpDown_Quantity.Value, (double)numericUpDown_Pollution.Value);

            inputPanelHelper.updatePanelSources(null);
        }

        private void setParentControls()
        {
            chart1.BringToFront();
            chart2.BringToFront();
            chart3.BringToFront();

            numericUpDown_Pollution.Parent.Controls.Add(chart3);
            numericUpDown_Quantity.Parent.Controls.Add(chart2);
            numericUpDown_Sensivity.Parent.Controls.Add(chart1);
            chart1.Series[3].Points[0].XValue = 5.0;
            chart2.Series[3].Points[0].XValue = 3.0;
            chart3.Series[3].Points[0].XValue = 3.9;
            trackBar_Pollution.Parent.Controls.Add(chart3);
            trackBar_Quantity.Parent.Controls.Add(chart2);
            trackBar_Sensitive.Parent.Controls.Add(chart1);
        }

        private void loadIcon()
        {
            try
            {
                string imagePath = Path.Combine(Application.StartupPath, "WashingMachineIcon.ico");
                this.Icon = new Icon(imagePath);

                string backGroundImagePath = Path.Combine(Application.StartupPath, "background.png");

                Image image = Image.FromFile(backGroundImagePath);

                this.BackgroundImage = image;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Resim yüklenirken hata oluştu: " + ex.Message);
            }
        }

        private void button_minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void numericUpDown_Inputs_ValueChanged(object sender, EventArgs e)
        {
            if (!(sender as Control).Focused) return;
            NumericUpDown activeNumericUpDown = (sender as NumericUpDown);

            updateTrackBarValue(activeNumericUpDown);
            setChartValueFromNumericUpDown(activeNumericUpDown);

            startFuzzification();
            Chart activeChart = activeNumericUpDown.Parent.Controls
                .OfType<Chart>()
                .FirstOrDefault(c => c.Tag.ToString().Equals(activeNumericUpDown.Tag?.ToString()));

            inputPanelHelper.updatePanelSources(activeChart);
        }

        private void trackBar_Inputs_Value_Scroll(object sender, EventArgs e)
        {
            if(!(sender as Control).Focused) return;
            TrackBar activeTrackBar = (sender as TrackBar);

            updateNumericUpDownValue(activeTrackBar);
            setChartValueFromTrackBar(activeTrackBar);

            startFuzzification();
            Chart activeChart = activeTrackBar.Parent.Controls
                .OfType<Chart>()
                .FirstOrDefault(c => c.Tag.ToString().Equals(activeTrackBar.Tag?.ToString()));

            inputPanelHelper.updatePanelSources(activeChart);
        }

        private void setChartValueFromNumericUpDown(NumericUpDown activeNumericUpDown)
        {
            Chart activeChart = activeNumericUpDown.Parent.Controls
                .OfType<Chart>()
                .FirstOrDefault(c => c.Tag.ToString().Equals(activeNumericUpDown.Tag?.ToString()));
            var temp = (double)activeNumericUpDown.Value;
            double x = temp > 0 ? temp : 0.03;

            activeChart.Series[3].Points[0].XValue = x;
        }

        private void setChartValueFromTrackBar(TrackBar activeTrackBar)
        {
            Chart activeChart = activeTrackBar.Parent.Controls
                .OfType<Chart>()
                .FirstOrDefault(c => c.Tag.ToString().Equals(activeTrackBar.Tag?.ToString()));
            var temp = (double)activeTrackBar.Value/1000;
            double x = temp > 0 ? temp : 0.03;

            activeChart.Series[3].Points[0].XValue = x;
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

        private void startFuzzification()
        {
            inputPanelHelper.calculate(
                (double)numericUpDown_Sensivity.Value,
                (double)numericUpDown_Quantity.Value,
                (double)numericUpDown_Pollution.Value);
        }

        //Deprecated
        private void button_startFuzzification_Click(object sender, EventArgs e)
        {
            //globalExceptionHandler ile input kontrolu sagla.
            // Deprecated 
            inputPanelHelper.calculate
                ((double)numericUpDown_Sensivity.Value, (double)numericUpDown_Quantity.Value, (double)numericUpDown_Pollution.Value);
        }

        private void button_ShowRules_Click(object sender, EventArgs e)
        {
            ShowRulesForm showRulesForm = new ShowRulesForm(inputPanelHelper.suitableRules);
            showRulesForm.ShowDialog();

        }
    }
}
