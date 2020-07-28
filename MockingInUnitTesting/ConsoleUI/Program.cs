using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    /// <summary>
    /// I installed .NET 4.7.0 as this Demo used that. I needed to reinstall System.Data.SQLite.Core Nuget package because 
    /// an exception was thrown stating not to find  sqlite dll.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var container = ContainerConfig.Configure();

            using (var scope = container.BeginLifetimeScope())
            {
                var app = scope.Resolve<IApplication>();
                app.Run();
            }
        }


    }
}
