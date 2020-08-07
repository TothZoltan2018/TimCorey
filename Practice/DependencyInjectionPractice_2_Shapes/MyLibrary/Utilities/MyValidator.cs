using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Utilities
{
    public class MyValidator : AbstractValidator<string>, IMyValidator
    {
        IDataAccess _dataAccess;
        public MyValidator(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;

            RuleFor(d => d).Length(1, 20).WithMessage("Please enter a number between 1 and 20 character long")
            .Must(BeAValidNumber).WithMessage("Please enter a valid number")
            .Must(BePositiveNumber).WithMessage("Please enter a positive number");
        }

        protected bool BeAValidNumber(string inputData)
        {
            inputData = inputData.Replace(".", "");
            return inputData.All(Char.IsNumber);
        }

        /// <summary>
        /// In fact, only this method would be enough, but for the sake of 
        /// practice I let the rest.
        /// </summary>
        /// <param name="inputData"></param>
        /// <returns></returns>
        protected bool BePositiveNumber(string inputData)
        {
            //int.TryParse(inputData, out int intParsed);
            double.TryParse(inputData, out double doubleParsed);

            return doubleParsed > 0;
        }

        public double GetNumberFromString()
        {
            bool isParsed;
            string inputData;
            do
            {
                inputData = _dataAccess.ReadIn();
                var result = this.Validate(inputData);
                for (int i = 0; i < result.Errors.Count; i++)
                {
                    _dataAccess.WriteOut(result.Errors[i].ErrorMessage);
                }

                isParsed = result.IsValid;
            } while (isParsed == false);

            return double.Parse(inputData);
        }

        //public double ValidateInputData(string readInData)
        //{
        //    double output = 0;
        //    int outputInt = 0;

        //    while (true)
        //    {
        //        if (int.TryParse(readInData, out outputInt))
        //        {
        //            return outputInt;
        //        }
        //        else if (double.TryParse(readInData, out output))
        //        {
        //            return output;
        //        }
        //        else
        //        {
        //            _dataAccess.WriteOut("Please enter a VALID numeric value:");
        //            readInData = _dataAccess.ReadIn();
        //        }
        //    }
        //}        
    }
}
