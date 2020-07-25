using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using DemoLibrary;
using DemoLibrary.Models;

namespace DemoLibrary.Tests
{
    public class DataAccessTests
    {
        [Fact]
        public void AddPersonToPeopleList_ShouldWork()
        {
            PersonModel newPerson = new PersonModel { FirstName = "Tim", LastName = "Corey" };
            List<PersonModel> people = new List<PersonModel>();

            DataAccess.AddPersonToPeopleList(people, newPerson);

            Assert.True(people.Count == 1);
            Assert.Contains<PersonModel>(newPerson, people);
        }

        [Theory]
        [InlineData("Tim", "", "LastName")]
        [InlineData("", "Corey", "FirstName")]
        public void AddPersonToPeopleList_ShouldFail(string firstName, string lastName, string param)
        {
            PersonModel newPerson = new PersonModel { FirstName = firstName, LastName = lastName };
            List<PersonModel> people = new List<PersonModel>();

            Assert.Throws<ArgumentException>(param, () => DataAccess.AddPersonToPeopleList(people, newPerson));
        }

        [Fact]
        public void ConvertModelsToCSV_AddPersonToPeopleList_ShouldWork()
        {
            List<PersonModel> people = new List<PersonModel> {
                new PersonModel { FirstName = "Bill", LastName = "Gates" },
                new PersonModel { FirstName = "Steve", LastName = "Jobs" }
            };

            List<string> actual = new List<string>();
            actual = DataAccess.ConvertModelsToCSV(people);

            //Assert.True(actual.Count == 2);

            for (int i = 0; i < actual.Count; i++)
            {
                string[] data = actual[i].Split(',');
                Assert.True((data[0] == people[i].FirstName) && (data[1] == people[i].LastName));
            }
        }

        [Theory]
        [InlineData("Bill", "Gates", "Bill,Gates")]
        [InlineData("Steve", "Jobs", "Steve,Jobs")]
        public void ConvertModelsToCSV_AddPersonToPeopleList_ShouldWork2(string firstName, string lastName, string expected)
        {
            List<PersonModel> oneElementList = new List<PersonModel>
            {
                new PersonModel{FirstName = firstName, LastName = lastName }
            };

            string actual = DataAccess.ConvertModelsToCSV(oneElementList)[0];

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("Bill", "Gates", "Bill,Gates")]
        [InlineData("Steve", "Jobs", "Steve,Jobs")]
        public void ConvertCSVToModel(string expectedFirstName, string expectedLastName, string cSVName)
        {
            List<PersonModel> person = new List<PersonModel>();
            string[] cSVArray = { cSVName };

            DataAccess.ConvertCSVToModel(person, cSVArray);

            Assert.Equal(person[0].FirstName, expectedFirstName);
            Assert.Equal(person[0].LastName, expectedLastName);
        }
    }
}
