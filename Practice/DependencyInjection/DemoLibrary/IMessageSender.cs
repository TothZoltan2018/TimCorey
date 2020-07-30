namespace DemoLibrary
{
    public interface IMessageSender
    {
        void SendEmail(Person person, string message);
    }
}