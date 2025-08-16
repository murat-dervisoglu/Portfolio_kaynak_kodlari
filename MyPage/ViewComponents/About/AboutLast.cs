using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace MyPage.ViewComponents.About
{
    public class AboutLast : ViewComponent
    {
        public readonly IAboutService _aboutManager;

        public AboutLast(IAboutService aboutManager)
        {
            _aboutManager = aboutManager;
        }

        public IViewComponentResult Invoke()
        {
            var values = _aboutManager.TGetList();
            return View(values);
        }
    }
}
