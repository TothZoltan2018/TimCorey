using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLibrary.Utilities.Validators;
using MyLibrary.Models;
using Xunit;

namespace MyTests
{
    public class ProductCategoryValidatorTests
    {
        ProductCategoryValidator productCategoryValidator = new ProductCategoryValidator();
        ProductCategoryModel productCategory = new ProductCategoryModel
        {
            ProductCategoryId = 1,
            ProductCategoryName = ""
        };

        [Theory]
        [InlineData("ab")]
        [InlineData("12345678901234567890")]
        public void ValidateProductCategorySuccesfully(string productCategoryName)
        {
            productCategory.ProductCategoryName = productCategoryName;
            var result = productCategoryValidator.GetClass().Validate(productCategory);

            Assert.True(result.IsValid);            
        }

        [Theory]
        [InlineData("a")]
        [InlineData("123456789012345678901")]
        public void ValidateProductCategoryShouldFail(string productCategoryName)
        {
            productCategory.ProductCategoryName = productCategoryName;
            var result = productCategoryValidator.GetClass().Validate(productCategory);

            Assert.True(result.IsValid == false);
        }
    }
}
