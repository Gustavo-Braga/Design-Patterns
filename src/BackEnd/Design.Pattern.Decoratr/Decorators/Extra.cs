using Design.Pattern.Decorator.Interfaces;

namespace Design.Pattern.Decorator.Decorators
{
    public abstract class Extra : IOrder
    {
        protected readonly IOrder _order;
        protected readonly string _label;
        protected readonly double _price;

        public Extra(IOrder order, string label, double price)
        {
            _order = order;
            _label = label;
            _price = price;
        }

        public abstract double GetPrice();

        public string GetLabel()
        {
            return $"{_order.GetLabel()}, {_label}";
        }
    }
}
