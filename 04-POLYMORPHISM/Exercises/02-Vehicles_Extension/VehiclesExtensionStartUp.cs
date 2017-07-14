using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_VehiclesExtension
    {
    class VehiclesExtensionStartUp
        {
        static void Main(string[] args)
            {
            var carInfo = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var truckInfo = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var busInfo = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            Vehicles car = new Car(double.Parse(carInfo[1]), double.Parse(carInfo[2]), double.Parse(carInfo[3]));
            Vehicles truck = new Truck(double.Parse(truckInfo[1]), double.Parse(truckInfo[2]), double.Parse(truckInfo[3]));
            Vehicles bus = new Bus(double.Parse(busInfo[1]), double.Parse(busInfo[2]), double.Parse(busInfo[3]));

            var numberOfCommand = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCommand; i++)
                {
                var commands = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var action = commands[0];
                var vehicleType = commands[1];
                var ammount = double.Parse(commands[2]);

                try
                    {
                    switch (vehicleType)
                        {
                        case "Car":
                            if (action == "Drive")
                                {
                                Console.WriteLine(car.TryDrive(ammount));
                                }
                            else
                                {
                                car.Refueling(ammount);
                                }
                            break;

                        case "Truck":
                            if (action == "Drive")
                                {
                                Console.WriteLine(truck.TryDrive(ammount));
                                }
                            else
                                {
                                truck.Refueling(ammount);
                                }
                            break;

                        case "Bus":
                            switch (action)
                                {
                                case "Drive":
                                    Console.WriteLine(bus.TryDrive(ammount));
                                    break;
                                case "DriveEmpty":
                                    Console.WriteLine(bus.TryDrive(ammount, true));
                                    break;
                                case "Refuel":
                                    bus.Refueling(ammount);
                                    break;
                                }
                            break;

                        default: break;
                        }

                    }
                catch (ArgumentException ae)
                    {
                    Console.WriteLine(ae.Message);
                    }

                }

            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
            }
        }
    }
