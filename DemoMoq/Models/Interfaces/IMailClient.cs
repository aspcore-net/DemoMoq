namespace DemoMoq.Models.Interfaces
{
    public interface IMailClient
    {
        string Server { get; set; }
        string Port { get; set; }

        bool SendMail(string from, string to, string subject, string body);
    }
}
