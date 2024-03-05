using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace EMAIL_SENDER
{
    public class Email
    {
        public string address;
        public string password;

        public void sendEmail(string body)
        {
            try
            {
                MailMessage message = new MailMessage();
                SmtpClient client = new SmtpClient("smtp.gmail.com");

                message.From = new MailAddress(address, address);
                message.To.Add(address);

                message.Subject = "Cursor Position";
                message.Body = body;

                client.EnableSsl = true;

                client.UseDefaultCredentials = false;

                client.Credentials = new NetworkCredential(address, password);

                client.Port = 587;

                client.Send(message);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
