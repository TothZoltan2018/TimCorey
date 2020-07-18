using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCPLibrary
{
    public class ManagerAccounts : IAccounts
    {
        public EmployeeModel Create(IApplicantModel person)
        {
            EmployeeModel output = new EmployeeModel();

            output.FirstName = person.FirstName;
            output.LastName = person.LastName;
            // Email domain is different for managers
            output.EmailAddress = $"{ person.FirstName.Substring(0, 1) }{person.LastName}@acmecorp.com";

            // This is new setting for managers
            output.IsManager = true;

            return output;
        }
    }
}
