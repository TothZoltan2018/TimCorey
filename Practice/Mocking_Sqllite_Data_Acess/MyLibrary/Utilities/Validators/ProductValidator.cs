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

            // ProductCategoryId is et to -99 if ProductCategoryTable does not esist.
            RuleFor(p => p.ProductCategoryId).GreaterThan(0).WithMessage($"ProductCategoryId is 0 or negative. ProductCategory table is empty. Please create entries first.");
            
            // Todo for other properties, too.            
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
