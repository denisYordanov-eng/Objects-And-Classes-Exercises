using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleCatalogue
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
                if(type == "Car")
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
                else if(type == "Truck")
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
            if (vehicle.Count > 0)
            {
                Console.WriteLine("Cars:");
                foreach (var car in vehicle.OrderBy(a => a.Brand))
                {
                    Console.WriteLine($"{car.Brand}: {car.Model} - {car.HorsePower}hp");
                }
            }
            if (trucks.Count > 0)
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
