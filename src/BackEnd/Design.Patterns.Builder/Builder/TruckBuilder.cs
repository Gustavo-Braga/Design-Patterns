using Design.Patterns.Builder.Interfaces;
using Design.Patterns.Builder.Model;
using System.Collections.Generic;

namespace Design.Patterns.Builder.Builder
{
    public class TruckBuilder: IVehicleBuilder
    {
        private Vehicle Vehicle = new Vehicle();

        public void SetModel()
        {
            Vehicle.Model = "FH 460";
        }

        public void SetYear()
        {
            Vehicle.Year = 2004;
        }

        public void SetColor()
        {
            Vehicle.Color = "Cinza";
        }

        public void SetAcessories()
        {
            Vehicle.Acessories = new List<string> { "Geladeira", "Capa para bancos", "Alarme" };
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
