﻿using System;
using _03_WildFarm.FoodModels;

namespace _03_WildFarm.AnimalModels
    {
    public class Tiger : Felime
        {
        public Tiger(string animalType, string animalName, double animalWeight, string livingRegion)
            : base(animalType, animalName, animalWeight, livingRegion)
            { }

        public override void Eat(Food food)
            {
            if (!(food.GetType().Name == "Meat"))
                {
                throw new ArgumentException($"{this.GetType().Name}s are not eating that type of food!");
                }
            base.Eat(food);
            }

        public override string MakeSound()
            {
            return "ROAAR!!!";
            }

        }
    }
