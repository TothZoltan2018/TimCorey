using Autofac;
using MyLibrary.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectionPractice_2_Shapes
{
    public class Program
    {
        static void Main(string[] args)
        {
            var container = AutoFacContainer.Configrue();

            using (var scope = container.BeginLifetimeScope())
            {
                var circle = scope.Resolve<MyLibrary.Shapes.ICircle>();

                circle.CalculateArea();
                circle.CalculatePerimeter();

                var rectangle = scope.Resolve<MyLibrary.Shapes.IRectangle>();

                rectangle.CalculateArea();
                rectangle.CalculatePerimeter();
            }

            Console.ReadLine();
        }
    }
}
