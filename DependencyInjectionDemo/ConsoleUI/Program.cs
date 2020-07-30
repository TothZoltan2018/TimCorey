using Autofac;
using DemoLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    class Program
    {
        /// <summary>
        /// 1. We have created interfaces for classes we want to add to Dependency Inversion and 
        /// eventually to Dependency Injection system. (IDataAccess, ILogger, IBusinessLogic)
        /// 2. Stop depending on low level classes. ( In BusinessLogic class instead of new Logger() and new DataAccess() 
        /// take in instances in constructor. )
        /// 3. In the Program class now we need to pass in these two instances to BusinessLogic( , ). We could create a
        /// Factroy class for it. But we want to use the 'AutoFac' instead.
        /// 4. Install Nugetpackage to  ConsolUI 'AutoFac'
        /// 5. Container is like the Factroy: It creates the instances.
        /// We have created 'ContainerConfig' class to do it with 'AutoFac'.
        /// 6. Create  class'Application'. This will be the start of our application. We register this also in 'ContainerConfig.
        /// 7. See in Main()
        /// 
        /// 
        ///  
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //Original code:
            //BusinessLogic businessLogic = new BusinessLogic();
            //businessLogic.ProcessData();

            var container = ContainerConfig.Configure();

            using (var scope = container.BeginLifetimeScope())
            {
                // 7. 
                // I need an 'IApplication' object. (This is normally done once, at start.)
                // That is it gives an Application object. (See in the ContainerConfig class.)
                // It looks into the actual instance it is going to create. Is your constructor requires any object? Yes, it does: '(IBusinessLogic businessLogic)'
                // It looks up in the container to see what needed for 'BusinessLogic' instance. Needs any objects? Yes, it does:
                // '(ILogger logger, IDataAccess dataAccess'. Checks these two and see, that nothing is needed for them and creates them. And then can new up 
                // 'BusinessLogic' and then 'Application' instance.
                // Then it runs the 'ProcessData()' method and uses the already available 'Logger' and 'DataAccess' instances.
                var app = scope.Resolve<IApplication>();

                // Run() calls the 'businessLogic.ProcessData()' method. 'businessLogic' is taken in in the constructor: 'Application(IBusinessLogic businessLogic)'
                app.Run();

                // I don't really get why we need the Application class. We can do the same without it as below:
                var business = scope.Resolve<IBusinessLogic>();
                business.ProcessData();
            }


            Console.ReadLine();
        }
    }
}
