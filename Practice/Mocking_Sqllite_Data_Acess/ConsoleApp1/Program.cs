using MyLibrary;
using MyLibrary.Logic;
using MyLibrary.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApp1
{
    /// <summary>
    /// 1. Install Nuget packages to Project 'Mylibrary': 'System.LData.SQite.Core' and 'Dapper'
    /// 2. Install Nuget package to Project 'ConsoleUI': 'System.Data.SQLite.Core'. (Without it, in the DataAccess
    /// class it throws 'Unable to load DLL 'SQLite.Interop.dll': The specified module could not be found.', although 
    /// the dll is present the same places as after install the package.)
    /// Megsem!2.I added System.Configuration to 'Mylibrary' References.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            ISqLiteDataAccess sqLiteDataAccess = new SqLiteDataAccess("InventoryDB.sqlite");   
            InventoryHandler inventoryHandler = new InventoryHandler(sqLiteDataAccess);

            inventoryHandler.CreateDBAndTables();

            string choice;
            ProductCategoryModel productCategory = new ProductCategoryModel
            {
                //ProductCategoryId = 34347,
                ProductCategoryName = "Dairy"
            };


            inventoryHandler.SaveModel(productCategory);

            ProductModel product = new ProductModel
            {
                //ProductId = 1,
                ProductName = "XXXXX",
                Description = "jjjjj",
                ProdCategoryId = 3,
                BestBefore = DateTime.Today,
                Quantity = 4,
                Unit = "MT"
            };

            inventoryHandler.SaveModel(product);

            do
            {
                choice = DisplayMenuAndGetInChoice();

                switch (choice)
                {
                    case "1":
                        DisplayDBTable<List<ProductCategoryModel>>(inventoryHandler.LoadModel<ProductCategoryModel>(productCategory));
                        break;
                    case "2":
                        DisplayDBTable<List<ProductModel>>(inventoryHandler.LoadModel<ProductModel>(product));
                        break;
                    case "3":
                        CreateAndSaveModel<ProductCategoryModel>(inventoryHandler);
                        break;
                    case "4":
                        CreateAndSaveModel<ProductModel>(inventoryHandler);
                        break;
                    case "5":
                        Console.WriteLine("Thanks for using this application");
                        break;
                    default:
                        Console.WriteLine("That was an invalid choice. Hit enter and try again.");
                        break;
                }
                Console.WriteLine("Hit return to continue...");
                Console.ReadLine();

            } while (choice != "5");

            //inventoryHandler.LoadModel<ProductCategoryModel>(productCategory);

            //productHandler.DeleteDB();            
        }

        private static void CreateAndSaveModel<T>(InventoryHandler inventoryHandler) where T: new()
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

            inventoryHandler.SaveModel<T>(model);
        }

        /// Displays a Generic List.        
        private static void DisplayDBTable<T>(T list) where T : class, IEnumerable, new()
        {            
            //this is a list of type, not a type. How to get the type?
            foreach (var item in list)
            {                
                PropertyInfo[] propertyInfoArr = item.GetType().GetProperties();
                for (int i = 0; i < propertyInfoArr.Length; i++)
                {                    
                    // ################## Wow! #####################
                    Console.WriteLine($"{propertyInfoArr[i].Name}: {propertyInfoArr[i].GetValue(item)}");
                } 
            }
            Console.ReadLine();
        }

        static private string DisplayMenuAndGetInChoice()
        {            
            Console.Clear();
            Console.WriteLine("Menu Options".ToUpper());
            Console.WriteLine("1 - Load Product Categories");
            Console.WriteLine("2 - Load Products");
            Console.WriteLine("3 - Create and Save a Product Category");
            Console.WriteLine("4 - Create and Save a Product");
            Console.WriteLine("5 - Exit");
            Console.Write("What would you like to choose: ");

            string output = Console.ReadLine();

            return output;
        }
    }
}
