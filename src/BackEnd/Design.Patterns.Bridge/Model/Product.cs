namespace Design.Patterns.Bridge.Model
{
    public class Product
    {
        public Product(string description)
        {
            Description = description;
        }

        public int Id { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, Descrição: {Description}";
        }
    }
}
