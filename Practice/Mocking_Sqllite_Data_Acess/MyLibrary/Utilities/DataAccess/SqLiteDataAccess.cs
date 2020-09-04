using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using Dapper;
using System.IO;

namespace MyLibrary
{    
    public class SqLiteDataAccess : ISqLiteDataAccess
    {
        public string DBName { get; set; }
        //string _dBName;

        public SqLiteDataAccess(string dBName)
        {
            DBName = dBName;
        }
        public void CreateDB()
        {
            if (File.Exists(DBName) == false)
            {
                SQLiteConnection.CreateFile(DBName);
            }            
        }

        //Does not work
        //public void DeleteDB()
        //{
        //    using (IDbConnection dBConn = new SQLiteConnection($"DataSource={DBName};Version=3;"))
        //    {
        //        //Does not work, exception, sql syntax error
        //        string sqlCommand = $"DROP DATABASE InventoryDB;";
        //        dBConn.Execute(sqlCommand);
        //    }
        //}

        //public void DeleteDBTables()
        //{
        //    using (IDbConnection dBConn = new SQLiteConnection($"DataSource={DBName};Version=3;"))
        //    {
        //        //Does not work, exception, sql syntax error
        //        string sqlCommand = $"DROP TABLE ProductCategory;";
        //        dBConn.Execute(sqlCommand);

        //        sqlCommand = $"DROP TABLE Product;";
        //        dBConn.Execute(sqlCommand);
        //    }
        //}

        public void CreateDBTables()
        {
            using (IDbConnection dBConn = new SQLiteConnection($"DataSource={DBName};Version=3;"))
            {
                string sqlCommand = "CREATE TABLE IF NOT EXISTS ProductCategory (" +
                    "ProductCategoryId INTEGER PRIMARY KEY, " +
                    "ProductCategoryName NVARCHAR(50) NOT NULL);";

                //SQLiteCommand command = new SQLiteCommand(sqlCommand, dBConn);

                dBConn.Execute(sqlCommand);

                sqlCommand = "CREATE TABLE IF NOT EXISTS [Product] (" +
                    "ProductId INTEGER NOT NULL, " +
                    "ProductName NVARCHAR(50) NOT NULL, " +
                    "[Description] NVARCHAR(50), " +
                    "ProductCategoryId INTEGER NOT NULL, " +
                    //"BestBefore DATETIME NOT NULL DEFAULT(GETDATE()), " +
                    "BestBefore DATETIME NOT NULL, " +
                    "Quantity FLOAT NOT NULL DEFAULT(1), " +
                    "Unit NVARCHAR(15), " +
                    "PRIMARY KEY(ProductId AUTOINCREMENT), " +
                    "FOREIGN KEY (ProductCategoryId) REFERENCES ProductCategory(ProductCategoryId));";
                dBConn.Execute(sqlCommand);
            }
        }

        public void SaveData<T>(T model, string sql)
        {
            using (IDbConnection dBConn = new SQLiteConnection($"DataSource={DBName};Version=3;"))
            {
                dBConn.Execute(sql, model);
            }
        }

        public List<T> LoadData<T>(string sql)
        {
            using (IDbConnection dBConn = new SQLiteConnection($"DataSource={DBName};Version=3;"))
            {
                var output = dBConn.Query<T>(sql, new DynamicParameters()); //Ez meg mi: DynamicParameters
                return output.ToList();
            }
        }
    }
}
