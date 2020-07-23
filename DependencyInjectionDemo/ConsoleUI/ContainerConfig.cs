using Autofac;
using DemoLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    public static class ContainerConfig
    {
        //IContainer: using AutoFac
        /// <summary>
        /// It configures the container
        /// </summary>
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            // ### Register one class ###
            // This is the simpliest version of registration: It registers the BusinessLogic:
            // Whenever we look for IBusinessLogic, it returns an instance of BusinessLogic
            builder.RegisterType<BusinessLogic>().As<IBusinessLogic>();            
            
            builder.RegisterType<Application>().As<IApplication>();

            // ### Register all classes in a folder ###
            // (Assembly: using System.Reflection.) In the 'Utilities' folder give me all classes,
            // register them and link them up to matching interface.
            builder.RegisterAssemblyTypes(Assembly.Load(nameof(DemoLibrary)))
                .Where(t => t.Namespace.Contains("Utilities"))
                .As(t => t.GetInterfaces().FirstOrDefault(i => i.Name == "I" + t.Name));

            // This builds the container. Container: a place to store the definitions. Key-value pair list of
            // classes we want to instantiate.
            return builder.Build();
        }
    }
}
