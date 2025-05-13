using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WashingMachine.Constants;
using static WashingMachine.Constants.FuzzyLogicConstant;

namespace WashingMachine.Rules
{
    public class Rule
    {
        public int ruleNo { get; private set; } // rule no
        public FuzzyLogicConstant.Sensitivity Sensivity { get; private set; }
        public FuzzyLogicConstant.Quantity Quantity { get; private set; }
        public FuzzyLogicConstant.Pollution Pollution { get; private set; }
        public FuzzyLogicConstant.Rotation Rotation { get; private set; }
        public FuzzyLogicConstant.Detergent Detergent { get; private set; }
        public FuzzyLogicConstant.Duration Duration { get; private set; }
        public List<Rule> rules { get; private set; }

        private List<double> intersectionsList;

        public double [] getIntersections 
        {
            get
            {
                return intersectionsList.ToArray();
            }
        }

        public void setRuleIntersectionList(double sMamdani, double qMamdani, double pMamdani)
        {
            intersectionsList = new List<double>();
            intersectionsList.Add(sMamdani);
            intersectionsList.Add(qMamdani);
            intersectionsList.Add(pMamdani);
        }

        public Rule()
        {
            readFromFile();
        }

        public Rule(FuzzyLogicConstant.Sensitivity sensivity, FuzzyLogicConstant.Quantity quantity, FuzzyLogicConstant.Pollution pollution)
        {
            this.Sensivity = sensivity;
            this.Quantity = quantity;
            this.Pollution = pollution;
        }

        public Rule(int ruleNo,string sensivity, string quantity, string pollution, string duration, string rotation, string detergent) // private olmasi sikinti cikariyor mu kontrol et...
        {
            this.ruleNo = ruleNo;
            getEnumValues(sensivity,quantity,pollution,rotation,detergent,duration);
        }

        private void readFromFile()
        {
            rules = new List<Rule>();
            StreamReader file = new StreamReader(@"rules.txt", Encoding.Default);

            string str;

            for (int i = 0; (str = file.ReadLine()) != null; i++)
            {
                string[] line = str.Split('-');
                Rule rule = new Rule(Convert.ToInt16(line[0]),line[1].ToString(), line[2].ToString(), line[3].ToString(), line[4].ToString(), line[5].ToString(), line[6].ToString());
                rules.Add(rule);
            }
        }

        private void getEnumValues(string sensivity, string quantity, string pollution, string rotation, string detergent, string duration)
        {
            Sensivity = (FuzzyLogicConstant.Sensitivity)Enum.Parse(typeof(FuzzyLogicConstant.Sensitivity), sensivity);
            Quantity = (FuzzyLogicConstant.Quantity)Enum.Parse(typeof(FuzzyLogicConstant.Quantity), quantity);
            Pollution = (FuzzyLogicConstant.Pollution)Enum.Parse(typeof(FuzzyLogicConstant.Pollution), pollution);
            Rotation = (FuzzyLogicConstant.Rotation)Enum.Parse(typeof(FuzzyLogicConstant.Rotation), rotation);
            Detergent = (FuzzyLogicConstant.Detergent)Enum.Parse(typeof(FuzzyLogicConstant.Detergent), detergent);
            Duration = (FuzzyLogicConstant.Duration)Enum.Parse(typeof(FuzzyLogicConstant.Duration), duration);
        }
    }
}
