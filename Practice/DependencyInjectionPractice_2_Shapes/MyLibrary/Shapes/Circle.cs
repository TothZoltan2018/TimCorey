using MyLibrary.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Shapes
{
    public class Circle : IShapes, ICircle
    {
        public double Radius { get; set; }

        public Circle(double radius)
        {
            Radius = radius;
        }

        public double CalculateArea()
        { 
           return Radius * Radius * Math.PI;
        }

        public double CalculatePerimeter()
        {
            return 2 * Radius * Math.PI;
        }
    }
}
