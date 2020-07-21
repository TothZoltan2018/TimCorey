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
        /// ISP: The client should not be forced to depend on intefaces they don't use.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            IBorrowableDVD dvd = new DVD();
                        
            Console.ReadLine();
        }
    }
}
