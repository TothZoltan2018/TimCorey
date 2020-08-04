using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Utilities
{
    public class Validator : IValidator
    {
        private IDataAccess _dataAccess;

        public Validator(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;            
        }

        public double ValidateInputData(string readInData)
        {
            double output = 0;
            int outputInt = 0;
            
            while (true)
            {
                if (int.TryParse(readInData, out outputInt))
                {
                    return outputInt;
                }
                else if (double.TryParse(readInData, out output))
                {
                    return output;
                }
                else
                {
                    _dataAccess.WriteOut("Please enter a VALID numeric value:");
                    readInData = _dataAccess.ReadIn();
                }
            }
        }
    }
}
