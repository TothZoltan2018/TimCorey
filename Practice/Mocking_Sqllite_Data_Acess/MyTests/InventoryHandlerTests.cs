using MyLibrary.Utilities.Validators;
using MyLibrary.Models;
using Xunit;
using System;
using MyLibrary.Logic;
using Autofac;
using ConsoleApp1;
using MyLibrary.Utilities.DataAccess;
using Autofac.Extras.Moq;
using Moq;
using System.Collections.Generic;
using Xunit.Abstractions;

namespace MyTests
{    
    public class InventoryHandlerTests
    {

        //[Fact]
        //// LoadModel is a generic method. We are testing it by mocking the database access. (We use Productmodel which is the more complex datatype.)
        //public void LoadModel()
        //{
        //    using (var mock = AutoMock.GetLoose())
        //    {
        //        // DBName property must ve set to the name of the database otherwise
        //        // Inventoryhandler.Loadmodel will not try to reach out the database.
        //        mock.Mock<ISqLiteDataAccess>().SetupGet(x => x.DBName).Returns(@"C:\Users\ZoliRege\source\repos\TimCorey\Practice\Mocking_Sqllite_Data_Acess\ConsoleApp1\bin\Debug\InventoryDB.sqlite");
        //        mock.Mock<ISqLiteDataAccess>().Setup(x => x.LoadData<ProductModel>("SELECT * FROM Product"))
        //            .Returns(GetMockedData<ProductModel>(new ProductModel()));

        //        var classUnderTest = mock.Create<InventoryHandler>();

        //        var actual = classUnderTest.LoadModel<ProductModel>(new ProductModel());

        //        var expected = GetMockedData<ProductModel>(new ProductModel());

        //        Assert.True(actual != null);
        //        // Todo check items one by one
        //        for (int i = 0; i < actual.Count; i++)
        //        {
        //            Assert.True(ScrollOverPropertiesAndCheckIfEqual<ProductModel>(actual[i], expected[i]));
        //        }
        //    }
        //}

        [Theory]
        // https://andrewlock.net/creating-strongly-typed-xunit-theory-test-data-with-theorydata/
        [ClassData(typeof(LoadProductModelTestData))]
        [ClassData(typeof(LoadProductCategoryModelTestData))]
        // notUsedDummyModel parameter is only to be able to use the above ClassData
        public void LoadModelSuccessfully<T>(T notUsedDummyModel) where T: new()
        {
            using (var mock = AutoMock.GetLoose())
            {
                // DBName property must be set to the name of the database otherwise
                // Inventoryhandler.Loadmodel will not try to reach out the database.
                mock.Mock<ISqLiteDataAccess>().SetupGet(x => x.DBName).Returns(@"C:\Users\ZoliRege\source\repos\TimCorey\Practice\Mocking_Sqllite_Data_Acess\ConsoleApp1\bin\Debug\InventoryDB.sqlite");

                // Which table is queried Product vs ProductCategory? I wanted to retreive the table name
                //  from Type T and use it in the SQL statement below. BUT:
                // !!! I do not need to determine it !!! Somehow it stll works fine!                
                //mock.Mock<ISqLiteDataAccess>().Setup(x => x.LoadData<T>("SELECT * FROM ProductCategory"))
                //    .Returns(GetMockedData<T>(new T()));
                //mock.Mock<ISqLiteDataAccess>().Setup(x => x.LoadData<T>("SELECT * FROM Product"))
                //    .Returns(GetMockedData<T>(new T()));

                string tableName = typeof(T).Name.Replace("Model", "");
                mock.Mock<ISqLiteDataAccess>().Setup(x => x.LoadData<T>($"SELECT * FROM {tableName}"))
                    .Returns(GetMockedData<T>(new T()));

                var classUnderTest = mock.Create<InventoryHandler>();
                
                var actual = classUnderTest.LoadModel<T>(new T());

                var expected = GetMockedData<T>(new T());

                Assert.True(actual != null);
                // Todo check items one by one
                for (int i = 0; i < actual.Count; i++)
                {
                    Assert.True(ScrollOverPropertiesAndCheckIfEqual<T>(actual[i], expected[i]));
                }
            }
        }

        #region ClassData for testmethod LoadModelSuccessfully
        public class TheoryData<T> : TheoryData
        {
            public void Add(T p)
            {
                AddRow(p);
            }            
        }

        public class LoadProductModelTestData : TheoryData<ProductModel>
        {
            public LoadProductModelTestData()
            {
                ProductModel p = new ProductModel();
                CreateOneDummyModelInstance(p);
                Add(p);
            }
        }

        public class LoadProductCategoryModelTestData : TheoryData<ProductCategoryModel>
        {
            public LoadProductCategoryModelTestData()
            {
                ProductCategoryModel p = new ProductCategoryModel();
                CreateOneDummyModelInstance(p);
                Add(p);
            }
        }
        #endregion

        [Theory]
        [ClassData(typeof(LoadProductModelTestData))]
        [ClassData(typeof(LoadProductCategoryModelTestData))]

        // I don't wanted to overgeneralize this method by using InventoryHandler.CreateSqlToSave method.
        // Therfore only 2 models are used hereby.
        public void SaveModelSuccessfully<T>(T model)// where T : new()
        {
            using (var mock = AutoMock.GetLoose())
            {
                CreateOneDummyModelInstance(model);

                string sql = string.Empty;
                string tablelName = model.GetType().Name.Replace("Model", "");
                if (tablelName == "ProductCategory")
                {
                    sql = $"INSERT INTO ProductCategory (ProductCategoryName) VALUES (@ProductCategoryName)";
                }

                if (tablelName == "Product")
                {
                    sql = "INSERT INTO Product (ProductName, Description, ProductCategoryId, BestBefore, Quantity, Unit)" +
                        " VALUES (@ProductName, @Description, @ProductCategoryId, @BestBefore, @Quantity, @Unit)";
                }

                mock.Mock<ISqLiteDataAccess>().Setup(x => x.SaveData(model, sql));
                var classUnderTest = mock.Create<InventoryHandler>();
                classUnderTest.SaveModel(model);

                mock.Mock<ISqLiteDataAccess>().Verify(x => x.SaveData(model, sql), Times.Once);
            }

        }

        private List<T> GetMockedData<T>(T model)
        {
            List<T> output = new List<T>();
            int numberOfItems = 3;
            for (int i = 0; i < numberOfItems; i++)
            {
                CreateOneDummyModelInstance(model);
                output.Add(model);
            }

            return output;
        }

        // This method is not needed as the 'new Productmodel' creates default values
        private static void CreateOneDummyModelInstance<T>(T model)
        {
            var pi = model.GetType().GetProperties();
            for (int j = 0; j < pi.Length; j++)
            {
                // Creates a dummy model with default values                                
                if (pi[j].PropertyType.Name == "DateTime")
                {
                    var value = DateTime.MinValue;
                    pi[j].SetValue(model, Convert.ChangeType(value, pi[j].PropertyType));
                }
                else
                {
                    object value = 0;
                    pi[j].SetValue(model, Convert.ChangeType(value, pi[j].PropertyType));
                }
            }
        }

        private static bool ScrollOverPropertiesAndCheckIfEqual<T>(T model1, T model2) //where T: new()
        {            
            var pi = model1.GetType().GetProperties();
            for (int j = 0; j < pi.Length; j++)
            {
                // This is not usuable because this still returns an object and I cannot cast it to the actual type
                //var value1 = Convert.ChangeType(pi[j].GetValue(model1), pi[j].PropertyType);
                //var value2 = Convert.ChangeType(pi[j].GetValue(model2), pi[j].PropertyType);

                switch (pi[j].PropertyType.Name)
                {
                    case "Int32" :
                        if ((int)pi[j].GetValue(model1) != (int)pi[j].GetValue(model2))
                        {
                            return false;
                        }
                        break;
                    case "String":
                        if ((string)pi[j].GetValue(model1) != (string)pi[j].GetValue(model2))
                        {
                            return false;
                        }
                        break;
                    case "DateTime":
                        if ((DateTime)pi[j].GetValue(model1) != (DateTime)pi[j].GetValue(model2))
                        {
                            return false;
                        }
                        break;

                    default:
                        break;
                }

            }
            return true;
        }
    }    
}
