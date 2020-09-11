using MyLibrary.Logic;
using MyLibrary.Models;
using MyLibrary.Utilities;
using MyLibrary.Utilities.DataAccess;
using MyLibrary.Utilities.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Application : IApplication
    {
        IInventoryHandler inventoryHandler;
        ProductCategoryModel productCategory = new ProductCategoryModel();
        ProductModel product = new ProductModel();
                
        public Application(IInventoryHandler inventoryHandler)
        {
            this.inventoryHandler = inventoryHandler;
        }

        public void RunApp()
        {
            inventoryHandler.CreateDBAndTables();
            string choice;

            do
            {
                choice = DisplayMenuAndGetInChoice();

                switch (choice)
                {
                    case "1":
                        inventoryHandler.DisplayTable<ProductCategoryModel>(inventoryHandler.LoadModel<ProductCategoryModel>(productCategory));
                        break;
                    case "2":
                        inventoryHandler.DisplayTable<ProductModel>(inventoryHandler.LoadModel<ProductModel>(product));
                        break;
                    case "3":
                        (ProductCategoryModel, bool) ValidatedProductCategory = inventoryHandler.CreateModel<ProductCategoryModel>();
                        SaveOnlyIfValidModel((InventoryHandler)inventoryHandler, ValidatedProductCategory);
                        break;
                    case "4":
                        ///For console UI extra validation is needed because user can enter anything which might not be in database
                        ///In WPF a combobox can only contains values which is loaded from database.
                        (ProductModel, bool) ValidatedProduct = inventoryHandler.CreateModel<ProductModel>();

                        SaveOnlyIfValidModel((InventoryHandler)inventoryHandler, ValidatedProduct);
                        break;
                    case "5":
                        DeleteDataBase((InventoryHandler)inventoryHandler, "Are you sure to delete all data? (y/n)");
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

        private static void SaveOnlyIfValidModel<T>(InventoryHandler inventoryHandler, (T, bool) ValidatedModel)
        {
            if (ValidatedModel.Item2 == true)
            {
                inventoryHandler.SaveModel<T>(ValidatedModel.Item1);
                Console.WriteLine($"{ValidatedModel.Item1.GetType().Name} is created and it is saved to database.");
            }
            else
            {
                Console.WriteLine($"Invalid {ValidatedModel.Item1.GetType().Name} created and it is NOT saved to database.");
            }
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

        ///// Displays a Generic List.        
        //private static void DisplayDBTable<T>(T list) where T : class, IEnumerable, new()
        //{            
        //    //this is a list of type, not a type. How to get the type?
        //    foreach (var item in list)
        //    {                
        //        PropertyInfo[] propertyInfoArr = item.GetType().GetProperties();
        //        for (int i = 0; i < propertyInfoArr.Length; i++)
        //        {                    
        //            // ################## Wow! #####################
        //            Console.WriteLine($"{propertyInfoArr[i].Name}: {propertyInfoArr[i].GetValue(item)}");
        //        }

        //        Console.WriteLine();
        //    }            
        //}

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
