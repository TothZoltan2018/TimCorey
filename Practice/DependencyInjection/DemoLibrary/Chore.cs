using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLibrary
{
    public class Chore
    {
        private ILogger _logger;
        private IMessageSender _messageSender;

        public string ChoreName { get; set; }
        public Person Owner { get; set; }
        public double HoursWorked { get; private set; }
        public bool IsComplete { get; private set; }
        public Chore(ILogger logger, IMessageSender messageSender)
        {
            _logger = logger;
            _messageSender = messageSender;
        }

        public void PerformedWork(double hours)
        {
            HoursWorked += hours;
            _logger.Log($"Performed work on { ChoreName }");
        }

        public void CompleteChore()
        {
            IsComplete = true;
                       
            _logger.Log($"Completed { ChoreName }");
            
            _messageSender.SendEmail(Owner, $"The chore { ChoreName } is complete.");
        }
    }
}
