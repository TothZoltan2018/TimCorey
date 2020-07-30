using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLibrary
{
    public class Emailer : IMessageSender
    {
        public void SendEmail(Person person, string message)
        {
            Console.WriteLine($"Simulating sending an email to { person.EmailAddress }");
        }
    }
}
