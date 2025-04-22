using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WashingMachine.Rules;
using WashingMachine.Util;

namespace WashingMachine.FuzzyLogicEngine
{
    internal class FuzzificationEngine
    {
        public List<string> sFuzzy { get; private set; }
        public List<string> qFuzzy { get; private set; }
        public List<string> pFuzzy { get; private set; }

        private List<string> deFuzzificationSpeed;
        private List<string> deFuzzificationDuration;
        private List<string> deFuzzificationQuantity;

        public string sensivityFuzzy;
        public string quantityFuzzy;
        public string pollutionFuzzy;

        private double sensivity;
        private double quantity;
        private double pollution;

        private List<string> sensivityList = new List<string>();
        private List<string> quantityList = new List<string>();
        private List<string> pollutionList = new List<string>();

        public List<double> mamdaniList { get; private set; }

        private MamdaniCalculator mamdaniCalculator;
        public FuzzificationEngine(double sensivity, double quantity, double pollution)
        {
            this.sensivity = sensivity;
            this.quantity = quantity;
            this.pollution = pollution;

            mamdaniCalculator = new MamdaniCalculator(sensivity,quantity,pollution);
            fuzzification(sensivity, quantity, pollution);
        }

        public void fuzzification(double sens, double quantity, double pollu)
        {
            sFuzzy = new List<string>();
            qFuzzy = new List<string>();
            pFuzzy = new List<string>();

            // Sensivity
            if (sens >= 0 && sens <= 4)
            {
                sensivityFuzzy += "Durable,";
                sFuzzy.Add("Durable");
            }
            if (sens >= 3 && sens <= 7)
            {
                sensivityFuzzy += "Medium,";
                sFuzzy.Add("Medium");
            }
            if (sens >= 5.5 && sens <= 10)
            {
                sensivityFuzzy += "Sensitive,";
                sFuzzy.Add("Sensitive");
            }

            // Quantity
            if (quantity >= 0 && quantity <= 4)
            {
                quantityFuzzy += "Small,";
                qFuzzy.Add("Small");
            }
            if (quantity >= 3 && quantity <= 7)
            {
                quantityFuzzy += "Medium,";
                qFuzzy.Add("Medium");
            }
            if (quantity >= 5.5 && quantity <= 10)
            {
                quantityFuzzy += "Large,";
                qFuzzy.Add("Large");
            }

            // Pollution
            if (pollu >= 0 && pollu <= 4.5)
            {
                pollutionFuzzy += "Clean,";
                pFuzzy.Add("Clean");
            }
            if (pollu >= 3 && pollu <= 7)
            {
                pollutionFuzzy += "Medium,";
                pFuzzy.Add("Medium");
            }
            if (pollu >= 5.5 && pollu <= 10)
            {
                pollutionFuzzy += "Dirty,";
                pFuzzy.Add("Dirty");
            }
        }


        public void calculateMamdani(List<Rule> suitableRules)
        {
            mamdaniList = new List<double>();

            foreach(Rule rule in suitableRules)
            {
                string sMamdani = rule.Sensivity.ToString();
                string qMamdani = rule.Quantity.ToString();
                string pMamdani = rule.Pollution.ToString();

                double minValue = EvaluateRule.EvaluateRuleFromMamdani(
                    mamdaniCalculator.sensivityMamdaniCalculator(sMamdani),
                    mamdaniCalculator.quantityMamdaniCalculator(qMamdani),
                    mamdaniCalculator.pollutionMamdaniCalculator(pMamdani));

                mamdaniList.Add(minValue);
            }
        }

        private List<double> pollutionInterSection(double d)
        {

            return null;
        }
    }
}
