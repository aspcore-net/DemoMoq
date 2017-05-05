using DemoMoq.Models.Interfaces;

namespace DemoMoq.Models
{
    public class DefaultMailer : IMailer
    {
        public string From { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

        public bool SendMail(IMailClient mailClient)
        {
            return mailClient.SendMail(From, To, Subject, Body);
        }
    }
}