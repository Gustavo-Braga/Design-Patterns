namespace Design.Patterns.Bridge.Model
{
    public class Client
    {
        public Client(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, Nome: {Name}, Idade: {Age}";
        }

    }
}
