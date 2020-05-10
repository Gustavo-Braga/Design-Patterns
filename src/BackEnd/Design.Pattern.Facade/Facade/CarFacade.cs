using Design.Pattern.Facade.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Design.Pattern.Facade.Facade
{
    public class CarFacade
    {
        public CarModel CarModel { get; set; }
        public CarBody CarBody { get; set; }
        public CarAcessories CarAcessories { get; set; }

        public CarFacade()
        {
            CarModel = new CarModel();
            CarBody = new CarBody();
            CarAcessories = new CarAcessories();
        }

        public void CreateCompleteCar()
        {
            CarModel.SetModel();
            CarBody.SetBody();
            CarAcessories.SetAcessories();
        }


    }
}
