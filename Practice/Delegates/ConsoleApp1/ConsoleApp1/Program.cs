using EmployeeLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<EmployeeModel> employees = new List<EmployeeModel>()
            {
                { new EmployeeModel { ID = 1, FirstName = "Zoltan", LastName = "Toth", Age = 43, IsMarried = true, Level = JobLevel.fellow, Location = WorkLocation.Hungary, NumberOfChildren = 2 } },
                { new EmployeeModel { ID = 2, FirstName = "Sarah", LastName = "Connor", Age = 50, IsMarried = false, Level = JobLevel.senior, Location = WorkLocation.US, NumberOfChildren = 0} },
                { new EmployeeModel { ID = 3, FirstName = "Bill", LastName = "Doe", Age = 22, IsMarried = true, Level = JobLevel.junior , Location = WorkLocation.Germany, NumberOfChildren = 1 } },
                { new EmployeeModel { ID = 4, FirstName = "Sue", LastName = "Wood", Age = 33, IsMarried = true, Level = JobLevel.mediore, Location = WorkLocation.Hungary, NumberOfChildren = 5 } },
            };

            HolidayCalculatorModel holidayCalculatorModel = new HolidayCalculatorModel();
            // Set the Employee's list to the library
            holidayCalculatorModel.Employees = employees;

            // ########### First way to calculate holidays  ########### 
            holidayCalculatorModel.CalculateAnnualHolidaysForEmployeeWithDelegate(calculate, 2);
            //The following to lines behaves the same
            holidayCalculatorModel.DisplayNumberOfHolidays(ShowHolidays, 2);
            holidayCalculatorModel.DisplayNumberOfHolidays(Console.WriteLine, 2);
            // ########### An other way to calculate holidays  ########### 
            holidayCalculatorModel.CalculateAnnualHolidaysForEmployeeWithFunc(calculate2, 2);
            holidayCalculatorModel.DisplayNumberOfHolidays(ShowHolidays, 2);
            // ########### The same way as before to calculate holidays but with anonymous method ########### 
            holidayCalculatorModel.CalculateAnnualHolidaysForEmployeeWithFunc(x => {
                switch (x.Location)
                {
                    case WorkLocation.US:
                        return x.AnnualHolidays = 20;
                    case WorkLocation.Germany:
                        return x.AnnualHolidays = 30;
                    case WorkLocation.Hungary:
                        return x.AnnualHolidays = 40;
                    default:
                        return x.AnnualHolidays = 0;
                }
            } , 2);
            holidayCalculatorModel.DisplayNumberOfHolidays(ShowHolidays, 2);

            Console.ReadLine();
        }

        private static int calculate2(EmployeeModel e)
        {
            switch (e.Location)
            {
                case WorkLocation.US:
                    return e.AnnualHolidays = 20;
                case WorkLocation.Germany:
                    return e.AnnualHolidays = 30;
                case WorkLocation.Hungary:
                    return e.AnnualHolidays = 40;
                default:
                    return e.AnnualHolidays = 0;                    
            }            
        }

        private static int calculate(EmployeeModel e)
        {
            const int BaseHoliday = 15;

            int ageBasedHolidays = 0;
            if (e.Age > 30)
            {
                ageBasedHolidays = 2;
            }
            else if (e.Age > 40)
            {
                ageBasedHolidays = 4;
            }
            else if (e.Age > 50)
            {
                ageBasedHolidays = 6;
            }

            int marriageBasedHolidays = 0;
            if (e.IsMarried)
            {
                marriageBasedHolidays = 2;
            }

            return BaseHoliday + ageBasedHolidays + marriageBasedHolidays;
        }

        private static void ShowHolidays(string employeeIdAndHolidaysText)
        {
            // Do something...
            // Do something...
            Console.WriteLine(employeeIdAndHolidaysText + " Special to Console UI");
        }


    }
}
