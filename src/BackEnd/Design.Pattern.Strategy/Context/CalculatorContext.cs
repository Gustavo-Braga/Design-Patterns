using Design.Pattern.Strategy.Interfaces;
using System.Collections.Generic;

namespace Design.Pattern.Strategy.Context
{
    public class CalculatorContext
    {
        private IList<IStrategy> _strategies = new List<IStrategy>();

        public CalculatorContext SetStrategy(IStrategy strategy)
        {
            _strategies.Add(strategy);
            return this;
        }

        public IEnumerable<string> Execute()
        {
            var response = new List<string>();
            foreach (var item in _strategies)
                response.Add(item.Execute());

            return response;
        }
    }
}
