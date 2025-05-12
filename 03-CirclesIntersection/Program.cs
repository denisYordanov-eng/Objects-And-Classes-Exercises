using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace _03_CirclesIntersection
{
    class Program
    {
        class Point
        {
            public double X { get; set; }
            public double Y { get; set; }
        }
        class Circle
        {
            public Point Center { get; set; }
            public double Radius { get; set; }
          
            public static bool Intersect( Circle circle1, Circle circle2)
            {
                double dx = circle1.Center.X - circle2.Center.X;
                double dy = circle1.Center.Y - circle2.Center.Y;
                double distance = Math.Sqrt((dx * dx) + (dy * dy));
                return distance <= (circle1.Radius + circle2.Radius);
            }
        }
      
        
        static void Main(string[] args)
        {
            string[] input1 = Console.ReadLine().Split(' ');
            string[] input2 = Console.ReadLine().Split(' ');

            Circle c1 = new Circle()
            {
                Center = new Point { X = double.Parse(input1[0]), Y = double.Parse(input1[1]) },
                Radius = double.Parse(input1[2])
            };

            Circle c2 = new Circle()
            {
                Center = new Point { X = double.Parse(input2[0]), Y = double.Parse(input2[1]) },
                Radius = double.Parse(input2[2])
            };
            Console.WriteLine(Circle.Intersect(c1, c2) ? "Yes" : "No");
        }
    }
}

