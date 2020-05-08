using Design.Patterns.Builder.Interfaces;
using Design.Patterns.Builder.Model;
using System.Collections.Generic;

namespace Design.Patterns.Builder.Builder
{
    public class TruckBuilder
    {
        private Vehicle Vehicle = new Vehicle();

        public TruckBuilder SetModel(string model)
        {
            Vehicle.Model = model;
            return this;
        }

        public TruckBuilder SetYear(int year)
        {
            Vehicle.Year = year;
            return this;
        }

        public TruckBuilder SetColor(string color)
        {
            Vehicle.Color = color;
            return this;
        }

        public TruckBuilder SetAcessories(IEnumerable<string> acessories)
        {
            Vehicle.Acessories = new List<string> { "Geladeira", "Capa para bancos", "Alarme" };
            Vehicle.Acessories = acessories;
            return this;
        }

        public Vehicle GetVehicle()
        {
            return Vehicle;
        }

        public override string ToString()
        {
            return $"Modelo: {Vehicle.Model}, Ano: {Vehicle.Year}, Cor: {Vehicle.Color}, Acessórios: {string.Join(", ", Vehicle.Acessories)}";
        }
    }
}
