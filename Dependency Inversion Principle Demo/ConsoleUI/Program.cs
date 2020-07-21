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
        /// DI: High level modules (the ones call something else) should not depend on low level (the called) modules. 
        /// Rather both should depend on abstractions and those abstractions should not depend on details.
        /// This needs to be inverted.
        /// 
        /// The many of "new" keywords indicates violating DI. Instead centrailze them into one place.
        /// 
        /// One way of achicing DI is Dependency INJECTION.
        /// 
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //IPerson owner = new Person
            //{
            //    FirstName = "Tim",
            //    LastName = "Corey",
            //    EmailAddress = "tim@iamtimcorey.com",
            //    PhoneNumber = "555-1212"
            //};

            IPerson owner = Factory.CreatePerson(); // We use interfaces instead of actual implementatons and use Factory to get it.
            owner.FirstName = "Tim";
            owner.LastName = "Corey";
            owner.EmailAddress = "tim@iamtimcorey.com";
            owner.PhoneNumber = "555-1212";

            //Chore chore = new Chore
            //{
            //    ChoreName = "Take out the trash",
            //    Owner = owner
            //};

            IChore chore = Factory.CreateChore(); // We use interfaces instead of actual implementatons and use Factory to get it.
            chore.ChoreName = "Take out the trash";
            chore.Owner = owner;

            chore.PerformedWork(3);
            chore.PerformedWork(1.5);
            chore.CompleteChore();

            Console.ReadLine();
        }
    }
}
