using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace VehicleCatalogue_DifferentSolution
{
    class Program
    {
        class Car
        {
            public string Brand { get; set; }
            public string Model { get; set; }
            public int HorsePower { get; set; }
        }
        class Truck
        {
            public string Brand { get; set; }
            public string Model { get; set; }
            public int Weight { get; set; }
        }

        class Catalog
        {
            public List<Car> Cars { get; set; }
            public List<Truck> Trucks { get; set; }
        }

        static void Main(string[] args)
        {
            List<Car> vehicle = new List<Car>();
            List<Truck> trucks = new List<Truck>();
            while (true)
            {
                string inputLine = Console.ReadLine();
                if (inputLine == "end")
                {
                    break;
                }
                string[] input = inputLine.Split('/');

                string type = input[0];
                if (type == "Car")
                {
                    string brand = input[1];
                    string model = input[2];
                    int horsePower = int.Parse(input[3]);

                    Car newCar = new Car();

                    newCar.Brand = brand;
                    newCar.Model = model;
                    newCar.HorsePower = horsePower;

                    vehicle.Add(newCar);

                    
                }
                else if (type == "Truck")
                {
                    string brand = input[1];
                    string model = input[2];
                    int weight = int.Parse(input[3]);

                    Truck newTruck = new Truck();

                    newTruck.Brand = brand;
                    newTruck.Model = model;
                    newTruck.Weight = weight;

                    trucks.Add(newTruck);
                }
                
                

            }
            Catalog catalog = new Catalog()
            {
                Cars = vehicle,
                Trucks = trucks
            };

            if (catalog.Cars.Any()) ;
            {
                Console.WriteLine("Cars:");
                foreach (var car in vehicle.OrderBy(a => a.Brand))
                {
                    Console.WriteLine($"{car.Brand}: {car.Model} - {car.HorsePower}hp");
                }
            }
            if (catalog.Trucks.Any())
            {
                Console.WriteLine("Trucks:");
                foreach (var truck in trucks.OrderBy(a => a.Brand))
                {
                    Console.WriteLine($"{truck.Brand}: {truck.Model} - {truck.Weight}kg");
                }
            }
        }
    }
}
