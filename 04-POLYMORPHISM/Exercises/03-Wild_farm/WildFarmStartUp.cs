using System;
using _03_WildFarm.AnimalModels;
using _03_WildFarm.FoodModels;

namespace _03_WildFarm
    {
    class WildFarmStartUp
        {
        static void Main(string[] args)
            {
            var inputLine = "";

            while ((inputLine = Console.ReadLine()) != "End")
                {
                Animal animal = null;
                var inputAnimal = inputLine
                    .Split(new[] { '\t', ' ', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                var animalType = inputAnimal[0];
                var animalName = inputAnimal[1];
                var animalWeight = double.Parse(inputAnimal[2]);
                var animalLivingRegion = inputAnimal[3];
                var CatBreed = "";
                if (inputAnimal.Length == 5)
                    {
                    CatBreed = inputAnimal[4];
                    }

                Food food = null;
                var inputFood = Console.ReadLine()
                    .Split(new[] { '\t', ' ', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                var foodType = inputFood[0];
                var foodQty = int.Parse(inputFood[1]);

                if (foodType == "Meat")
                    {
                    food = new Meat(foodQty);
                    }
                else
                    {
                    food = new Vegetable(foodQty);
                    }

                switch (animalType)
                    {
                    case "Mouse":
                        animal = new Mouse(animalType, animalName, animalWeight, animalLivingRegion);
                        break;

                    case "Zebra":
                        animal = new Zebra(animalType, animalName, animalWeight, animalLivingRegion);
                        break;

                    case "Cat":
                        animal = new Cat(animalType, animalName, animalWeight, animalLivingRegion, CatBreed);
                        break;

                    case "Tiger":
                        animal = new Tiger(animalType, animalName, animalWeight, animalLivingRegion);
                        break;

                    default: break;
                    }


                Console.WriteLine(animal.MakeSound());
                try
                    {
                    animal.Eat(food);
                    }
                catch (ArgumentException ae)
                    {
                    Console.WriteLine(ae.Message);
                    }
                Console.WriteLine(animal);

                }



            }
        }
    }
