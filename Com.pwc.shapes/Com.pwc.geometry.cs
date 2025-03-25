using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Pwc.shapes;

namespace Com.pwc.Geometry
{
    internal class Shapes
    {
        static void Main()
        {
            Circle circle = new Circle(7.0f);
            Console.WriteLine("Radius : " + circle.GetRadius());
            Console.WriteLine("Area : " + circle.CalculateCircleArea());
            Console.WriteLine("Circumference : " + circle.CalculateCircumference());
        }
    }
}
