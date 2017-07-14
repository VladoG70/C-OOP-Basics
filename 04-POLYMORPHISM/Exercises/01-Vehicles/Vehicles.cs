using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Vehicles
    {
    public abstract class Vehicles
        {
        private double fuelQuantity;
        private double fuelConsumption;

        public Vehicles(double fuelQuantity, double fuelConsumption)
            {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
            }

        public double FuelQuantity
            {
            get { return this.fuelQuantity; }
            private set
                {
                this.fuelQuantity = value;
                }
            }

        public double FuelConsumption
            {
            get { return this.fuelConsumption; }
            private set
                {
                this.fuelConsumption = value;
                }
            }

        public string TryDrive(double distance)
            {
            var neededFuel = distance * this.fuelConsumption;
            if (neededFuel > this.fuelQuantity)
                {
                return $"{this.GetType().Name} needs refueling";
                }

            this.FuelQuantity -= neededFuel;
            return $"{this.GetType().Name} travelled {distance} km";
            }


        public virtual void Refueling(double refuel)
            {
            this.FuelQuantity += refuel;
            }

        public override string ToString()
            {
            return $"{this.GetType().Name}: {this.FuelQuantity:F2}";
            }
        }
    }
