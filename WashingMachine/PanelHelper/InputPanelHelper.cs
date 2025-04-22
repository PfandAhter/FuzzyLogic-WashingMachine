using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WashingMachine.Constants;
using WashingMachine.FuzzyLogicEngine;
using WashingMachine.Rules;

namespace WashingMachine.PanelHelper
{
    public class InputPanelHelper
    {
        private Form inputForm;

        private FuzzificationEngine fuzzificationEngine;

        private List<Rule> suitableRules;
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
            DataGridView dataGird = inputForm.Controls.OfType<DataGridView>()
                .FirstOrDefault(c => c.Name.Equals("dataGridView_suitableRules"));

            //Burada ekleme islemini yaparsin koda...

        }

        public void calculate(double sensivity, double quantity, double pollution)
        {
            fuzzificationEngine = new FuzzificationEngine
                (sensivity, quantity, pollution);

            getSuitableRules(fuzzificationEngine.sFuzzy, fuzzificationEngine.qFuzzy, fuzzificationEngine.pFuzzy);

            updateSuitableRulesDataGridView
                (fuzzificationEngine.sFuzzy, fuzzificationEngine.qFuzzy, fuzzificationEngine.pFuzzy);


            fuzzificationEngine.calculateMamdani(suitableRules);

            ListBox listBox = inputForm.Controls.OfType<ListBox>()
                   .FirstOrDefault(c => c.Name.Equals("listBox_test"));

            for (int i =0; i < fuzzificationEngine.mamdaniList.Count(); i++)
            {
                listBox.Items.Add(fuzzificationEngine.mamdaniList[i].ToString());
            }
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


    }
}
