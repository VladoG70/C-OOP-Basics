using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Vehicles
    {
    public class Truck : Vehicles
        {
        private const double consumptionIncreasing = 1.6;
        private const double fuelLoss = 0.95;

        public Truck(double fuelQuantity, double fuelConsumption)
            : base(fuelQuantity, fuelConsumption + consumptionIncreasing)
            { }

        public override void Refueling(double refuel)
            {
            base.Refueling(refuel * fuelLoss);
            }
        }
    }
