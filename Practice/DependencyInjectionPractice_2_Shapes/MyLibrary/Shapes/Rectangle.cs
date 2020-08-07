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
        private IDataAccess _dataAccess;
        IMyValidator _myvalidator;

        private double _sideA;
        private double _sideB;

        public Rectangle(IDataAccess dataAccess, IMyValidator myvalidator)
        {           
            _dataAccess = dataAccess;
            _myvalidator = myvalidator;

            dataAccess.WriteOut($"Please enter one side of the {nameof(Rectangle)}:");
            _sideA = _myvalidator.GetNumberFromString();

            dataAccess.WriteOut($"Please enter the other side of the {nameof(Rectangle)}:");
            _sideB = _myvalidator.GetNumberFromString();
        }


        public void CalculateArea()
        {
            _dataAccess.WriteOut($"The Area of the {nameof(Rectangle)} is: { _sideA * _sideB}");
        }

        public void CalculatePerimeter()
        {
            _dataAccess.WriteOut($"The Area of the {nameof(Rectangle)} is: { 2 * (_sideA + _sideB)}");
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
