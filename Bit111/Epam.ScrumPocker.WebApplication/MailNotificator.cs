using Epam.ScrumPocker.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;

namespace Epam.ScrumPocker.WebApplication
{
    public class MailNotificator : INotificator
    {
        public void Notify(Domain.User user, string link)
        {
            //4rf%TG6yh
            //scrumpockernotificator@gmail.com

            SmtpClient client = new SmtpClient();
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            client.Timeout = 10000;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential("scrumpockernotificator@gmail.com", "4rf%TG6yh");

            MailMessage mm = new MailMessage("scrumpockernotificator@gmail.com", user.Email, 
                "Scrum pocker round", link);
            mm.BodyEncoding = UTF8Encoding.UTF8;
            mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

            client.Send(mm);
        }
    }
}