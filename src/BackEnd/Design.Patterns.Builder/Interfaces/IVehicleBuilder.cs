using System.Collections.Generic;

namespace Design.Patterns.Builder.Interfaces
{
    public interface IVehicleBuilder
    {
        void SetModel();
        void SetYear();
        void SetColor();
        void SetAcessories();
    }
}
