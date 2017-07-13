using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_Animals
    {
    class AnimalsStartUp
        {
        static void Main(string[] args)
            {
            var input = "";
            List<Animal> animals = new List<Animal>();

            while ((input = Console.ReadLine()) != "Beast!")
                {
                var animalInfo = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var name = animalInfo[0];
                var age = int.Parse(animalInfo[1]);
                var gender = animalInfo[2];

                try
                    {
                    switch (input)
                        {
                        case "Dog":
                            Animal dog = new Dog(name, age, gender);
                            animals.Add(dog);
                            break;

                        case "Cat":
                            Animal cat = new Cat(name, age, gender);
                            animals.Add(cat);
                            break;

                        case "Frog":
                            Animal frog = new Frog(name, age, gender);
                            animals.Add(frog);
                            break;

                        case "Kitten":
                            Animal kitten = new Kitten(name, age, gender);
                            animals.Add(kitten);
                            break;

                        case "Tomcat":
                            Animal tomcat = new Tomcat(name, age, gender);
                            animals.Add(tomcat);
                            break;

                        default: break;
                        }

                    //foreach (var animal in animals)
                    //    {
                    //    Console.WriteLine(animal.GetType().Name);
                    //    Console.WriteLine($"{animal.Name} {animal.Age} {animal.Gender}");
                    //    animal.ProduceSound();
                    //    }

                    }
                catch (Exception ex)
                    {
                    Console.WriteLine(ex.Message);
                    }
                }

                foreach (var animal in animals)
                {
                    Console.WriteLine(animal.GetType().Name);
                    Console.WriteLine($"{animal.Name} {animal.Age} {animal.Gender}");
                    animal.ProduceSound();
                }
            }
        }
    }
