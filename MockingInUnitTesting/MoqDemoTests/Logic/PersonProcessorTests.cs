using System;
using System.Collections.Generic;
using Autofac.Extras.Moq;
using DemoLibrary.Logic;
using DemoLibrary.Models;
using DemoLibrary.Utilities;
using Moq;
using Xunit;

namespace MoqDemoTests.Logic
{
    /// <summary>
    /// For Database testing we use mocking. For that purpose we indstall 'Moq' abd 'Autofac.Extras.Moq' nuget packages.
    /// Also, updated all nuget packages.
    /// </summary>
    public class PersonProcessorTests
    {
        [Theory]
        [InlineData("6'8\"", true, 80)]
        [InlineData("6\"8'", false, 0)]
        [InlineData("six'eight\"", false, 0)]
        public void ConvertHeightTextToInches_VariousOptions(
            string heightText,
            bool expectedIsValid,
            double expectedHeightInInches)
        {
            // We passes 'null' to the constructor because we do not use '_database' variable.
            PersonProcessor processor = new PersonProcessor(null);

            var actual = processor.ConvertHeightTextToInches(heightText);

            Assert.Equal(expectedIsValid, actual.isValid);
            Assert.Equal(expectedHeightInInches, actual.heightInInches);
        }

        [Theory]
        [InlineData("Tim", "Corey", "6'8\"", 80)]
        [InlineData("Charitry", "Corey", "5'4\"", 64)]
        public void CreatePerson_Successful(string firstName, string lastName, string heightText, double expectedHeight)
        {
            PersonProcessor processor = new PersonProcessor(null);

            PersonModel expected = new PersonModel
            {
                FirstName = firstName,
                LastName = lastName,
                HeightInInches = expectedHeight,
                Id = 0
            };

            var actual = processor.CreatePerson(firstName, lastName, heightText);

            Assert.Equal(expected.Id, actual.Id);
            Assert.Equal(expected.FirstName, actual.FirstName);
            Assert.Equal(expected.LastName, actual.LastName);
            Assert.Equal(expected.HeightInInches, actual.HeightInInches);

        }

        [Theory]
        [InlineData("Tim#", "Corey", "6'8\"", "firstName")]
        [InlineData("Charitry", "C88ey", "5'4\"", "lastName")]
        [InlineData("Jon", "Corey", "SixTwo", "heightText")]
        [InlineData("", "Corey", "5'11\"", "firstName")]
        public void CreatePerson_ThrowsException(string firstName, string lastName, string heightText, string expectedInvalidParameter)
        {
            PersonProcessor processor = new PersonProcessor(null);

            var ex = Record.Exception(() => processor.CreatePerson(firstName, lastName, heightText));

            Assert.NotNull(ex);
            Assert.IsType<ArgumentException>(ex);
            if (ex is ArgumentException argEx)
            {
                Assert.Equal(expectedInvalidParameter, argEx.ParamName);
            }
        }

        [Fact]
        public void LoadPeople_ValidCall()
        {
            // AutoMock is a framework for creating fake items            
            using (var mock = AutoMock.GetLoose())
            {
                /// We mocked out the 'LoadData' method. When it is called with that sql command,
                /// it returns the List<PersonModel> created by GetSamplePeople method.
                mock.Mock<ISqliteDataAccess>()
                    .Setup(x => x.LoadData<PersonModel>("select * from Person"))
                    .Returns(GetSamplePeople());
                /// cls: the class we are testing. When this 'PersonProcessor' type class asks for 'ISqliteDataAccess',
                /// it wiil not gi e back 'SqliteDataAccess' but it gives back the above mocked version. 
                /// (With only one method ('LoadData') out of three.)
                /// I think, the only requirement for passing the first two tests is, that sql command must mach here and
                /// in the 'PersonProcessor.Load()' method. It can be even absolutely nonsense string literal.
                var cls = mock.Create<PersonProcessor>();
                /// So this is where the mocked database access happens. It "loads" the mocked data.
                var actual = cls.LoadPeople();

                var expected = GetSamplePeople();

                Assert.True(actual != null); // 1.
                Assert.Equal(expected.Count, actual.Count); //2.
                // The 'Assert.Equal' compares objects, not values!
                //Assert.Equal(expected, actual);

                for (int i = 0; i < expected.Count; i++)
                {
                    Assert.Equal(expected[i].FirstName, actual[i].FirstName);
                    Assert.Equal(expected[i].LastName, actual[i].LastName);
                }
            }            
        }

        [Fact]
        public void SavePeople_ValidCall()
        {
            // AutoMock is a framework for creating fake items            
            using (var mock = AutoMock.GetLoose())
            {
                var person = GetSamplePeople()[0];
                string sql = "insert into Person (FirstName, LastName, HeightInInches) " +
               "values (@FirstName, @LastName, @HeightInInches)";

                mock.Mock<ISqliteDataAccess>()
                    .Setup(x => x.SaveData(person, sql));
                
                var cls = mock.Create<PersonProcessor>();
                cls.SavePerson(person);

                /// This checks if the 'SaveData' method call inside the 'ISqliteDataAccess' interface
                /// happened exactly onece.
                mock.Mock<ISqliteDataAccess>()
                    .Verify(x => x.SaveData(person, sql), Times.Exactly(1));

                
  
            }
        }

        private List<PersonModel> GetSamplePeople()
        {
            List<PersonModel> output = new List<PersonModel>
            {
                new PersonModel
                {
                    FirstName = "Zoli",
                    LastName = "Toth"
                },
                new PersonModel
                {
                    FirstName = "Rege",
                    LastName = "Papp"
                },
                new PersonModel
                {
                    FirstName = "Sugi",
                    LastName = "Toth"
                },
                new PersonModel
                {
                    FirstName = "Zolika",
                    LastName = "Toth"
                },
            };

            return output;                                
        }
    }
}
