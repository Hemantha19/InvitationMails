using System;
using System.Data;
using System.Net.Mail;
using System.Configuration;

namespace InvitationMail
{
    class Program
    {
        static void Main(string[] args)
        {
            DataTable csvData = CustomerExcel.ReadCsvFile();
            foreach (DataRow d in csvData.Rows)
            {
                MailMessage mail = SendMailBody.Createmessage(d);
                SmtpClient smtp = new SmtpClient()
                {
                    Host = ConfigurationManager.AppSettings["smtpServer"],
                    Port = Convert.ToInt32(ConfigurationManager.AppSettings["smtpPort"]),
                    EnableSsl = true,
                    Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["smtpUser"], ConfigurationManager.AppSettings["smtpPass"])
                };
                Console.WriteLine("Sending Email......");
                smtp.Send(mail);
                Console.WriteLine("Email Sent.");
            }
        }

        }
    }

