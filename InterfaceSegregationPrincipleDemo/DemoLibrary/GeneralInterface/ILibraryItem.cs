using System;

namespace DemoLibrary
{
    public interface ILibraryItem
    {        
        string LibraryId { get; set; }
        string Title { get; set; }
        //string Author { get; set; }
        //DateTime BorrowDate { get; set; }
        //string Borrower { get; set; }
        //int CheckOutDurationInDays { get; set; }        
        //int Pages { get; set; }        

        //void CheckIn();
        //void CheckOut(string borrower);
        //DateTime GetDueDate();
    }
}