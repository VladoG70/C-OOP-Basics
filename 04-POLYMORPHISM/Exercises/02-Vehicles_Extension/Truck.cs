namespace _02_VehiclesExtension
    {
    public class Truck : Vehicles
        {
        private const double consumptionIncreasing = 1.6;
        private const double fuelLoss = 0.95;

        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption + consumptionIncreasing, tankCapacity)
            { }

        public override void Refueling(double refuel)
            {
            base.Refueling(refuel * fuelLoss);
            }
        }
    }
