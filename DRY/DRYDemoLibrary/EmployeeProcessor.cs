using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRYDemoLibrary
{
    public class EmployeeProcessor
    {
        public string GenerateEmployeeID(string firstName, string lastName)
        {
            string employeeId = $@"{ firstName.Substring(0, 4) }{ lastName.Substring(0, 4) }{ DateTime.Now.Millisecond }";
            return employeeId;
        }
    }
}
