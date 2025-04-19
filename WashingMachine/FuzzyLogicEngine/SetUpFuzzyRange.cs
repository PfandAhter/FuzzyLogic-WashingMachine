using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WashingMachine.FuzzyLogicEngine
{
    public class SetUpFuzzyRange
    {
        private double sensivity;
        private double quantity;
        private double pollution;

        public static List<string> sFuzzy;
        public static List<string> qFuzzy;
        public static List<string> pFuzzy;
        public double smamdani { get; private set; }
        public double qmamdani { get; private set; }
        public double pmamdani { get; private set; }

        public SetUpFuzzyRange(double sensivity, double quantity, double pollution)
        {
            this.sensivity = sensivity;
            this.quantity = quantity;
            this.pollution = pollution;
            sFuzzy = new List<string>();
            qFuzzy = new List<string>();
            pFuzzy = new List<string>();
            fuzzification(sensivity, quantity, pollution);
        }

        public void fuzzification(double sens, double quantity, double pollu)
        {
            // Sensivity
            if (sens >= 0 && sens <= 4)
            {
                sFuzzy.Add("Durable");
            }
            if (sens >= 3 && sens <= 7)
            {
                sFuzzy.Add("Medium");
            }
            if (sens >= 5.5 && sens <= 10)
            {
                sFuzzy.Add("Sensitive");
            }

            // Quantity
            if (quantity >= 0 && quantity <= 4)
            {
                qFuzzy.Add("Small");
            }
            if (quantity >= 3 && quantity <= 7)
            {
                qFuzzy.Add("Medium");
            }
            if (quantity >= 5.5 && quantity <= 10)
            {
                qFuzzy.Add("Large");
            }

            // Pollution
            if (pollu >= 0 && pollu <= 4.5)
            {
                pFuzzy.Add("Clean");
            }
            if (pollu >= 3 && pollu <= 7)
            {
                pFuzzy.Add("Medium");
            }
            if (pollu >= 5.5 && pollu <= 10)
            {
                pFuzzy.Add("Dirty");
            }
        }

        public void sensivityMandaniCalculator(string a)//Hassaslık Mandani Hesaplama
        {
            if (a == "Durable")
            {
                if (sensivity >= 0 && sensivity <= 2)
                {
                    smamdani = 1;
                }
                else if (sensivity > 2 && sensivity < 4)
                {
                    smamdani = ((sensivity - 2) / (2 - 4)) + 1;
                }
                else if (sensivity == 4)
                {
                    smamdani = 0;
                }

            }
            if (a == "Medium")
            {
                if (sensivity > 3 && sensivity < 5)
                {
                    smamdani = ((sensivity - 3) / (5 - 3));
                }
                else if (sensivity > 5 && sensivity < 7)
                {
                    smamdani = ((sensivity - 5) / (5 - 7)) + 1;
                }
                else if (sensivity == 3 || sensivity == 7)
                {
                    smamdani = 0;
                }
                else if (sensivity == 5)
                {
                    smamdani = 1;
                }
            }
            if (a == "Sensitive")
            {
                if (sensivity > 5.5 && sensivity < 8)
                {
                    smamdani = ((sensivity - 5.5) / (8 - 5.5));

                }
                else if (sensivity >= 8 && sensivity <= 10)
                {
                    smamdani = 1;
                }
                else if (sensivity == 5.5)
                {
                    smamdani = 0;
                }
            }
        }

        public void quantityMandaniCalculator(string a)//Miktar Mandani Hesaplma
        {
            if (a == "Small")
            {
                if (quantity >= 0 && quantity <= 2)
                {
                    qmamdani = 1;
                }
                else if (quantity > 2 && quantity < 4)
                {
                    qmamdani = ((quantity - 2) / (2 - 4)) + 1;
                }
                else if (quantity == 4)
                {
                    qmamdani = 0;
                }

            }
            if (a == "Medium")
            {
                if (quantity > 3 && quantity < 5)
                {
                    qmamdani = ((quantity - 3) / (5 - 3));
                }
                else if (quantity > 5 && quantity < 7)
                {
                    qmamdani = ((quantity - 5) / (5 - 7)) + 1;
                }
                else if (quantity == 3 || quantity == 7)
                {
                    qmamdani = 0;
                }
                else if (quantity == 5)
                {
                    qmamdani = 1;
                }

            }
            if (a == "Large")
            {
                if (quantity > 5.5 && quantity < 8)
                {
                    qmamdani = ((quantity - 5.5) / (8 - 5.5));

                }
                else if (quantity >= 8 && quantity <= 10)
                {
                    qmamdani = 1;
                }
                else if (quantity == 5.5)
                {
                    qmamdani = 0;
                }
            }
        }
        //https://github.com/Safakglz/C-SHARP-YAPAY-ZEKA-BULANIK-MANTIK-ALGORITMASI/tree/main

        //https://github.com/EsraAlhaddad/Bulanik-mantik/tree/main
        public void pollutionMandaniCalculator(string a)//Kirlilik Mandani Hesaplama
        {
            if (a == "Clean")
            {
                if (pollution >= 0 && pollution <= 2)
                {
                    pmamdani = 1;
                }
                else if (pollution > 2 && pollution < 4.5)
                {
                    pmamdani = ((pollution - 2) / (2 - 4.5)) + 1;
                }
                else if (pollution == 4.5)
                {
                    pmamdani = 0;
                }
            }
            if (a == "Medium")
            {
                if (pollution > 3 && pollution < 5)
                {
                    pmamdani = ((pollution - 3) / (5 - 3));
                }
                else if (pollution > 5 && pollution < 7)
                {
                    pmamdani = ((pollution - 5) / (5 - 7)) + 1;
                }
                else if (pollution == 3 || pollution == 7)
                {
                    pmamdani = 0;
                }
                else if (pollution == 5)
                {
                    pmamdani = 1;
                }

            }
            if (a == "Dirty")
            {
                if (pollution > 5.5 && pollution < 8)
                {
                    pmamdani = ((pollution - 5.5) / (8 - 5.5));

                }
                else if (pollution >= 8 && pollution <= 10)
                {
                    pmamdani = 1;
                }
                else if (pollution == 5.5)
                {
                    pmamdani = 0;
                }
            }
        }

        public double sensivityMandani(string sensivity)
        {
            double sensivityValue = 0;
         
            
            return sensivityValue;
        }

            /*public double calculateRotation(double sensivity, double quantity, double pollution)
            {
                double rotation = 0;
                if (sensivity == 0 && quantity == 0 && pollution == 0)
                {
                    rotation = 0;
                }
                else if (sensivity == 1 && quantity == 1 && pollution == 1)
                {
                    rotation = 1;
                }
                else
                {
                    rotation = (sensivity + quantity + pollution) / 3;
                }
                return rotation;
            }
            public double calculateDetergent(double sensivity, double quantity, double pollution)
            {
                double detergent = 0;
                if (sensivity == 0 && quantity == 0 && pollution == 0)
                {
                    detergent = 0;
                }
                else if (sensivity == 1 && quantity == 1 && pollution == 1)
                {
                    detergent = 1;
                }
                else
                {
                    detergent = (sensivity + quantity + pollution) / 3;
                }
                return detergent;
            }
            public double calculateDuration(double sensivity, double quantity, double pollution)
            {
                double duration = 0;
                if (sensivity == 0 && quantity == 0 && pollution == 0)
                {
                    duration = 0;
                }
                else if (sensivity == 1 && quantity == 1 && pollution == 1)
                {
                    duration = 1;
                }
                else
                {
                    duration = (sensivity + quantity + pollution) / 3;
                }
                return duration;
            }*/
        }
}
