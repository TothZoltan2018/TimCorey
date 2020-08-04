using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Utilities
{
    public interface IDataAccess
    { 
        void WriteOut(string message);
        string ReadIn();
    }
}
