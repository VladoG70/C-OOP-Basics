namespace _03_WildFarm.AnimalModels
    {
    public class Tiger : Felime
        {
        public Tiger(string animalType, string animalName, double animalWeight, string livingRegion)
            : base(animalType, animalName, animalWeight, livingRegion)
            { }


        public override string MakeSound()
            {
            return "ROAAR!!!";
            }

        }
    }
