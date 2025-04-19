using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WashingMachine.FuzzyLogicEngine
{
    internal class FuzzificationEngine
    {

        private List<string> sFuzzy;
        private List<string> qFuzzy;
        private List<string> pFuzzy;

        private List<string> deFuzzificationSpeed;
        private List<string> deFuzzificationDuration;
        private List<string> deFuzzificationQuantity;

        private string senss;
        private string quantt;
        private string pollu;

        private double sensivity;
        private double quantity;
        private double pollution;

        private List<string> sensivityList = new List<string>();
        private List<string> quantityList = new List<string>();
        private List<string> pollutionList = new List<string>();


        /*public List<string> SFuzzy { get => sFuzzy; set => sFuzzy = value;}
        public List<string> QFuzzy { get => qFuzzy; set => qFuzzy = value; }
        public List<string> PFuzzy { get => pFuzzy; set => pFuzzy = value; }*/

        /*public List<string> DeFuzzificationSpeed { get => deFuzzificationSpeed; set => deFuzzificationSpeed = value;}
        public List<string> DeFuzzificationDuration { get => deFuzzificationDuration; set => deFuzzificationDuration = value;}
        public List<string> DeFuzzificationQuantity { get => deFuzzificationQuantity; set => deFuzzificationQuantity = value;}*/

        public FuzzificationEngine(double sensivity, double quantity, double pollution)
        {
            this.sensivity = sensivity;
            this.quantity = quantity;
            this.pollution = pollution;
        }

        public void Fuzzification(double sens, double quantity, double pollu)
        {
            sFuzzy = new List<string>();
            qFuzzy = new List<string>();
            pFuzzy = new List<string>();

            // Sensivity
            if (sens >= 0 && sens<= 4)
            {
                sFuzzy.Add("Durable");
            }
            if (sens >= 3 && sens <= 7)
            {
                sFuzzy.Add("Medium");
            }
            if(sens >= 5.5 && sens <= 10)
            {
                sFuzzy.Add("Sensitive");
            }

            // Quantity
            if (quantity>= 0 && quantity <= 4)
            {
                qFuzzy.Add("Small");
            }
            if (quantity >= 3 && quantity <= 7)
            {
                qFuzzy.Add("Medium");
            }
            if(quantity >= 5.5 && quantity <= 10)
            {
                qFuzzy.Add("Large");
            }

            // Pollution
            if (pollu >=0 && pollu <= 4.5)
            {
                pFuzzy.Add("Clean");
            }
            if (pollu >= 3 && pollu <= 7)
            {
                pFuzzy.Add("Medium");
            }
            if(pollu >= 5.5 && pollu <= 10)
            {
                pFuzzy.Add("Dirty");
            }
        }


        private List<double> pollutionInterSection(double d)
        {

            return null;
        }
    }
}
