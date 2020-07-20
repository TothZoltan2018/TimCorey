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
        static void Main(string[] args)
        {
            Manager accountingVP = new Manager();

            accountingVP.FirstName = "Emma";
            accountingVP.LastName = "Stone";
            accountingVP.CalculatePerHourRate(4);

            //Employee emp = new Employee(); //LSP says, new Manager() can be used instead of new Employee()
            // Of course the CalaculatePerHourRate() method will work differently, but the Manager cannot
            // Throw exception where the Employee would not have.
            // Employee emp = new Manager(); // This works fine

            // Covariants: return type of a method cannot change. 
            // Contravariants Cannot change the parameters type.

            // Also, cannot strengthen preconditions in the child class. Eg. Introduce an input parameter check in a method of the Manager class
            // Also, cannot Weaken postconditions in the child class. Eg. a method of the Manager class cannot return values in wider range than
            // the method of the Employee class (if it would have limited).

            // So actually a Manager is not really an Employee, because of not having Manager property and method. Therefore inheritance is not the best way.

            Employee emp = new CEO(); // This throws exception

            emp.FirstName = "Tim";
            emp.LastName = "Corey";
            emp.AssignManager(accountingVP); // Throwa exception for CEO 
            emp.CalculatePerHourRate(2);

            Console.WriteLine($"{ emp.FirstName }'s salary is ${ emp.Salary }/hour.");

            Console.ReadLine();
        }
    }
}
