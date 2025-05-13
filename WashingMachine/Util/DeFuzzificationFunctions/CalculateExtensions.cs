using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WashingMachine.Util.test
{
    public static class CalculateExtensions
    {
        public static double calculate<T>(this IEnumerable<T> records, ICalculationStrategy<T> strategy)
        {
            return strategy.calculate(records);
        }
    }
}
