using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using MyLibrary.Utilities.DataAccess;
using MyLibrary.Utilities.Validators;
using MyLibrary.Logic;

namespace ConsoleApp1
{
    public class AutoFacContainer
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<InventoryHandler>().As<IInventoryHandler>();
            builder.RegisterType<SqLiteDataAccess>().As<ISqLiteDataAccess>();
            builder.RegisterType<ProductCategoryValidator>().As<IProductCategoryValidator>();
            builder.RegisterType<ProductValidator>().As<IProductValidator>();
            builder.RegisterType<UserInterface>().As<MyLibrary.Utilities.IUserInterface>();

            builder.RegisterType<Application>().As<IApplication>();

            return builder.Build();
        }
    }
}
