using Autofac;
using MyLibrary.Utilities.DataAccess;

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
            var container = AutoFacContainer.Configure();
            using (var scope = container.BeginLifetimeScope())
            {
                //Todo: How to set dBName parameter. It only works because I gave a default value in the constructor.
                ISqLiteDataAccess sqLiteDataAccess = scope.Resolve<ISqLiteDataAccess>(new NamedParameter("dBName", "InventoryDB.sqlite"));
                IApplication app = scope.Resolve<IApplication>();

                app.RunApp();
            }
        }
    }
}
