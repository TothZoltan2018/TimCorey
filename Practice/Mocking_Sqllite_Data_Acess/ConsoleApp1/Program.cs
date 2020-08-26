using MyLibrary;
using MyLibrary.Logic;
using MyLibrary.Models;
using MyLibrary.Utilities;
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
                        
            IProductCategoryValidator productCategoryValidator = new ProductCategoryValidator();
            IProductValidator productValidator = new ProductValidator();

            IUserInterface userInterface = new UserInterface();

            InventoryHandler inventoryHandler = new InventoryHandler(sqLiteDataAccess, productCategoryValidator, productValidator, userInterface);

            inventoryHandler.CreateDBAndTables();
 
            string choice;
            ProductCategoryModel productCategory = new ProductCategoryModel();
            ProductModel product = new ProductModel();

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
                        var ValidatedProductCategory = inventoryHandler.CreateModel<ProductCategoryModel>();
                        if (ValidatedProductCategory.Item2 == true)
                        {
                            inventoryHandler.SaveModel<ProductCategoryModel>(ValidatedProductCategory.Item1);
                            Console.WriteLine("Model is created and it is saved to database.");
                        }
                        else 
                        {
                            Console.WriteLine("Invalid model created and it is not saved to database.");
                        }
                        
                        break;
                    case "4":                        
                        var ValidatedProduct = inventoryHandler.CreateModel<ProductModel>();
                        
                        // Todo this might be in generic method.
                        if (ValidatedProduct.Item2 == true)
                        {
                            inventoryHandler.SaveModel<ProductModel>(ValidatedProduct.Item1);
                            Console.WriteLine("Model is created and it is saved to database.");
                        }
                        else
                        {
                            Console.WriteLine("Invalid model created and it is not saved to database.");
                        }
                        
                        break;
                    case "5":
                        DeleteDataBase(inventoryHandler, "Are you sure to delete all data? (y/n)");                        
                        break;
                    case "6":
                        Console.WriteLine("Thanks for using this application");
                        break;
                    default:
                        Console.WriteLine("That was an invalid choice. Hit enter and try again.");
                        break;
                }
                Console.WriteLine("Hit return to continue...");
                Console.ReadLine();

            } while (choice != "6");
        }

        private static void DeleteDataBase(InventoryHandler inventoryHandler, string question)
        {
            string answer = GetInAnswer(question);

            if (answer == "y")
            {                   
                answer = GetInAnswer("By pressing y/Y the database with all data will be deleted permanently! \nAre you sure to continue?");
                if (answer == "y")
                {                        
                    inventoryHandler.DeleteDB();                     
                }                   
            }
        }

        private static string GetInAnswer(string question)
        {
            Console.WriteLine(question);
            string answer = Console.ReadLine().ToLower();
            return answer;
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
        }

        static private string DisplayMenuAndGetInChoice()
        {            
            Console.Clear();
            Console.WriteLine("Menu Options".ToUpper());
            Console.WriteLine("1 - Load Product Categories");
            Console.WriteLine("2 - Load Products");
            Console.WriteLine("3 - Create and Save a Product Category");
            Console.WriteLine("4 - Create and Save a Product");
            Console.WriteLine("5 - Delete database");
            Console.WriteLine("6 - Exit");
            Console.Write("What would you like to choose: ");

            string output = Console.ReadLine();

            return output;
        }
    }
}
