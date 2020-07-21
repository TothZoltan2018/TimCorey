using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLibrary
{
    public interface IDVD : ILibraryItem
    {        
        List<string> Actors { get; set; }        
        // This is not violating DRY. This RuntimeInMinutes is different from an Audiobook's RuntimeInMinutes.
        int RuntimeInMinutes { get; set; }

    }
}
