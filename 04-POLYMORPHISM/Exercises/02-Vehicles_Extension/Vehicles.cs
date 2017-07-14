using System;

namespace _02_VehiclesExtension
    {
    public abstract class Vehicles
        {
        private double fuelQuantity;
        private double fuelConsumption;
        private double tankCapacity;

        public Vehicles(double fuelQuantity, double fuelConsumption, double tankCapacity)
            {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
            this.TankCapacity = tankCapacity;
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

        public double TankCapacity
            {
            get { return this.tankCapacity; }
            private set
                {
                this.tankCapacity = value;
                }
            }

        public virtual string TryDrive(double distance)
            {
            var neededFuel = distance * this.fuelConsumption;
            if (neededFuel > this.fuelQuantity)
                {
                return $"{this.GetType().Name} needs refueling";
                }

            this.FuelQuantity -= neededFuel;
            return $"{this.GetType().Name} travelled {distance} km";
            }

        public virtual string TryDrive(double distance, bool empty)
        {
            double decreaseConsumption = 1.4;
            var neededFuel = distance * (this.fuelConsumption - decreaseConsumption);
            if (neededFuel > this.fuelQuantity)
                {
                return $"{this.GetType().Name} needs refueling";
                }

            this.FuelQuantity -= neededFuel;
            return $"{this.GetType().Name} travelled {distance} km";
            }


        public virtual void Refueling(double refuel)
            {
            if (refuel <= 0)
                {
                throw new ArgumentException("Fuel must be a positive number");
                }

            if ((refuel + this.fuelQuantity) > this.tankCapacity && !(this.GetType().Name == "Truck"))
                {
                throw new ArgumentException("Cannot fit fuel in tank");
                }

            this.FuelQuantity += refuel;
            }

        public override string ToString()
            {
            return $"{this.GetType().Name}: {this.FuelQuantity:F2}";
            }
        }
    }
