using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using WashingMachine.Constants;
using WashingMachine.FuzzyLogicEngine;
using WashingMachine.Rules;

namespace WashingMachine.PanelHelper
{
    public class InputPanelHelper
    {
        public Form inputForm;

        private FuzzificationEngine fuzzificationEngine;

        private DeFuzzificationEngine deFuzzificationEngine;

        public List<Rule> suitableRules;
        public List<string> deFuzzificationRotation { get; private set; }
        public List<string> deFuzzificationDetergent { get; private set; }
        public List<string> deFuzzificationDuration { get; private set; }

        private Rule rule;

        public InputPanelHelper(Form inputForm)
        {
            this.inputForm = inputForm;
            this.rule = new Rule();
        }
        public void updateSuitableRulesDataGridView(List<string> sFuzzy, List<string> qFuzzy, List<string> pFuzzy)
        {
            DataGridView dataGridView = 
                inputForm.Controls.OfType<GroupBox>()
                .FirstOrDefault(c => c.Name.Equals("groupBox_SuitableRules"))
                .Controls.OfType<DataGridView>().FirstOrDefault();

            dataGridView.DefaultCellStyle.Font = new Font("Times New Roman", 16, FontStyle.Italic);
            dataGridView.Rows.Clear();

            foreach (Rule rule in suitableRules)
            {
                dataGridView.Rows.Add(
                    rule.ruleNo.ToString(),
                    rule.Sensivity.ToString(),
                    rule.Quantity.ToString(),
                    rule.Pollution.ToString(),
                    rule.Duration.ToString(),
                    rule.Rotation.ToString(),
                    rule.Detergent.ToString());
            }
        }

        public void calculate(double sensivity, double quantity, double pollution)
        {
            fuzzificationEngine = new FuzzificationEngine
                (sensivity, quantity, pollution);

            getSuitableRules(fuzzificationEngine.sFuzzy, fuzzificationEngine.qFuzzy, fuzzificationEngine.pFuzzy);

            updateSuitableRulesDataGridView
                (fuzzificationEngine.sFuzzy, fuzzificationEngine.qFuzzy, fuzzificationEngine.pFuzzy);
            fuzzificationEngine.calculateMamdani(suitableRules);
            updatePanelSources();

            deFuzzificationEngine = new DeFuzzificationEngine(this);

            setLabelsText();

        }

        private void getSuitableRules(List<string> sFuzzy, List<string> qFuzzy, List<string> pFuzzy)
        {
            deFuzzificationDetergent = new List<string>();
            deFuzzificationDuration = new List<string>();
            deFuzzificationRotation = new List<string>();
            suitableRules = new List<Rule>();

            for (int i = 0; i < rule.rules.Count(); i++)
            {
                FuzzyLogicConstant.Sensitivity sensivityRule = rule.rules[i].Sensivity;
                FuzzyLogicConstant.Quantity quantityRule = rule.rules[i].Quantity;
                FuzzyLogicConstant.Pollution pollutionRule = rule.rules[i].Pollution;

                if(sFuzzy.Contains(sensivityRule.ToString()) &&
                    qFuzzy.Contains(quantityRule.ToString()) &&
                    pFuzzy.Contains(pollutionRule.ToString()))
                {
                    deFuzzificationDetergent.Add(rule.rules[i].Detergent.ToString());
                    deFuzzificationDuration.Add(rule.rules[i].Duration.ToString());
                    deFuzzificationRotation.Add(rule.rules[i].Rotation.ToString());

                    suitableRules.Add(rule.rules[i]);
                }
            }
        }

        private void setLabelsText()
        {
            Label labelRotationWeightedAvgValue = inputForm.Controls.OfType<GroupBox>()
                .FirstOrDefault(c => c.Name.Equals("groupBox_DeFuzzificationResults"))
                .Controls.OfType<GroupBox>().FirstOrDefault(c => c.Name.Equals("groupBox_RotationResult"))
                .Controls.OfType<Label>().FirstOrDefault(l => l.Name.Equals("label_RotationWeightedAvgValue"));
            Label labelDetergentWeightedAvgValue = inputForm.Controls.OfType<GroupBox>()
                .FirstOrDefault(c => c.Name.Equals("groupBox_DeFuzzificationResults"))
                .Controls.OfType<GroupBox>().FirstOrDefault(c => c.Name.Equals("groupBox_DetergentResult"))
                .Controls.OfType<Label>().FirstOrDefault(l => l.Name.Equals("label_DetergentWeightedAvgValue"));
            Label labelDurationWeightedAvgValue = inputForm.Controls.OfType<GroupBox>()
                .FirstOrDefault(c => c.Name.Equals("groupBox_DeFuzzificationResults"))
                .Controls.OfType<GroupBox>().FirstOrDefault(c => c.Name.Equals("groupBox_DurationResult"))
                .Controls.OfType<Label>().FirstOrDefault(l => l.Name.Equals("label_DurationWeightedAvgValue"));

            Label labelRotationCentroidValue = inputForm.Controls.OfType<GroupBox>()
                .FirstOrDefault(c => c.Name.Equals("groupBox_DeFuzzificationResults"))
                .Controls.OfType<GroupBox>().FirstOrDefault(c => c.Name.Equals("groupBox_RotationResult"))
                .Controls.OfType<Label>().FirstOrDefault(l => l.Name.Equals("label_RotationCentroidValue"));
            Label labelDetergentCentroidValue = inputForm.Controls.OfType<GroupBox>()
                .FirstOrDefault(c => c.Name.Equals("groupBox_DeFuzzificationResults"))
                .Controls.OfType<GroupBox>().FirstOrDefault(c => c.Name.Equals("groupBox_DetergentResult"))
                .Controls.OfType<Label>().FirstOrDefault(l => l.Name.Equals("label_DetergentCentroidValue"));
            Label labelDurationCentroidValue = inputForm.Controls.OfType<GroupBox>()
                .FirstOrDefault(c => c.Name.Equals("groupBox_DeFuzzificationResults"))
                .Controls.OfType<GroupBox>().FirstOrDefault(c => c.Name.Equals("groupBox_DurationResult"))
                .Controls.OfType<Label>().FirstOrDefault(l => l.Name.Equals("label_DurationCentroidValue"));

            labelRotationWeightedAvgValue.Text = deFuzzificationEngine.labelRotationWeightedAvgText;
            labelDetergentWeightedAvgValue.Text = deFuzzificationEngine.labelDetergentWeightedAvgText;
            labelDurationWeightedAvgValue.Text = deFuzzificationEngine.labelDurationWeightedAvgText;

            labelRotationCentroidValue.Text = deFuzzificationEngine.labelRotationCentroidText;
            labelDetergentCentroidValue.Text = deFuzzificationEngine.labelDetergentCentroidText;
            labelDurationCentroidValue.Text = deFuzzificationEngine.labelDurationCentroidText;
        }

        private void updatePanelSources()
        {
            ListBox listBox = inputForm
                .Controls.OfType<GroupBox>().FirstOrDefault(c => c.Name.Equals("groupBox_Mamdani"))
                .Controls.OfType<ListBox>().FirstOrDefault(l => l.Name.Equals("listBox_Mamdani"));

            List<Label> labelList = inputForm
                .Controls.OfType<GroupBox>().FirstOrDefault(c => c.Name.Equals("groupBox_FuzzificatedInputValues"))
                .Controls.OfType<Label>().ToList();

            listBox.Items.Clear();
            for (int i = 0; i < fuzzificationEngine.mamdaniList.Count(); i++)
            {
                listBox.Items.Add(fuzzificationEngine.mamdaniList[i].ToString());
            }

            labelList[2].Text = fuzzificationEngine.sensivityFuzzy;
            labelList[1].Text = fuzzificationEngine.quantityFuzzy;
            labelList[0].Text = fuzzificationEngine.pollutionFuzzy;
        }

        public void updatePanelSources(Chart activeChart)
        {
            string linestr = "";

            if(activeChart == null)
            {
                //Baslangicta ekrandaki bilgilerle bir hesaplama yapmasi icin.
                string chart1Line = fuzzificationEngine.sMamdaniList.Min().ToString();
                string chart2Line = fuzzificationEngine.qMamdaniList.Min().ToString();
                string chart3Line = fuzzificationEngine.pMamdaniList.Min().ToString();

                Chart chart1 = inputForm.Controls.OfType<GroupBox>()
                    .FirstOrDefault(c => c.Name.Equals("groupBox_InputValues"))
                    .Controls.OfType<Chart>()
                    .FirstOrDefault(chart => chart.Name.Equals("chart1"));

                Chart chart2 = inputForm.Controls.OfType<GroupBox>()
                    .FirstOrDefault(c => c.Name.Equals("groupBox_InputValues"))
                    .Controls.OfType<Chart>()
                    .FirstOrDefault(chart => chart.Name.Equals("chart2"));

                Chart chart3 = inputForm.Controls.OfType<GroupBox>()
                    .FirstOrDefault(c => c.Name.Equals("groupBox_InputValues"))
                    .Controls.OfType<Chart>()
                    .FirstOrDefault(chart => chart.Name.Equals("chart3"));

                chart1.Series[3].Points[0].Label = chart1Line.Length > 5 ? chart1Line.Substring(0, 5) : chart1Line;
                chart2.Series[3].Points[0].Label = chart2Line.Length > 5 ? chart2Line.Substring(0, 5) : chart2Line;
                chart3.Series[3].Points[0].Label = chart3Line.Length > 5 ? chart3Line.Substring(0, 5) : chart3Line;
                
                return;
            }

            if (activeChart.Tag.Equals("sensivity"))
            {
                linestr = fuzzificationEngine.sMamdaniList.Min().ToString();
            }
            else if (activeChart.Tag.Equals("quantity"))
            {
                linestr = fuzzificationEngine.qMamdaniList.Min().ToString();
            }
            else
            {
                linestr = fuzzificationEngine.pMamdaniList.Min().ToString();
            }

            activeChart.Series[3].Points[0].Label = linestr.Length > 5 ? linestr.Substring(0, 5) : linestr;
        }
    }
}
