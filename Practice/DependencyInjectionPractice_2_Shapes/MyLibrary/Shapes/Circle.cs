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
        //IValidator _validator;        
        IDataAccess _dataAccess;

        double _radius;

        public Circle(IValidator validator, IDataAccess dataAccess)
        {
            //_validator = validator;            
            _dataAccess = dataAccess;

            dataAccess.WriteOut($"Please enter the radius of the {nameof(Circle)}:");
            _radius = validator.ValidateInputData(dataAccess.ReadIn());
        }

        public void CalculateArea()
        {
            //_dataAccess.WriteOut($"Please enter the radius of the {nameof(Circle)}:");
            //Radius = _validator.ValidateInputData(_dataAccess.ReadIn());

            _dataAccess.WriteOut($"The Area of the {nameof(Circle)} is: { _radius * _radius * Math.PI}");
        }

        public void CalculatePerimeter()
        {
            //_dataAccess.WriteOut($"Please enter the radius of the {nameof(Circle)}:");
            //Radius = _validator.ValidateInputData(_dataAccess.ReadIn());

            _dataAccess.WriteOut($"The Perimeter of the {nameof(Circle)} is: { 2 * _radius * Math.PI}");
        }
    }
}
