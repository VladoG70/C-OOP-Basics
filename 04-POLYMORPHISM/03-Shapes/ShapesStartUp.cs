using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class ShapesStartUp
    {
    static void Main(string[] args)
        {
        Shape rectangle = new Rectangle(2.5, 3);
        Shape circle = new Circle(5);

        Console.WriteLine("Rectangle:");
        Console.WriteLine(rectangle.CalculatePerimeter());
        Console.WriteLine(rectangle.CalculateArea());
        Console.WriteLine(rectangle.Draw());
        Console.WriteLine("Circle:");
        Console.WriteLine(circle.CalculatePerimeter());
        Console.WriteLine(circle.CalculateArea());
        Console.WriteLine(circle.Draw());
        }
    }

