using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WashingMachine.Util.DeFuzzificationFunctions
{
    public class CentroidFunction : IDeFuzzificationFunction
    {
        public double DeFuzzify(List<double> fuzzySet, List<double> membershipValues)
        {
            double numerator = 0;
            double denominator = 0;
            for (int i = 0; i < fuzzySet.Count; i++)
            {
                numerator += fuzzySet[i] * membershipValues[i];
                denominator += membershipValues[i];
            }
            return numerator / denominator;
        }
    }
}
