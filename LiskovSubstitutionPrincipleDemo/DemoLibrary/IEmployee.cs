namespace DemoLibrary
{
    // Here are the tings common in all
    public interface IEmployee
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        decimal Salary { get; set; }

        void CalculatePerHourRate(int rank);
    }
}