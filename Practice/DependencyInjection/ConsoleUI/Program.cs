using DemoLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;

namespace ConsoleUI
{
    /// <summary>
    /// This was the demo code start state for Dependency Inversion. I am going to refactor the code and apply Autofac for Dep. Injection.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var container = AutoFacContainer.Configure();

            using (var scope = container.BeginLifetimeScope())
            {
                var owner = (Person)scope.Resolve<IPerson>();

                var chore = scope.Resolve<IChore>();

                owner.FirstName = "Zoli";
                owner.LastName = "Toth";
                owner.EmailAddress = "tz@gmail.com";
                owner.PhoneNumber = "123456789";

                chore.ChoreName = "Take out the trash";
                chore.Owner = owner;

                chore.PerformedWork(3);
                chore.PerformedWork(1.5);
                chore.CompleteChore();

            }

            Console.ReadLine();
        }
    }
}
