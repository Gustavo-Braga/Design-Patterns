using Design.Pattern.Decoratr.Interfaces;

namespace Design.Pattern.Decoratr.Model
{
    public class Pizza : IOrder
    {
        public Pizza(string label, double price)
        {
            Label = label;
            Price = price;
        }

        public string Label { get; set; }
        public double Price { get; set; }
        public double GetPrice()
        {
            return Price;
        }

        public string GetLabel()
        {
            return Label;
        }
    }
}
