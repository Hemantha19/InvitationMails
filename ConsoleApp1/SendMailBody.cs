using System;
using System.Configuration;
using System.Data;
using System.IO;
using System.Net.Mail;

namespace InvitationMail
{
    public  class SendMailBody
    {
        public string title;
        public string surname;
        public string payoutamount;
        public string annualpremium;
        public string Firstname;
        public string Productname;

        public string PopulateBody(string title, string Firstname, string surname, string productname, string payoutamount, string annualpremium)
        {
            string body = string.Empty;
            //string title; 
            //string Firstname, string surname, string productname, string payoutamount, string annualpremium
            string FileSaveWithPath = "C:\\Users\\heman\\source\\repos\\ConsoleApp1\\ConsoleApp1\\MailBody.html";

            using (StreamReader reader = new StreamReader(FileSaveWithPath))
            {
                body = reader.ReadToEnd();
            }
            body = body.Replace("{{TodayDate}}", DateTime.Now.ToShortDateString());
            body = body.Replace("{{Title}}", title);
            body = body.Replace("{{FirstName}}", Firstname);
            body = body.Replace("{{Surname}}", surname);
            string name = Firstname + "" + surname;
            body = body.Replace("{{Name}}", name);
            body = body.Replace("{{ProductName}}", productname);
            body = body.Replace("{{PayOutAmount}}", payoutamount);
            body = body.Replace("{{AnualPremium}}", annualpremium);
            double creditcharge = Convert.ToDouble(annualpremium) * 0.05;
            creditcharge = Math.Round(creditcharge, 2, MidpointRounding.ToEven);
            body = body.Replace("{{CreditCharge}}", creditcharge.ToString());
            double totalpremium = Convert.ToDouble(annualpremium) + creditcharge;
            body = body.Replace("{{TotalPremium}}", totalpremium.ToString());
            decimal averagemonthpremium = Convert.ToDecimal(totalpremium) / 12;
            // averagemonthpremium = Math.Round(averagemonthpremium,2, MidpointRounding.ToEven);
            string inti = Convert.ToString(averagemonthpremium); // Convert to string
            int length = inti.Substring(inti.IndexOf(".") + 1).Length;
            if (length > 2)
            {
                decimal othermonth = Math.Round(averagemonthpremium, 2, MidpointRounding.ToEven);
                decimal _initialMonth = Convert.ToDecimal(totalpremium) - (othermonth * 11);
                body = body.Replace("{{OtherMonthlyPaymentsAmount}}", (othermonth).ToString());
                body = body.Replace("{{InitialMonthlyPaymentAmount}}", _initialMonth.ToString());
            }
            else
            {
                decimal othermonths = Convert.ToDecimal(averagemonthpremium);
                body = body.Replace("{{OtherMonthlyPaymentsAmount}}", othermonths.ToString());
                body = body.Replace("{{InitialMonthlyPaymentAmount}}", othermonths.ToString());
                //Console.WriteLine(othermonths);
            }
            return body;
        }
        public static MailMessage Createmessage(DataRow d)
        {
            MailMessage mail = new MailMessage();
            MailAddress sender = new MailAddress(ConfigurationManager.AppSettings["smtpUser"]);
            MailAddress receiver = new MailAddress("hemantha.pendyala@gmail.com");
            mail.From = sender;
            mail.To.Add(receiver);
            SendMailBody sm = new SendMailBody();
            mail.Body = sm.PopulateBody(d[1].ToString(), d[2].ToString(), d[3].ToString(), d[4].ToString(), d[5].ToString(), d[6].ToString());
            mail.IsBodyHtml = true;
            return mail;
        }
    }
}
