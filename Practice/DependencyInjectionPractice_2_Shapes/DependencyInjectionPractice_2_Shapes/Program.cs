using Autofac;
using MyLibrary.Shapes;
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
                var dataAccess = scope.Resolve<IDataAccess>();
                var myValidator = scope.Resolve<IMyValidator>();

                dataAccess.WriteOut($"Please enter the radius of the circle");
                double radiusValue = myValidator.GetNumberFromString(dataAccess.ReadIn());
                var circle = scope.Resolve<ICircle>(new NamedParameter("radius", radiusValue));
                double area = circle.CalculateArea();
                double perimerter = circle.CalculatePerimeter();
                PrintoutCalculationResults(dataAccess, circle, area, perimerter);
                Console.WriteLine();


                dataAccess.WriteOut($"Please enter one side of the rectangle");
                double sideAValue = myValidator.GetNumberFromString(dataAccess.ReadIn());
                dataAccess.WriteOut($"Please enter the other side of the rectangle");
                double sideBValue = myValidator.GetNumberFromString(dataAccess.ReadIn());
                var rectangle = scope.Resolve<IRectangle>(
                    new NamedParameter("sideA", sideAValue),
                    new NamedParameter("sideB", sideBValue)
                    );
                area = rectangle.CalculateArea();
                perimerter = rectangle.CalculatePerimeter();
                PrintoutCalculationResults(dataAccess, rectangle, area, perimerter);
            }

            Console.ReadLine();
        }

        private static void PrintoutCalculationResults(IDataAccess dataAccess, IShapes shape, double area, double perimeter)
        {
            dataAccess.WriteOut($"The Area of the {shape.GetType().Name} is: {area}");
            dataAccess.WriteOut($"The Perimeter of the {shape.GetType().Name} is: {perimeter}");
        }

        //private static void PrintoutForInputtingData(IDataAccess dataAccess, string shape)
        //{
        //    if (shape == "circle")
        //    {
        //        dataAccess.WriteOut($"Please enter the radius of the {shape}");
        //    }
        //    else if (shape == "rectangle")
        //    {
        //        dataAccess.WriteOut($"Please enter the side of the  {shape}");
        //    }                
        //}

    }
}
           //switch (nameof(shape))
           // {
           //     circle:
           //         dataAccess.WriteOut($"Please enter the radius of the {nameof(shape)} is:}");
           //     break;
           //     default:
           //         break;
           // }