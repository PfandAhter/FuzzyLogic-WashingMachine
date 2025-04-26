using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WashingMachine.Util.test
{
    public interface ICalculationStrategy<T>
    {
        string name { get; }
        double calculate(IEnumerable<T> records);
    }
}
