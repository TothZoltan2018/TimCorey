using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
            if (File.Exists(_dataAccess.DBName) == false)
            {
                _dataAccess.CreateDB();
                _dataAccess.CreateDBTables();
            }
        }

        public void DeleteDB()
        {
           File.Delete(_dataAccess.DBName);
        
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
