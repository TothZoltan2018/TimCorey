namespace DemoLibrary
{
    public interface IChore
    {
        string ChoreName { get; set; }
        double HoursWorked { get; }
        bool IsComplete { get; }
        Person Owner { get; set; }

        void CompleteChore();
        void PerformedWork(double hours);
    }
}