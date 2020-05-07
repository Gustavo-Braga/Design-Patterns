using Design.Patterns.Builder.Interfaces;

namespace Design.Patterns.Builder.Builder
{
    public class VehicleCreator 
    {
        private readonly IVehicleBuilder vehicleBuilder;

        public VehicleCreator(IVehicleBuilder vehicleBuilder)
        {
            this.vehicleBuilder = vehicleBuilder;
        }

        public void CreateVehicleCaracteristics()
        {
            vehicleBuilder.SetModel();
            vehicleBuilder.SetYear();
            vehicleBuilder.SetColor();
        }

        public void CreateVehicleAcessories()
        {
            vehicleBuilder.SetAcessories();
        }
    }
}
