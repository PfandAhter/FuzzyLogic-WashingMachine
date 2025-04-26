using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WashingMachine.Util.test
{
    public class WeightedAverageFunction<T> : ICalculationStrategy<T>
    {

        private readonly Func<T, double> valueSelector;
        private readonly Func<T, double> weightSelector;
        public string name => "Weighted Avg.";
        
        public WeightedAverageFunction(Func<T,double> valueSelector, Func<T,double> weightSelector)
        {
            this.valueSelector = valueSelector;
            this.weightSelector = weightSelector;
        }

        public double calculate(IEnumerable<T> records)
        {
            double weightedValueSum = records.Sum(x => valueSelector(x) * weightSelector(x));
            double weightSum = records.Sum(x => valueSelector(x));

            if(weightSum != 0)
                return weightedValueSum / weightSum;

            return 0.0;
        }
    }
}
