using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCPLibrary
{
    public class ExecutiveAccounts : IAccounts
    {
        public EmployeeModel Create(IApplicantModel person)
        {
            EmployeeModel output = new EmployeeModel();

            output.FirstName = person.FirstName;
            output.LastName = person.LastName;
            // Email domain is different for executive
            output.EmailAddress = $"{ person.FirstName}{person.LastName}@acmecorp.com";

            // This is new setting for executive
            output.IsManager = true;
            output.IsExecutive = true;

            return output;
        }
    }
}
