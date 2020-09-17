using MyLibrary.Utilities.Validators;
using MyLibrary.Models;
using Xunit;
using System;

namespace MyTests
{
    public class ProductValidatorTests
    {
        ProductValidator productValidator = new ProductValidator();
        // Default values for properties which has a validation rule. Particular properties will be overwritten in test cases
        ProductModel productModel = new ProductModel()
        {
            ProductId = 1,        
            ProductName = "test",
            BestBefore = DateTime.Now.AddDays(15),
            ProductCategoryId = 1,
            Unit = "test",
            Quantity = 10            
        };        

        [Theory]
        [InlineData("Litre", 500)]
        [InlineData("liter", 1)]
        [InlineData("kg", 500)]
        [InlineData("Kg", 500)]
        [InlineData("dkg", 1)]
        [InlineData("dummy", 20000)]
        [InlineData("dummy", 1)]
        public void ValidateProductSuccesfullyForQuantityShouldPass(string unitName, int quantity)
        {
            productModel.Unit = unitName;
            productModel.Quantity = quantity;

            var result = productValidator.GetClass().Validate(productModel);
            
            Assert.True(result.IsValid);
        }

        [Theory]
        [InlineData("Litre", 501)]
        [InlineData("liter", 0)]
        [InlineData("kg", 501)]
        [InlineData("Kg", 0)]
        [InlineData("dkg", 0)]
        [InlineData("dummy", 20001)]
        [InlineData("dummy", 0)]
        public void ValidateProductSuccesfullyForQuantityShouldFail(string unitName, int quantity)
        {
            productModel.Unit = unitName;
            productModel.Quantity = quantity;

            var result = productValidator.GetClass().Validate(productModel);

            Assert.True(result.Errors.Count > 0);
        }

        [Theory]
        [InlineData(1)]        
        public void ValidateProductSuccesfullyForBestBeforeSouldPass(int dayOffset)
        {
            productModel.BestBefore = DateTime.Now.AddDays(dayOffset);            

            var result = productValidator.GetClass().Validate(productModel);

            Assert.True(result.IsValid);
        }



    }
}
