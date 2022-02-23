using LimaShop.Notification.ViewModel;
using System.Net;
using System.Net.Mail;

namespace LimaShop.Notification.Services
{
    public class NotificationService : INotificationService
    {
        private readonly string EMAIL_ORIGEM = "ll5176418@gmail.com";
        private readonly string EMAIL_SENHA = "91285912";

        public async Task SendAsync(string subject, string content, string toEmail, string toName)
        {
            var bodyEmail = new BodyEmail(content, "event", toName);

            using (var mensagemDeEmail = new MailMessage())
            {
                mensagemDeEmail.From = new MailAddress(EMAIL_ORIGEM);

                mensagemDeEmail.Subject = subject;
                mensagemDeEmail.To.Add(toEmail);
                mensagemDeEmail.IsBodyHtml = true;
                mensagemDeEmail.Body = bodyEmail.ToString();

                using (var smtpClient = new SmtpClient())
                {
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.Credentials = new NetworkCredential(EMAIL_ORIGEM, EMAIL_SENHA);
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtpClient.Host = "smtp.gmail.com";
                    smtpClient.Port = 587;
                    smtpClient.EnableSsl = true;
                    smtpClient.Timeout = 30000;

                    try
                    {

                        await smtpClient.SendMailAsync(mensagemDeEmail);
                    }
                    catch (SmtpException e)
                    {
                        System.Console.WriteLine();
                    }
                }
            }
        }

    }
}
