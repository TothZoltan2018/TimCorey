using DRYDemoLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DryDemoLibraryTest
{
    public class EmployeeProcessorTest
    {
        //It does not care with the ending quasi random numbers
        [Theory]
        [InlineData("Zoltan", "Toth", "ZoltToth")]
        [InlineData("Zol", "Toth", "ZolxToth")]
        [InlineData("Zo", "To", "ZoxxToxx")]
        public void GenerateEmployeeId_ShouldCalculate(string firstName, string lastName, string expectedStart) 
        {
            //Arrange
            EmployeeProcessor processor = new EmployeeProcessor();

            //Act
            string actualStart = processor.GenerateEmployeeID(firstName, lastName).Substring(0, expectedStart.Length);

            //Assert
            Assert.Equal(expectedStart, actualStart);
        }
    }
}
