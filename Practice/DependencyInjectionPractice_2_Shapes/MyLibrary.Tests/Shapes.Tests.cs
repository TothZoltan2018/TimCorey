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
    public class Shapes
    {        
        [Theory]
        [InlineData(3, 4, 12)]
        public void CalculateArea_Rectangle(double sideA, double sideB, double expexted)
        {
            Rectangle rectangle = new Rectangle(sideA, sideB);

            double actual = rectangle.CalculateArea();

            Assert.Equal(expexted, actual);
        }

        [Theory]
        [InlineData(3, Math.PI * 3 * 3)]
        public void CalculateArea_Circle(double radius, double expexted)
        {
            Circle circle = new Circle(radius);

            double actual = circle.CalculateArea();

            Assert.Equal(expexted, actual);
        }

        [Theory]
        [InlineData(3, 4, 14)]
        public void CalculatePerimeter_Rectangle(double sideA, double sideB, double expexted)
        {
            Rectangle rectangle = new Rectangle(sideA, sideB);

            double actual = rectangle.CalculatePerimeter();

            Assert.Equal(expexted, actual);
        }

        [Theory]
        [InlineData(3, Math.PI * 3 * 2)]
        public void CalculatePerimeter_Circle(double radius, double expexted)
        {
            Circle circle = new Circle(radius);

            double actual = circle.CalculatePerimeter();

            Assert.Equal(expexted, actual);
        }

    }
}
