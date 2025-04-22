using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WashingMachine.Util.DeFuzzificationFunctions
{
    public interface IDeFuzzificationFunction
    {
        double DeFuzzify(List<double> fuzzySet, List<double> membershipValues);
    }
}