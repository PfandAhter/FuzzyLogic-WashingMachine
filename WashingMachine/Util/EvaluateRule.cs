using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WashingMachine.Util
{
    public class EvaluateRule
    {
        public static double EvaluateRuleFromMamdani(double sensivityMamdani, double quantityMamdani, double pollutionMamdani)
        {
            return Math.Min(sensivityMamdani, Math.Min(quantityMamdani, pollutionMamdani));
        }
    }
}
