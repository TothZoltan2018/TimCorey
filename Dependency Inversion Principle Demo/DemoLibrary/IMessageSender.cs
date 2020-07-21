namespace DemoLibrary
{
    public interface IMessageSender
    {
        void SendMessage(IPerson person, string message);
    }
}