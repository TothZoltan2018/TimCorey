using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using MyLibrary.Models;
using System.Reflection;

namespace MyLibrary.Utilities.Validators
{
    //class Validator : AbstractValidator<T> 
    public class ProductCategoryValidator : AbstractValidator<ProductCategoryModel>, IProductCategoryValidator
    {
        int productCategoryNameLengthMin = 1;
        int productCategoryNameLengthhMax = 20;
        public ProductCategoryValidator()
        {
            RuleFor(p => p.ProductCategoryName).Length(productCategoryNameLengthMin, productCategoryNameLengthhMax).WithMessage($"Please enter a text between {productCategoryNameLengthMin} and {productCategoryNameLengthhMax} character long");            
        }

        public ProductCategoryValidator GetClass()
        {
            return this;
        }

        //public ProductCategoryValidator GetClass<ProductCategoryValidator>()
        //{
        //    return this;
        //}

        //public IMyValidator GetClass()
        //{
        //    return this;
        //}

    }
}
