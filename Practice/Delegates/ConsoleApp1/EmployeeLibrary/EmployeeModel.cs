using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeLibrary
{
    public class EmployeeModel
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
       // public string MiddleName { get; set; }
        public bool IsMarried { get; set; }
        public int Age { get; set; }
        public WorkLocation Location { get; set; }
        public JobLevel Level { get; set; }
        public int NumberOfChildren { get; set; }
        public int AnnualHolidays { get; set; } = 0;
    }

    public enum JobLevel
    {
        junior, mediore, senior, principal, fellow
    }

    public enum WorkLocation 
    {
        US, Germany, Hungary
    }
}
