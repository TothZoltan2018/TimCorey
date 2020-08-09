using MyLibrary.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Shapes
{
    public class Rectangle : IShapes, IRectangle
    {
        public double SideA { get; set; }
        public double SideB { get; set; }

        public Rectangle(double sideA, double sideB)
        {
            SideA = sideA;
            SideB = sideB;            
        }


        public double CalculateArea()
        {
            return SideA * SideB;
        }

        public double CalculatePerimeter()
        {
            return 2 * (SideA + SideB);
        }

        //private double GetNumberFromString()
        //{
        //    string input;
        //    bool isParsed;

        //    do
        //    {
        //        input = _dataAccess.ReadIn();
        //        var result = _validator.Validate(input);
        //        isParsed = result.IsValid;
        //    } while (isParsed == false);

        //    return double.Parse(input);
        //}
    }
}
