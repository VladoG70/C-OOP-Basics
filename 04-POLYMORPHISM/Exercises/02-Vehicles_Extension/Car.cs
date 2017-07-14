namespace _02_VehiclesExtension
    {
    public class Car : Vehicles
        {
        private const double consumptionIncreasing = 0.9;

        public Car(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption + consumptionIncreasing, tankCapacity)
            { }

        }
    }
