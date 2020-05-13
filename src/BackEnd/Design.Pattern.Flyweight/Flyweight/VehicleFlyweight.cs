using Design.Pattern.Flyweight.Model;
using System.Collections.Generic;

namespace Design.Pattern.Flyweight.Flyweight
{
    public class VehicleFlyweight
    {
        public VehicleFlyweight(Dictionary<string, Truck> trucks)
        {
            Trucks = trucks;
        }

        private Dictionary<string, Truck> Trucks { get; set; }

        public Truck GetVehicles(string key)
        {
            if (Trucks.ContainsKey(key))
                return Trucks[key];
            else
            {
                Trucks.Add(key, new Truck());
                return Trucks[key];
            }
        }

        public void GetListTrucks()
        {
            foreach (var item in Trucks.Values)
            {
                item.Show();
            }
        }
    }
}
