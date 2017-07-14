using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Vehicles
    {
    public class Car : Vehicles
        {
        private const double consumptionIncreasing = 0.9;

        public Car(double fuelQuantity, double fuelConsumption)
                : base(fuelQuantity, fuelConsumption + consumptionIncreasing)
            { }

        }
    }
