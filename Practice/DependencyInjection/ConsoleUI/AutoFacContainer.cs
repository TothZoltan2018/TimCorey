using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using DemoLibrary;

namespace ConsoleUI
{
    class AutoFacContainer
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<Emailer>().As<IMessageSender>();

            //This goes over the DemoLibrary and registers all classes except the Emailer.
            builder.RegisterAssemblyTypes(Assembly.Load(nameof(DemoLibrary)))
                .Where(t => t.Name.Contains(nameof(Emailer)) == false)
                .As(t => t.GetInterfaces().FirstOrDefault(i => i.Name == "I" + t.Name));
            
            return builder.Build();
        }
    }
}
