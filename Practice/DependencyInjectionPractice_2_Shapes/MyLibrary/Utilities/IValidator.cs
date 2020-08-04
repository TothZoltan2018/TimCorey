using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Utilities
{
    public interface IValidator
    {
        double ValidateInputData(string radiusOrSides);
    }
}
