using System;

namespace Design.Pattern.Flyweight.Model
{
    public class Truck
    {
        public string Model { get; set; }
        public int Year { get; set; }
        public decimal Weight { get; set; }
        public decimal Height { get; set; }
        public decimal Width { get; set; }

        public void Show()
        {
            Console.WriteLine($"Caminhão de modelo: {Model}, do ano: {Year}, com altura: {Height}, de largura: {Width} e peso: {Weight}");
        }
    }
}
