using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;
using MyLibrary.Models;
using MyLibrary.Utilities;

namespace MyLibrary.Logic
{
    public class InventoryHandler
    {
        private ISqLiteDataAccess _dataAccess;
        private IProductCategoryValidator _productCategoryValidator;
        private IProductValidator _productValidator;
        private IUserInterface _userInterface;

        public InventoryHandler(ISqLiteDataAccess dataAccess, IProductCategoryValidator productCategoryValidator, IProductValidator productValidator, IUserInterface userInterface)
        {
            _dataAccess = dataAccess;
            _productCategoryValidator = productCategoryValidator;
            _productValidator = productValidator;
            _userInterface = userInterface;
        }

        public void CreateDBAndTables()
        {
            //if (File.Exists(_dataAccess.DBName) == false)
            //{
                _dataAccess.CreateDB();
                _dataAccess.CreateDBTables();
            //}
        }

        public void DeleteDB()
        {
           File.Delete(_dataAccess.DBName);        
        }

        /// <summary>
        /// Generic method which creates instance of type T. 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public (T, bool) CreateModel<T>() where T : new()
        {            
            T model = new T();
            object value = null;
            PropertyInfo[] propertyInfos = model.GetType().GetProperties();
            string retry = "n";

            ValidationResult validation = null;

            do
            {
                for (int i = 0; i < propertyInfos.Length; i++)
                {
                    //Id should not be read because that is not pushed to the DB hence that is autoincremented
                    if (i > 0)
                    {
                        _userInterface.WriteOutToUser($"Please enter {propertyInfos[i].Name}:");
                        value = _userInterface.ReadInFromUser();

                        try
                        {
                            propertyInfos[i].SetValue(model, Convert.ChangeType(value, propertyInfos[i].PropertyType));
                        }
                        catch (FormatException e)
                        {
                            _userInterface.WriteOutToUser($"{e.Message}. Please enter {propertyInfos[i].Name} again in correct format.");
                            i--;
                            continue;
                        }
                    }
                }
                //// Todo: Fluent validation should check the values. It checks the whole class, not one by one, which is not the most user friendly   


                //if (_myValidator.GetType() == typeof(ProductCategoryValidator))
                //{
                //    //_myValidator.GetClass().Validate(model as ProductCategoryModel);
                //}
                //else if (_myValidator.GetType() == typeof(ProductValidator))
                //{
                //    //_myValidator.GetClass().Validate(model as ProductModel);//(Convert.ChangeType(model, ));
                //    (_myValidator as ProductValidator).GetClass().Validate(model as ProductModel); ;
                //    //.Validate(model as ProductModel);//(Convert.ChangeType(model, ));
                //}


                if (model.GetType() == typeof(ProductCategoryModel))
                {
                    validation = _productCategoryValidator.GetClass().Validate(model as ProductCategoryModel);
                }
                else if (model.GetType() == typeof(ProductModel))
                {
                    validation = _productValidator.GetClass().Validate(model as ProductModel);
                }

                // Error handling. Perhaps it should be moved to a function
                if (validation.IsValid == false)
                {
                    foreach (var error in validation.Errors)
                    {
                        _userInterface.WriteOutToUser(error.ErrorMessage);
                    }

                    _userInterface.WriteOutToUser("Please enter valid values or skip creating new entry!");
                    _userInterface.WriteOutToUser("Do you want to retry? Y/N");
                    retry = _userInterface.ReadInFromUser().ToString().ToLower();                    
                }

            } while (retry == "Y");

            return (model, validation.IsValid);
        }

        public void SaveModel<T>(T model)
        {
            string sql = "";

            if (GetDBTableName<T>(model) == "ProductCategory")
            {
                sql = $"INSERT INTO ProductCategory (ProductCategoryName) VALUES (@ProductCategoryName)";
            }

            if (GetDBTableName<T>(model) == "Product")
            {
                sql = "INSERT INTO Product (ProductName, [Description], ProdCategoryId, BestBefore, Quantity, Unit)" +
                    " VALUES (@ProductName, @Description, @ProdCategoryId, @BestBefore, @Quantity, @Unit)";
            }

            //ProductCategoryModel productCategory = model as ProductCategoryModel;
            //if (productCategory != null)
            //{
            //    sql = "INSERT INTO ProductCategory (ProductCategoryName) VALUES (@ProductCategoryName)";
            //}

            //ProductModel product = model as ProductModel;
            //if (product != null)
            //{
            //    sql = "INSERT INTO Product (ProductName, [Description], ProdCategoryId, BestBefore, Quantity, Unit)" +
            //        " VALUES (@ProductName, @Description, @ProdCategoryId, @BestBefore, @Quantity, @Unit)";
            //}

            _dataAccess.SaveData(model, sql);
        }

        public List<T> LoadModel<T>(T model)
        {
            string tableName = GetDBTableName<T>(model);

            string sql = $"SELECT * FROM {tableName}";

            return _dataAccess.LoadData<T>(sql);
        }

        public string GetDBTableName<T>(T model)
        {
            string tablelName = model.GetType().Name.Replace("Model", "");
            
            return tablelName;
        }
    }
}
