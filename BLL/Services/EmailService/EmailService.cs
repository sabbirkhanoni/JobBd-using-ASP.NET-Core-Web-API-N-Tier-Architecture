using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.EmailService
{
    public class EmailService : IEmailService
    {
        public bool SendEmail(string to, string subject, string body)
        {
            try
            {
                var smtp = new SmtpClient("smtp.gmail.com", 587)
                {
                    Credentials = new NetworkCredential(
                        "youremail@gmail.com",
                        "yourpassword"
                    ),
                    EnableSsl = true
                };

                var mail = new MailMessage
                {
                    From = new MailAddress("youremail@gmail.com", "JobBD Support"),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true
                };

                mail.To.Add(to);
                smtp.Send(mail);
                return true;
            }
            catch
            {
                return false;
            }
        }
      }
    }
