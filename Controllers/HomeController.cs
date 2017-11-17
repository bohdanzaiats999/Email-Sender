using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApplication5.Models;
namespace WebApplication5.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult SendEmail()
        {
                //From Address  
                string FromAddress = "bohdan2131@gmail.com";
                string FromAdressTitle = "Email from bohdan2131";
                //To Address  
                string ToAddress = "bohdanzaiats999@gmail.com";
                string ToAdressTitle = "Microsoft ASP.NET Core";
                string Subject = "Hello World";
                string BodyContent = "This is Email sender created the greatest man - Bohdan Zaiats";

                //Smtp Server  
                string SmtpServer = "smtp.gmail.com";
                //Smtp Port Number  
                int SmtpPortNumber = 587;

                var mimeMessage = new MimeMessage();
                mimeMessage.From.Add(new MailboxAddress(FromAdressTitle, FromAddress));
                mimeMessage.To.Add(new MailboxAddress(ToAdressTitle, ToAddress));
                mimeMessage.Subject = Subject;
                mimeMessage.Body = new TextPart("plain")
                {
                    Text = BodyContent
                };

                using (var client = new SmtpClient())
                {

                    client.Connect(SmtpServer, SmtpPortNumber, false);   
                    client.Authenticate("bohdan2131@gmail.com", "bohdan123");
                    client.Send(mimeMessage);
                    client.Disconnect(true);
                }
            
            return View();
        }


        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
