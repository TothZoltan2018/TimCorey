using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLibrary
{
    // It only joins two interfaces
    public interface IBorrowableBook : IBorrowable, IBook
    {        
    }
}
