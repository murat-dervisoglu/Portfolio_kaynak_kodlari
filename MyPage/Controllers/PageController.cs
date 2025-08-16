using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MyPage.Models;

namespace MyPage.Controllers
{
    [AllowAnonymous]
    public class PageController : Controller
    {       
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(MailRequest mailRequest)
        {
            var message = new MimeMessage();

            message.From.Add(new MailboxAddress("İletişim Formu", "muratdervisoglu2002@gmail.com"));

            message.To.Add(new MailboxAddress("Admin", "muratdervisoglu2002@gmail.com"));
            message.Subject = $"[İletişim Formu] {mailRequest.Name} - {mailRequest.Subject}";
            message.ReplyTo.Add(new MailboxAddress(mailRequest.Name, mailRequest.SenderMail));

            var builder = new BodyBuilder();
            builder.TextBody = $"Gönderen: {mailRequest.Name} {mailRequest.Surname}\n<{mailRequest.SenderMail}>\n" +
            $"{mailRequest.Phone}\n\nMesaj:\n{mailRequest.Content}";

            message.Body = builder.ToMessageBody();
            using (var smtpClient = new SmtpClient())
            {
                smtpClient.Connect("smtp.gmail.com", 587, false);
                smtpClient.Authenticate("muratdervisoglu2002@gmail.com", "ynrdnpkmxmoajdmc");
                smtpClient.Send(message);
                smtpClient.Disconnect(true);
            }
            ViewBag.Message = "Mesajınız başarıyla gönderildi!";
            return View();
        }

        public PartialViewResult HeaderPartial()
        {
            return PartialView();
        }

        public PartialViewResult NavbarPartial()
        {
            return PartialView();
        }
    }
}
