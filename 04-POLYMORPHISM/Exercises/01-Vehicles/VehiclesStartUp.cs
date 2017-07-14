using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Vehicles
    {
    class VehiclesStartUp
        {
        static void Main(string[] args)
            {
            var carInfo = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var truckInfo = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            Vehicles car = new Car(double.Parse(carInfo[1]), double.Parse(carInfo[2]));
            Vehicles truck = new Truck(double.Parse(truckInfo[1]), double.Parse(truckInfo[2]));

            var numberOfCommand = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCommand; i++)
                {
                var commands = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var action = commands[0];
                var vehicleType = commands[1];
                var ammount = double.Parse(commands[2]);

                switch (action)
                    {
                    case "Drive":
                        if (vehicleType == "Car")
                            {
                            Console.WriteLine(car.TryDrive(ammount));
                            }
                        else
                            {
                            Console.WriteLine(truck.TryDrive(ammount));
                            }
                        break;

                    case "Refuel":
                        if (vehicleType == "Car")
                            {
                            car.Refueling(ammount);
                            }
                        else
                            {
                            truck.Refueling(ammount);
                            }
                        break;

                    default: break;
                    }

                }

            Console.WriteLine(car);
            Console.WriteLine(truck);
            }
        }
    }
