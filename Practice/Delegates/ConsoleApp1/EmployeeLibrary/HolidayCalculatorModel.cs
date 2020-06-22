using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeLibrary
{
    public class HolidayCalculatorModel
    {
        public delegate int Calculate(EmployeeModel e);
        public List<EmployeeModel> Employees { get; set; } = new List<EmployeeModel>();
        EmployeeModel employee = new EmployeeModel();

        // Taking over a method to calculate number of holidays
        public int CalculateAnnualHolidaysForEmployee(Calculate calculate, int ID)
        {            
            employee = Employees.First(e => e.ID == ID);
            return employee.AnnualHolidays = calculate(employee);
            //return calculate(employee);            
        }

        public void DisplayNumberOfHolidays(Action<string> display, int ID)
        {
            employee = Employees.First(e => e.ID == ID);
            display($"Employee Id:{employee.ID} has {employee.AnnualHolidays} holidays per year.");
        }
        //private static void ShowHolidays(string employeeIdAndHolidaysText)
        //{
        //    Console.WriteLine(employeeIdAndHolidaysText);
        //}

    }
}
