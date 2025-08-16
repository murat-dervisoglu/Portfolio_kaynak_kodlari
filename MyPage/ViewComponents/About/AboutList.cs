using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace MyPage.ViewComponents.About
{
    public class AboutList : ViewComponent
    {
        public readonly IAboutService _aboutService;

        public AboutList(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        public IViewComponentResult Invoke(bool onlyBirthDate = false)
        {
            var values = _aboutService.TGetList();

            if (onlyBirthDate)
            {
                return View("BirthDateOnly", values);
            }

            return View(values);
        }
    }
}
