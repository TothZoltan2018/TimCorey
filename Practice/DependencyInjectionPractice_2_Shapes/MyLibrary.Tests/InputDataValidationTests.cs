using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using MyLibrary.Utilities;

namespace MyLibrary.Tests
{
    public class InputDataValidationTests
    {
        [Theory]
        [InlineData("1")]
        [InlineData("1.0")]
        [InlineData("2222")]
        public void Validate_StringShouldBeParsed(string x)
        {
            //Arrange

            //Act
            MyValidator myValidator = new MyValidator(null);
            var actual = myValidator.Validate(x);

            //Assert
            Assert.True(actual.IsValid);            
        }

        [Theory]
        [InlineData("-1")]
        [InlineData("0")]
        [InlineData("0.0")]
        [InlineData("111111111111111111111111111111111111111111111111111111")]
        [InlineData("0ssdf")]
        [InlineData("x")]
        public void Validate_StringShouldFail(string x)
        {
            //Arrange

            //Act
            MyValidator myValidator = new MyValidator(null);
            var actual = myValidator.Validate(x);
    
            //Assert
            Assert.False(actual.IsValid);
        }


    }
}
