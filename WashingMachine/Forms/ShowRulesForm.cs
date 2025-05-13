using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WashingMachine.Rules;

namespace WashingMachine.Forms
{
    public partial class ShowRulesForm : Form
    {
        private List<Rule> suitableRules;

        private static List<Rule> allRules = new List<Rule>();

        private const int DWMWA_USE_IMMERSIVE_DARK_MODE = 20;
        
        public ShowRulesForm(List<WashingMachine.Rules.Rule> suitableRules)
        {
            InitializeComponent();
            this.suitableRules = suitableRules;
            Rule rule = new Rule();
            
            if(!(allRules.Count >= 27))
                allRules = rule.rules;

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterScreen;

            string imagePath = Path.Combine(Application.StartupPath, "WashingMachineIcon.ico");
            this.Icon = new Icon(imagePath);

            IntPtr hWnd = this.Handle;
            int attrValue = 2; // 2 = dark mode, 1 = light mode
            DwmSetWindowAttribute(hWnd, DWMWA_USE_IMMERSIVE_DARK_MODE, ref attrValue, sizeof(int));

            fillDataGridViewWithRules();
        }

        [DllImport("dwmapi.dll", CharSet = CharSet.Unicode, SetLastError = true)]

        private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);

        private void fillDataGridViewWithRules()
        {
            dataGridView2.Rows.Clear();
            
            foreach(Rule rule in allRules)
            {
                dataGridView2.Rows.Add(
                    rule.ruleNo.ToString(),
                    rule.Sensivity.ToString(),
                    rule.Quantity.ToString(),
                    rule.Pollution.ToString(),
                    rule.Duration.ToString(),
                    rule.Rotation.ToString(),
                    rule.Detergent.ToString());
            }

            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                if (row.IsNewRow || row.Cells[0].Value == null)
                    continue;

                string ruleNo = row.Cells[0].Value.ToString();

                foreach (Rule rule in suitableRules)
                {
                    if (ruleNo.Equals(rule.ruleNo.ToString()))
                    {
                        row.DefaultCellStyle.BackColor = Color.Aquamarine;
                        row.DefaultCellStyle.ForeColor = Color.Black;
                        row.DefaultCellStyle.SelectionBackColor = Color.LightGreen;
                        row.DefaultCellStyle.SelectionForeColor = Color.Black;
                    }
                }
            }
        }

        private void button_DeleteSelectedRule_Click(object sender, EventArgs e)
        {
            
            
            allRules.Select(r => r.ruleNo.ToString()).ToList().ForEach(r =>
            {
                if (r.Equals(dataGridView2.CurrentRow.Cells[0].Value.ToString()))
                {
                    allRules.Remove(allRules.FirstOrDefault(rule => rule.ruleNo.ToString().Equals(r)));
                }
            });

            writeActiveRulesToTxt();
            updateRulesFromTxt();
        }

        private void button_AddNewRule_Click(object sender, EventArgs e)
        {
            AddRuleForm addRuleForm = new AddRuleForm();
            addRuleForm.ShowDialog();


            if (addRuleForm.sensitivity != null || 
                addRuleForm.quantity != null || 
                addRuleForm.pollution != null || 
                addRuleForm.duration != null || 
                addRuleForm.rotation != null || 
                addRuleForm.detergent != null)
            {
                allRules.Add(new Rule(allRules.Count + 1, addRuleForm.sensitivity, addRuleForm.quantity, addRuleForm.pollution, addRuleForm.rotation, addRuleForm.detergent, addRuleForm.duration));
                writeActiveRulesToTxt();
                updateRulesFromTxt();
            }
            else
            {
                MessageBox.Show("Please fill all fields.");
            }
        }

        private void writeActiveRulesToTxt()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(@"rules.txt", false, Encoding.Default))
                {
                    foreach (Rule rule in allRules)
                    {
                        writer.WriteLine(rule.ruleNo.ToString() + "-" + rule.Sensivity.ToString() + "-" + rule.Quantity.ToString() + "-" + rule.Pollution.ToString() + "-" + rule.Duration.ToString() + "-" + rule.Rotation.ToString() + "-" + rule.Detergent.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error writing to file: " + ex.Message);
            }

        }
        private void updateRulesFromTxt()
        {
            allRules = new List<Rule>();
            StreamReader reader = new StreamReader(@"rules.txt", Encoding.Default);

            string str;

            for (int i = 0; (str = reader.ReadLine()) != null; i++)
            {
                string[] line = str.Split('-');
                Rule rule = new Rule(Convert.ToInt16(line[0]), line[1].ToString(), line[2].ToString(), line[3].ToString(), line[4].ToString(), line[5].ToString(), line[6].ToString());
                allRules.Add(rule);
            }
        }

        private void button_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button_minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
