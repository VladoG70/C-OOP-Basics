﻿using System;
using _03_WildFarm.FoodModels;

namespace _03_WildFarm.AnimalModels
    {
    public abstract class Animal
        {
        private string animalType;
        private string animalName;
        private double animalWeight;
        private int foodEaten = 0;

        public Animal(string animalType, string animalName, double animalWeight)
            {
            this.AnimalType = animalType;
            this.AnimalName = animalName;
            this.AnimalWeight = animalWeight;                            
            }

        public string AnimalType
            {
            get { return this.animalType; }
            private set
                {
                this.animalType = value;
                }
            }

        public string AnimalName
            {
            get { return this.animalName; }
            private set { this.animalName = value; }
            }

        public double AnimalWeight
            {
            get { return this.animalWeight; }
            private set { this.animalWeight = value; }
            }

        public int FoodEaten
            {
            get { return this.foodEaten; }
            private set { this.foodEaten += value; }
            }

        public void Eat(Food food)
            {
            switch (this.GetType().Name)
                {
                case "Cat":
                    this.FoodEaten = food.Quantity;
                    break;
                case "Tiger":
                    if (!(food.GetType().Name == "Meat"))
                        {
                        throw new ArgumentException($"{this.GetType().Name}s are not eating that type of food!");
                        }
                    this.FoodEaten = food.Quantity;
                    break;
                case "Mouse":
                    if (!(food.GetType().Name == "Vegetable"))
                        {
                        throw new ArgumentException($"{this.GetType().Name}s are not eating that type of food!");
                        }
                    this.FoodEaten = food.Quantity;
                    break;
                case "Zebra":
                    if (!(food.GetType().Name == "Vegetable"))
                        {
                        throw new ArgumentException($"{this.GetType().Name}s are not eating that type of food!");
                        }
                    this.FoodEaten = food.Quantity;
                    break;
                }
            }

        public abstract string MakeSound();

        }
    }
