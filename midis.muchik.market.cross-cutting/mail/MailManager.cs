using Microsoft.Extensions.Configuration;
using midis.muchik.market.crosscutting.interfaces;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Reflection;

namespace midis.muchik.market.crosscutting.mail
{
    public class MailManager : IMailManager
    {
        private readonly IConfiguration _configuration;

        public MailManager(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void SendMail(string pathMailing, string mailRecipients, Dictionary<string, string> valuesMailing)
        {
            var sendGridApiKey = _configuration.GetValue<string>("SendGridConfig:SecretKey");
            var sendGridMailFrom = _configuration.GetValue<string>("SendGridConfig:MailFrom");

            var sendGridClient = new SendGridClient(sendGridApiKey);
            
            var fromEmail = new EmailAddress(sendGridMailFrom);
            var subjectEmail = "Muchik Market | Cambiar Contraseña";

            var tosMail = new List<EmailAddress>();
            var mailRecipientsArray = mailRecipients.Split(';');
            foreach (var mailRecipient in mailRecipientsArray)
            {
                tosMail.Add(new EmailAddress(mailRecipient));
            }

            var messageHtml = GetTemplateMailing(pathMailing, valuesMailing);
            var messageSendGrid = MailHelper.CreateSingleEmailToMultipleRecipients(fromEmail, tosMail, subjectEmail, string.Empty, messageHtml);
            sendGridClient.SendEmailAsync(messageSendGrid).ConfigureAwait(false);
        }

        private string GetTemplateMailing(string path, Dictionary<string, string> valuesMailing)
        {
            var executableLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            if (executableLocation is not null)
            {
                var mailingLocation = Path.Combine(executableLocation, path);
                var sr = new StreamReader(mailingLocation);
                string htmlFromMailing = sr.ReadToEnd();
                sr.Close();

                foreach (var valueMailing in valuesMailing)
                {
                    htmlFromMailing = htmlFromMailing.Replace(valueMailing.Key, valueMailing.Value);
                }

                return htmlFromMailing;
            }

            return string.Empty;
        }
    }  
}
