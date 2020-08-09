using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using MyLibrary.Shapes;
using MyLibrary.Utilities;

namespace DependencyInjectionPractice_2_Shapes
{
    public class AutoFacContainer
    {
        public static IContainer Configrue()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<IShapes>().As<IShapes>();
            builder.RegisterType<Circle>().As<ICircle>();
            builder.RegisterType<Rectangle>().As<IRectangle>();
            builder.RegisterType<DataAccess>().As<IDataAccess>();
            
            builder.RegisterType<MyValidator>().As<IMyValidator>();

            //builder.RegisterAssemblyTypes(Assembly.Load(nameof(MyLibrary)))
            //    //.Where(t => t.Namespace.Contains("Shapes"))
            //    .As(t => t.GetInterfaces().FirstOrDefault(i => i.Name == "I" + t.Name));


            return builder.Build();
        }
    }
}
