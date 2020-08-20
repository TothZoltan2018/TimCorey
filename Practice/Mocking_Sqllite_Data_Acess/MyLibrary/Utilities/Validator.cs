using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using MyLibrary.Models;
using System.Reflection;

namespace MyLibrary.Utilities
{
    //class Validator : AbstractValidator<T> 
    class Validator : AbstractValidator<ProductCategoryModel>
    {
        int ProductCategoryNameLength = 50;
        Validator()
        {
            RuleFor(p => p.ProductCategoryName).Length(1, 20).WithMessage($"Please enter a text between 1 and { ProductCategoryNameLength } character long");
        }


    //        RuleFor(d => d).Length(1, 20).WithMessage("Please enter a number between 1 and 20 character long")
    //        .Must(BeAValidNumber).WithMessage("Please enter a valid number")
    //        .Must(BePositiveNumber).WithMessage("Please enter a positive number");
    //}

    //protected bool BeAValidNumber(string inputData)
    //{
    //    inputData = inputData.Replace(".", "");
    //    return inputData.All(Char.IsNumber);
    //}
    }
}
