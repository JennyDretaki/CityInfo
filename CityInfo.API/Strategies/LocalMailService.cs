namespace CityInfo.API.Strategies
{
    public class LocalMailService : IMailService
    {
        private string _mailFrom = "noreply@cityinfo.be";
        private string _mailTo = "admin@cityinfo.be";

        public void Send(string subject, string message)
        {
            // Send mail - output to console
            Console.WriteLine($"Mail from {_mailFrom} to {_mailTo}, " +
                $"with {nameof(LocalMailService)}.");
            Console.WriteLine($"Subject: {subject}");
            Console.WriteLine($"Message: {message}");
        }

    }

}
