using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using MyLibrary.Models;
using System.Reflection;
using MyLibrary.Logic;

namespace MyLibrary.Utilities
{
    public class ProductValidator : AbstractValidator<ProductModel>, IProductValidator
    {
        int productNameLengthMin = 1;
        int productNameLengthMax = 50;
        int productQuantityMin = 0;
        int productQuantityMax = 500;
        int productQuantityMaxForOthers = 200;

        public ProductValidator()
        {
            RuleFor(p => p.ProductName).Length(productNameLengthMin, productNameLengthMax).WithMessage($"Please enter a text between {productNameLengthMin} and {productNameLengthMax} characters long");
                       
            RuleFor(p => p.Quantity).LessThan(productQuantityMax).When(p => p.Unit.ToLower() == "kg" 
                        || p.Unit.ToLower() == "litre" || p.Unit.ToLower() =="liter"
                        || p.Unit.ToLower() == "dkg" )
                        .WithMessage(($"Please enter a value less than {productQuantityMax}."));

            RuleFor(p => p.Quantity).InclusiveBetween(productQuantityMin, productQuantityMaxForOthers).WithMessage(($"Please enter a value between {productQuantityMin} and {productQuantityMaxForOthers}.")); ;

            RuleFor(p => p.BestBefore).GreaterThanOrEqualTo(DateTime.Today).WithMessage("Please enter a DateTime value which is in the future.");

            // Todo for other properties, too.

            //TODO productcategoryId should not be asked for. Instead productcategoryName but from the list read back from DB.
        }

        public ProductValidator GetClass()
        {
            return this;
        }

        //public IMyValidator GetClass<IMyValidator>()
        //{
        //    return this;
        //}

        //public IMyValidator GetClass()
        //{
        //    return this;
        //}

    }
}
