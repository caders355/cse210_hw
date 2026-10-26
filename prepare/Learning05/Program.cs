/**/

using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>();

        shapes.Add(new Square("Blue", 4));
        shapes.Add(new Rectangle("Red", 4, 5));
        shapes.Add(new Circle("Green", 3));

        foreach (Shape s in shapes)
        {
            Console.WriteLine($"The {s.GetColor()} shape has an area of {s.GetArea()}");
        }
    }
}