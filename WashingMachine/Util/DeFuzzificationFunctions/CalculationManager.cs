using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WashingMachine.Util.test
{
    public class CalculationManager<T>
    {
        private readonly Dictionary<string, ICalculationStrategy<T>> _strategies = new Dictionary<string, ICalculationStrategy<T>>();

        public void registerStrategy(ICalculationStrategy<T> strategy)
        {
            _strategies[strategy.name] = strategy;
        }

        public ICalculationStrategy<T> getStrategy(string name)
        {
            if (_strategies.TryGetValue(name, out var strategy))
                return strategy;

            throw new KeyNotFoundException($"'{name}' strategy not found!");
        }

        public IEnumerable<string> getAvailableStrategies()
        {
            return _strategies.Keys;
        }

        public double calculate(string strategyName, IEnumerable<T> records)
        {
            return getStrategy(strategyName).calculate(records);
        }
    }
}
