using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Utilities
{
    public interface IUserInterface
    {
        object ReadInFromUser();

        void WriteOutToUser(string message);
    }

    
}
