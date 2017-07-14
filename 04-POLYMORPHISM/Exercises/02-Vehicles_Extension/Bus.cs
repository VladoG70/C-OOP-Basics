namespace _02_VehiclesExtension
    {
    public class Bus : Vehicles
        {
        private const double consumptionIncreasing = 1.4;

        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption + consumptionIncreasing, tankCapacity)
            { }

        }
    }
