using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoLibrary;
using Xunit;
// This is a Windows Classic Desktop Class Library .NET Framework
// We references the DemoLibrary and installed Xunit, Xunit.Runner.Console and Xunit.Runner.VisualStudio nuget packages.
// Json file is added to set up TestExplorer
namespace DemoLibrary.Tests
{
    public class CalculatorTests
    {
        [Theory] // Ensures using InlineData
        [InlineData(4,3,7)]
        [InlineData(21, 5.25, 26.25)]
        [InlineData(double.MaxValue, 5, double.MaxValue)]        
        [InlineData(double.MaxValue, double.MaxValue, double.PositiveInfinity)]
        [InlineData(double.MaxValue, double.MinValue, 0)]
        public void Add_SimpleValuesShouldCalculate(double x, double y, double expected)
        {
            // Arrange

            // Act
            double actual = Calculator.Add(x, y);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory] // Ensures using InlineData
        [InlineData(2, 3, -1)]        
        [InlineData(double.MinValue, 5, double.MinValue)]
        [InlineData(double.MinValue, double.MaxValue, double.NegativeInfinity)]
        [InlineData(double.MinValue, double.MinValue, 0)]
        public void Subtract_SimpleValuesShouldCalculate(double x, double y, double expected)
        {
            // Arrange

            // Act
            double actual = Calculator.Subtract(x, y);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(8, 4, 32)]
        [InlineData(double.MaxValue, double.MaxValue, double.PositiveInfinity)]
        [InlineData(double.MaxValue, 1.000000000000001, double.PositiveInfinity)]
        //[InlineData(double.MaxValue, 1.0000000000000001, double.PositiveInfinity)] // This would fail
        [InlineData(double.MaxValue, double.MinValue, double.NegativeInfinity)]
        public void Multiply_SimpleValuesShouldCalculate(double x, double y, double expected)
        {
            double actual = Calculator.Multiply(x, y);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(8,4,2)]
        [InlineData(double.MaxValue, double.MaxValue, 1)]
        [InlineData(double.MaxValue, double.MinValue, -1)]
        [InlineData(0, double.MinValue, 0)]
        [InlineData(0, double.PositiveInfinity, 0)]
        [InlineData(double.NegativeInfinity, double.PositiveInfinity, double.NaN)]
        public void Divide_SimpleValuesShouldCalculate(double x, double y, double expected)
        {
            // Arrange

            // Act
            double actual = Calculator.Divide(x, y);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact] // Puts it to the TextExplorer
        public void Divide_DivideByZero()
        {
            // Arrange
            double expected = 0;

            // Act
            double actual = Calculator.Divide(15, 0);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
