using MyLibrary.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class UserInterface : IUserInterface
    {
        public object ReadInFromUser()
        {
            return Console.ReadLine();
        }

        public void WriteOutToUser(string message)
        {
            Console.WriteLine(message);
        }
    }
}
