namespace CityInfo.API.Strategies
{
    public interface IMailService
    {
        void Send(string subject, string message);
    }
}
