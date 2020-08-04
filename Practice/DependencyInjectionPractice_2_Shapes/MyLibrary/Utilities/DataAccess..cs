using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Utilities
{
    public class DataAccess : IDataAccess
    { 
        public string ReadIn()
        {
            return Console.ReadLine();        
        }

        public void WriteOut(string message)
        {
            Console.WriteLine($"Printout from MessageToConsole class: {message}");
        }
    }
}
