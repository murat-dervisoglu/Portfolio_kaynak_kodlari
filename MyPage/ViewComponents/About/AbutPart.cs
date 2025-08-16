using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace MyPage.ViewComponents.About
{
    public class AbutPart : ViewComponent
    {
        public readonly IAboutService _aboutManager;

        public AbutPart(IAboutService aboutManager)
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
