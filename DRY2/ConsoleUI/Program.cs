using DRYDemoLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("What is your first name: ");
            string firstName = Console.ReadLine();

            Console.WriteLine("What is your last name: ");
            string lastName = Console.ReadLine();

            EmployeeProcessor processor = new EmployeeProcessor();
            string employeeID = processor.GenerateEmployeeID(firstName, lastName);

            Console.WriteLine($"Your employee id is: {employeeID}.");

            Console.ReadLine();
        }
    }
}
