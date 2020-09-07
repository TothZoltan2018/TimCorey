using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using MyLibrary.Utilities.DataAccess;
using MyLibrary.Utilities.Validators;

namespace MyLibrary.Utilities
{
    class AutoFacContainer
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<Logic.InventoryHandler>().As<Logic.IInventoryHandler>();
            builder.RegisterType<SqLiteDataAccess>().As<ISqLiteDataAccess>();
            builder.RegisterType<ProductCategoryValidator>().As<IProductCategoryValidator>();
            builder.RegisterType<ProductValidator>().As<IProductValidator>();

            return builder.Build();
        }
    }
}
