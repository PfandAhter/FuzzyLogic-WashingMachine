using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WashingMachine.Constants;

namespace WashingMachine.FuzzyLogicEngine
{
    public class MamdaniCalculator
    {
        private double sensivity;
        private double quantity;
        private double pollution;

        public string sensivityFuzzy;
        public string quantityFuzzy;
        public string pollutionFuzzy;

        public static List<string> sFuzzy;
        public static List<string> qFuzzy;
        public static List<string> pFuzzy;
        public double smamdani { get; private set; }
        public double qmamdani { get; private set; }
        public double pmamdani { get; private set; }

        public MamdaniCalculator(double sensivity, double quantity, double pollution)
        {
            this.sensivity = sensivity;
            this.quantity = quantity;
            this.pollution = pollution;
            sFuzzy = new List<string>();
            qFuzzy = new List<string>();
            pFuzzy = new List<string>();
        }

        public double sensivityMamdaniCalculator(string a)//Sensivity Mamdani Calculator
        {
            smamdani = -1;
            if (a == "Durable")
            {
                if (sensivity >= 0 && sensivity <= 2)
                {
                    smamdani = 1;
                }
                else if (sensivity >= 2 && sensivity <= 4)
                {
                    smamdani = 1 - (sensivity - 2) * (1 / Math.Abs((2.0) - (4.0)));
                }
            }

            if (a == "Medium")
            {
                if (sensivity >= 3 && sensivity <= 5)
                {
                    smamdani = (sensivity - 3) * (1 / Math.Abs((3.0) - (5.0)));
                }
                else if (sensivity >= 5 && sensivity <= 7)
                {
                    smamdani = 1 - (sensivity - 5) * (1 / Math.Abs((5.0) - (7.0)));
                }
            }

            if (a == "Sensitive")
            {
                if (sensivity >= 5.5 && sensivity <= 8)
                {
                    smamdani = (sensivity - 5.5) * (1 / Math.Abs((5.5) / (8.0)));
                }
                else if (sensivity >= 8 && sensivity <= 12.5)
                {
                    smamdani = 1;
                }
                else if (sensivity == 12.5 && sensivity <= 14)
                {
                    smamdani = 1 - ((sensivity - 12.5) * (1 / Math.Abs((12.5) - (14.0))));
                }
            }

            return smamdani;
        }
        
        public double quantityMamdaniCalculator(string a)//Quantity Mamdani Calculator
        {
            qmamdani = -1;
            if (a == "Small")
            {
                if (quantity >= 0 && quantity <= 2)
                {
                    qmamdani = 1;
                }
                else if (quantity >= 2 && quantity <= 4)
                {
                    qmamdani = 1 - (quantity - 2) * (1 / Math.Abs((2.0) - (4.0)));
                }
            }

            if (a == "Medium")
            {
                if (quantity >= 3 && quantity <= 5)
                {
                    qmamdani = (quantity - 3) * (1 / Math.Abs((3.0) - (5.0)));
                }
                else if (quantity >= 5 && quantity <= 7)
                {
                    qmamdani = 1 - (quantity - 5) * (1 / Math.Abs((5.0) - (7.0)));
                }
            }

            if (a == "Large")
            {
                if (quantity >= 5.5 && quantity <= 8)
                {
                    qmamdani = (quantity - 5.5) * (1 / Math.Abs((5.5) / (8.0)));
                }
                else if (quantity >= 8 && quantity <= 12.5)
                {
                    qmamdani = 1;
                }
                else if (quantity >= 12.5 && quantity <= 14)
                {
                    qmamdani = 1 - ((quantity - 12.5) * (1 / Math.Abs((12.5) - (14.0))));
                }
            }
            return qmamdani;
        }
        
        public double pollutionMamdaniCalculator(string a)//Pollution Mamdani Calculator
        {
            pmamdani = -1;
            if (a == "Clean")
            {
                if (pollution >= 0 && pollution <= 2)
                {
                    pmamdani = 1;
                }
                else if (pollution >= 2 && pollution <= 4.5)
                {
                    pmamdani = 1 - ((pollution - 2) * (1/ Math.Abs(((2.0) - (4.5)))));
                }
            }
            if (a == "Medium")
            {
                if (pollution >= 3 && pollution <= 5)
                {
                    pmamdani = ((pollution - 3) * (1 / Math.Abs(((3.0) - (5.0)))));
                }
                else if (pollution >= 5 && pollution <= 7)
                {
                    pmamdani = 1 - ((pollution - 5) *( 1/ Math.Abs(((5.0) - (7.0)))));
                }
            }
            if (a == "Dirty")
            {
                if (pollution >= 5.5 && pollution <= 8)
                {
                    pmamdani = (pollution - 5.5) * ( 1/ Math.Abs(((5.5) - (8.0))));
                }
                else if (pollution >= 8 && pollution <= 12.5)
                {
                    pmamdani = 1;
                }
                else if (pollution >= 12.5 && pollution <= 15)
                {
                    pmamdani = 1 - ((pollution - 12.5) * (1 / Math.Abs((12.5) - (15.0))));
                }
            }

            return pmamdani;
        }
    }
}
