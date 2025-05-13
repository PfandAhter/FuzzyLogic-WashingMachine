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
using WashingMachine.Constants;

namespace WashingMachine.Forms
{
    public partial class AddRuleForm : Form
    {
        public string sensitivity;
        public string quantity;
        public string pollution;
        public string rotation;
        public string detergent;
        public string duration;

        private const int DWMWA_USE_IMMERSIVE_DARK_MODE = 20;

        public AddRuleForm()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterScreen;


            string imagePath = Path.Combine(Application.StartupPath, "WashingMachineIcon.ico");
            this.Icon = new Icon(imagePath);

            IntPtr hWnd = this.Handle;
            int attrValue = 2; // 2 = dark mode, 1 = light mode
            DwmSetWindowAttribute(hWnd, DWMWA_USE_IMMERSIVE_DARK_MODE, ref attrValue, sizeof(int));
        }
        [DllImport("dwmapi.dll", CharSet = CharSet.Unicode, SetLastError = true)]

        private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);

        private void button_AddRule_Click(object sender, EventArgs e)
        {
            checkInputs();
            Application.Exit();
        }

        private void checkInputs()
        {
            try
            {
                checkInputsIncludeNumeric();
                checkInputsAreEnum();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void checkInputsIncludeNumeric()
        {
            if (textBox_Sensitivity.Text.Any(char.IsDigit))
            {
                throw new FormatException("Sensitivity not valid.");
            }
            if (textBox_Quantity.Text.Any(char.IsDigit))
            {
                throw new FormatException("Quantity not valid.");
            }
            if (textBox_Pollution.Text.Any(char.IsDigit))
            {
                throw new FormatException("Pollution not valid.");
            }
            if (textBox_Rotation.Text.Any(char.IsDigit))
            {
                throw new FormatException("Rotation not valid.");
            }
            if (textBox_Detergent.Text.Any(char.IsDigit))
            {
                throw new FormatException("Detergent not valid.");
            }
            if (textBox_Duration.Text.Any(char.IsDigit))
            {
                throw new FormatException("Duration not valid.");
            }
        }
        
        private void checkInputsAreEnum()
        {
            if (!Enum.TryParse(textBox_Sensitivity.Text, true, out FuzzyLogicConstant.Sensitivity parsedSensitivity))
            {
                throw new FormatException("Sensitivity not valid.");
            }
            if(!Enum.TryParse(textBox_Quantity.Text, true, out FuzzyLogicConstant.Quantity parsedQuantity))
            {
                throw new FormatException("Quantity not valid.");
            }
            if (!Enum.TryParse(textBox_Pollution.Text, true, out FuzzyLogicConstant.Pollution parsedPollution))
            {
                throw new FormatException("Pollution not valid.");
            }
            if (!Enum.TryParse(textBox_Rotation.Text, true, out FuzzyLogicConstant.Rotation parsedRotation))
            {
                throw new FormatException("Rotation not valid.");
            }
            if (!Enum.TryParse(textBox_Detergent.Text, true, out FuzzyLogicConstant.Detergent parsedDetergent))
            {
                throw new FormatException("Detergent not valid.");
            }
            if (!Enum.TryParse(textBox_Duration.Text, true, out FuzzyLogicConstant.Duration parsedDuration))
            {
                throw new FormatException("Duration not valid.");
            }

            sensitivity = parsedSensitivity.ToString();
            quantity = parsedQuantity.ToString();
            pollution = parsedPollution.ToString();
            rotation = parsedRotation.ToString();
            detergent = parsedDetergent.ToString();
            duration = parsedDuration.ToString();
        }
    }
}
