using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// namespace OCPLibrary.Accounts
namespace OCPLibrary
{
    public class TechnicianAccounts : IAccounts
    {
        public EmployeeModel Create(IApplicantModel person)
        {
            EmployeeModel output = new EmployeeModel();

            output.FirstName = person.FirstName;
            output.LastName = person.LastName;
            // Email domain is different for technicians
            output.EmailAddress = $"{ person.FirstName.Substring(0, 1) }{person.LastName}@acmetech.com";

            return output;
        }
    }
}

