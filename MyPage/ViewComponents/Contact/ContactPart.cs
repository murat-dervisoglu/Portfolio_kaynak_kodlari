using Microsoft.AspNetCore.Mvc;
using MyPage.Models;

namespace MyPage.ViewComponents.Contact
{
    public class ContactPart : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var model = new MailRequest(); 
            return View(model); 
        }
    }
}


