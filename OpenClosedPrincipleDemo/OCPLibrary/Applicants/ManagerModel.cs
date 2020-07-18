using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCPLibrary
{
    // We can put ManagerModel to the List<IApplicantModel> in Pogram.Main() because of the IApplicantModel interface
    public class ManagerModel : IApplicantModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }        
        public IAccounts AccountProcessor { get; set; } = new ManagerAccounts(); 
    }
}
