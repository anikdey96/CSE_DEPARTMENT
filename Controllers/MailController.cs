using CSE_DEPARTMENT.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace CSE_DEPARTMENT.Controllers
{
    public class MailController : Controller
    {
        // GET: Mail
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Send(Mail_info model)
        {
            var formAddress = new MailAddress("anik.adj82@gmail.com");
           
            var mail = new SmtpClient("smtp.gmail.com", 587)
            {
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(formAddress.Address, "#iamnotabadboy123"),
                EnableSsl = true
            };
            var message = new MailMessage();
            message.IsBodyHtml = false;
            message.From = new MailAddress(model.From);
            message.ReplyToList.Add(model.From);
            message.To.Add(new MailAddress(model.To));
            message.Subject = model.Subject;
            message.Body = model.Body;

            {
                var docu = Request.Files["document"];
                string fileName = Path.GetFileName(docu.FileName);
                message.Attachments.Add(new Attachment(docu.InputStream, fileName));

            }
            mail.Send(message);
            return View("Send");

        }
        public ActionResult Active()
        {
            return View();
        }
    }
}