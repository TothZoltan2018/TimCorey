using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MyLibrary.Models;

namespace MyLibrary.Logic
{
    public class InventoryHandler
    {
        private ISqLiteDataAccess _dataAccess;

        public InventoryHandler(ISqLiteDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
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

        public T CreateModel<T>() where T : new()
        {
            T model = new T();
            object value = null;
            PropertyInfo[] propertyInfos = model.GetType().GetProperties();

            for (int i = 0; i < propertyInfos.Length; i++)
            {
                //Id should not be read because that is not pushed to the DB hence that is autoincremented
                if (i > 0)
                {
                    Console.WriteLine($"Please enter {propertyInfos[i].Name}:");
                    value = Console.ReadLine();
                    // Todo: Fluent validation should check the values

                    propertyInfos[i].SetValue(model, Convert.ChangeType(value, propertyInfos[i].PropertyType));
                }
            }

            return model;
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
