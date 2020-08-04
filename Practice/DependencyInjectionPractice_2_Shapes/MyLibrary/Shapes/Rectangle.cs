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
        private double _sideA;
        private double _sideB;

        public Rectangle(IValidator validator, IDataAccess dataAccess)
        {
            //_validator = validator;            
            _dataAccess = dataAccess;

            dataAccess.WriteOut($"Please enter one side of the {nameof(Rectangle)}:");
            _sideA = validator.ValidateInputData(dataAccess.ReadIn());
            dataAccess.WriteOut($"Please enter the other side of the {nameof(Rectangle)}:");
            _sideB = validator.ValidateInputData(dataAccess.ReadIn());
        }


        public void CalculateArea()
        {
            _dataAccess.WriteOut($"The Area of the {nameof(Rectangle)} is: { _sideA * _sideB}");
        }

        public void CalculatePerimeter()
        {
            _dataAccess.WriteOut($"The Area of the {nameof(Rectangle)} is: { 2 * (_sideA + _sideB)}");
        }
    }
}
