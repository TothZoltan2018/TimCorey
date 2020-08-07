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
        IDataAccess _dataAccess;
        IMyValidator _myvalidator;
        double _radius;

        public Circle(IDataAccess dataAccess, IMyValidator myvalidator)
        {     
            _dataAccess = dataAccess;
            _myvalidator = myvalidator;

            dataAccess.WriteOut($"Please enter the radius of the {nameof(Circle)}:");
            _radius = _myvalidator.GetNumberFromString();
        }

        public void CalculateArea()
        { 
            _dataAccess.WriteOut($"The Area of the {nameof(Circle)} is: { _radius * _radius * Math.PI}");
        }

        public void CalculatePerimeter()
        {
            _dataAccess.WriteOut($"The Perimeter of the {nameof(Circle)} is: { 2 * _radius * Math.PI}");
        }
    }
}
