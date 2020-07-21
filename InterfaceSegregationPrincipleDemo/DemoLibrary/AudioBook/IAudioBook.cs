using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLibrary
{
    public interface IAudioBook : ILibraryItem //, IBorrowable // There might be not borrowable audiobooks, too
    {
        int RuntimeInMinutes { get; set; }
    }
}
