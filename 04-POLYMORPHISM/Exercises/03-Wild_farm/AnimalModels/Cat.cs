namespace _03_WildFarm.AnimalModels
    {
    public class Cat : Felime
        {
        public string catBreed;

        public Cat(string animalType, string animalName, double animalWeight, string livingRegion, string catBreed)
            : base(animalType, animalName, animalWeight, livingRegion)
            {
            this.CatBreed = catBreed;
            }

        public string CatBreed
            {
            get { return this.catBreed; }
            private set { this.catBreed = value; }
            }


        public override string MakeSound()
            {
            return "Meowwww";
            }

        public override string ToString()
            {
            return $"{base.AnimalType}[{base.AnimalName}, {this.CatBreed}, {base.AnimalWeight}, {this.LivingRegion}, {base.FoodEaten}]";
            }
        }
    }
