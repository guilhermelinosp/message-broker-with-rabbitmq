namespace Producer.API.Services.Interfaces
{
    public interface IMessageProducer
    {
        public void SendMessage<T>(T message);

    }
}
