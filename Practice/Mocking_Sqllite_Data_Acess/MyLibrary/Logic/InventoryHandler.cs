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
using MyLibrary.Utilities.DataAccess;
using MyLibrary.Utilities.Validators;

namespace MyLibrary.Logic
{
    public class InventoryHandler : IInventoryHandler
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
            PropertyInfo[] propertyInfos = model.GetType().GetProperties();
            string retry;

            ValidationResult validation = null;

            do
            {//Id (index 0) should not be read because that is not pushed to the DB hence that is autoincremented                    
                for (int i = 1; i < propertyInfos.Length; i++)
                {
                    _userInterface.WriteOutToUser($"Please enter {propertyInfos[i].Name}:");

                    if (SetForeignKeyProperty(model, propertyInfos[i]) == false)
                    {
                        if (SetPropertyValue(model, propertyInfos[i]) == false)
                        {
                            i--;
                        }
                    } 
                }

                if (model.GetType() == typeof(ProductCategoryModel))
                {
                    validation = _productCategoryValidator.GetClass().Validate(model as ProductCategoryModel);
                }
                else if (model.GetType() == typeof(ProductModel))
                {
                    validation = _productValidator.GetClass().Validate(model as ProductModel);
                }

                // Error handling. Perhaps it should be moved to a function
                retry = "n";
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

            } while (retry == "y");

            return (model, validation.IsValid);
        }

        private bool SetPropertyValue<T>(T model, PropertyInfo propertyInfo) where T : new()
        {
            bool isSuccessFul = false;
            object value = _userInterface.ReadInFromUser();
            try
            {
                propertyInfo.SetValue(model, Convert.ChangeType(value, propertyInfo.PropertyType));
                isSuccessFul = true;
            }
            catch (FormatException e)
            {
                _userInterface.WriteOutToUser($"{e.Message}. Please enter {propertyInfo.Name} again in correct format.");                
            }

            return isSuccessFul;
        }

        /// <summary>
        /// Checks if a property is a foreign key reference to an other table. If so, then it displays the values of that table and prompts
        /// the user to set the Id value. Only values present in the foreign key table are accepted.
        /// If a foreign key table does not exist then its Id is set to -99
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"> T type class which might contain a property which is an foreign key</param>
        /// <param name="PropertyInfoOfModel">The property which is checked to be foreign key Id</param>
        /// <returns></returns>
        private bool SetForeignKeyProperty<T>(T model, PropertyInfo PropertyInfoOfModel) where T : new()
        {
            bool isForeignKeyProperty = false;            
            string propName = PropertyInfoOfModel.Name;
           
            //Checking for Foreign key
            if (propName.EndsWith("Id"))
            {
                isForeignKeyProperty = true;
                string modelName = propName.Replace("Id", "Model");
                var modelContainsForeignKey = Activator.CreateInstance("MyLibrary", $"MyLibrary.Models.{modelName}").Unwrap();

                _userInterface.WriteOutToUser("Please select an Id from the List below:");
                switch (modelName)
                {
                    case "ProductCategoryModel":
                        var productCategoryTable = LoadModel<ProductCategoryModel>((ProductCategoryModel)modelContainsForeignKey);
                        // Todo Perhaps here should we check for length 
                        //if (productCategoryTable.Count == 0)
                        //{
                        //    PropertyInfoOfModel.SetValue(model, -99);
                        //}
                                                
                        DisplayTable<ProductCategoryModel>(productCategoryTable);                        
                        SetForeignKeyValueFromForeignKeyTable<ProductCategoryModel, T>(productCategoryTable, model, PropertyInfoOfModel);

                        break;
                    //Put here other tables which are foreign key for some table.
                    //case "": 
                        //break;
                    default:
                        break;
                }
            }
            return isForeignKeyProperty;
        }
                
        private void SetForeignKeyValueFromForeignKeyTable<ForeinKeyModel, Model>(List<ForeinKeyModel> foreignKeyTable, Model model, PropertyInfo propertyInfo) where ForeinKeyModel: new() where Model: new()
        {
            if (foreignKeyTable.Count != 0)
            {
                string foreignKeyModelId = foreignKeyTable[0].GetType().GetProperties()[0].Name;
                _userInterface.WriteOutToUser("Please select an Id from the list");

                while (SetPropertyValue<Model>(model, propertyInfo) == false) ;

                do
                {
                    foreach (var item in foreignKeyTable)
                    {
                        if (item.GetType().GetProperty(foreignKeyModelId).GetValue(item).Equals(model.GetType().GetProperty(propertyInfo.Name).GetValue(model)))
                        {
                            // Successfully set Id: It is in the foreign key table
                            _userInterface.WriteOutToUser($"{propertyInfo.Name} was set successfully");
                            return;
                        }
                    }

                    _userInterface.WriteOutToUser($"{propertyInfo.Name} was NOT set successfully. Please choose a value from the list");
                    while (SetPropertyValue<Model>(model, propertyInfo) == false) ;

                } while (true);
            }
            // If a foreign key table does not exist then its Id is set to -99. ProductValidator is prepared to fail with this value.
            else
            {
                model.GetType().GetProperty(propertyInfo.Name).SetValue(model, -99);                
            }
        }

        public void DisplayTable<M>(List<M> modelTable) //where T : class, IEnumerable, new()
        {            
            foreach (var row in modelTable)
            {
                var pi = row.GetType().GetProperties();
                for (int j = 0; j < pi.Length; j++)
                {
                    _userInterface.WriteOutToUser($"{pi[j].Name}: {pi[j].GetValue(row)}");
                }
            }
        }

        public void SaveModel<T>(T model)
        {
            string sql = CreateSqlToSave(model);
 
            _dataAccess.SaveData(model, sql);
        }

        private string CreateSqlToSave<T>(T model)
        {
            string sql = $"INSERT INTO {GetDBTableName<T>(model)} (";

            PropertyInfo[] pi = model.GetType().GetProperties();
            for (int i = 1; i < pi.Length; i++)
            {
                if (i > 1)
                {
                    sql += ", ";
                }
                sql += $@"{pi[i].Name}";
            }

            sql += ") VALUES (";

            for (int i = 1; i < pi.Length; i++)
            {
                if (i > 1)
                {
                    sql += ", ";
                }

                sql += $@"@{pi[i].Name}";
            }

            sql += ")";

            return sql;
        }

        public List<T> LoadModel<T>(T model)
        {
            List<T> tableOfModel = new List<T>();

            if (File.Exists(_dataAccess.DBName) == true)
            {
                string tableName = GetDBTableName<T>(model);

                string sql = $"SELECT * FROM {tableName}";

                tableOfModel = _dataAccess.LoadData<T>(sql);
            }

            return tableOfModel;
        }

        private string GetDBTableName<T>(T model)
        {
            string tablelName = model.GetType().Name.Replace("Model", "");

            return tablelName;
        }
    }
}
