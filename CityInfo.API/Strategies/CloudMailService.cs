namespace CityInfo.API.Strategies
{
    public class CloudMailService : IMailService
    {
        private string _mailFrom = "noreply@cityinfo.be";
        private string _mailTo = "admin@cityinfo.be";

        public void Send(string subject, string message)
        {
            // Logic to send email using cloud service
            Console.WriteLine($"Sending email from {_mailFrom} to {_mailTo}, " +
                $"with {nameof(CloudMailService)}.");
            Console.WriteLine($"Subject: {subject}");
            Console.WriteLine($"Message: {message}");
        }
    }
}
