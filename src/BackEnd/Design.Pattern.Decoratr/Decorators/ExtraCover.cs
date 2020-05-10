using Design.Pattern.Decoratr.Interfaces;

namespace Design.Pattern.Decoratr.Decorators
{
    public class ExtraCover : Extra
    {
        public ExtraCover(IOrder order, string label, double price) : base(order, label, price)
        {
        }

        public override double GetPrice()
        {
            return _order.GetPrice() + _price;
        }
    }
}
