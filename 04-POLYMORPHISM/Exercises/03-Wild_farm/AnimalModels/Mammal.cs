namespace _03_WildFarm.AnimalModels
    {
    public abstract class Mammal : Animal
        {
        private string livingRegion;

        public Mammal(string animalType, string animalName, double animalWeight, string livingRegion)
            : base(animalType, animalName, animalWeight)
            {
            this.LivingRegion = livingRegion;
            }

        public string LivingRegion
            {
            get { return this.livingRegion; }
            private set { this.livingRegion = value; }
            }

        public override string ToString()
            {
            return $"{this.GetType().Name}[{this.AnimalName}, {this.AnimalWeight}, {this.LivingRegion}, {this.FoodEaten}]";
            }
        }
    }
