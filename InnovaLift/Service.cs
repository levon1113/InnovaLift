using MimeKit;
using System.Net.Mail;
using System.Net;
using InnovaLift.Models;

namespace SendMail
{
    public class Service
    {
        private readonly ILogger<Service> logger;
        public Service(ILogger<Service> logger)
        {
            this.logger = logger;
        }


        public void SendEmail(EmailModel Model)
        {


            try
            {

                var message = new MimeMessage();
                message.From.Add(new MailboxAddress(Model.Name, Model.Email));
                message.To.Add(new MailboxAddress("Recipient Name", "hayks.ghukasyan29@gmail.com"));

                var builder = new BodyBuilder();
                builder.TextBody = Model.Message;

                message.Body = builder.ToMessageBody();

                using (MailKit.Net.Smtp.SmtpClient client = new MailKit.Net.Smtp.SmtpClient())
                {
                    client.Connect("smtp.gmail.com", 587, false);
                    client.Authenticate("fermanyanlevon@gmail.com", "xpjgizejiifqhegd");

                    client.Send(message);
                    client.Disconnect(true);
                }

                logger.LogInformation("Success");

            }
            catch (Exception e)
            {
                logger.LogError(e.GetBaseException().Message);

            }


        }
    }
}
