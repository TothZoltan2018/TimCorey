using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Xunit;
using MyLibrary.Shapes;

namespace MyLibrary.Tests
{
    // The Shape classes cannot be tested. Needs to be reworked so that
    // they not write results out but return value.
    public class Shapes
    {        
        [Theory]
        [InlineData(3, 4, 12)]
        public void RectangleArea(double sideA, double sideB, double Area)
        {
            Rectangle rectangle = new Rectangle(null, null);

            rectangle.CalculateArea();
            
        }
    }
}
