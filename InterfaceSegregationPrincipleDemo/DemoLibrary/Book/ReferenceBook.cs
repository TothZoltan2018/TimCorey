using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLibrary
{
    /// <summary>
    /// A referencebook cannot be boroowed.
    /// </summary>
    public class ReferenceBook : IBook
    {
        public string LibraryId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Pages { get; set; }
        //// This prop has no sense!
        //public int CheckOutDurationInDays { get; set; } = 0;
        //// This prop has no sense!
        //public string Borrower { get; set; }
        //public DateTime BorrowDate { get; set; }

        //// All these methods ar also not applicable!
        //public void CheckOut(string borrower)
        //{
        //    throw new NotImplementedException();
        //}

        //public void CheckIn()
        //{
        //    throw new NotImplementedException();
        //}

        //public DateTime GetDueDate()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
