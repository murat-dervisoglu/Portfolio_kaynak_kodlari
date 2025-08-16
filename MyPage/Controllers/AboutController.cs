using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyPage.Controllers
{
    [Authorize]
    public class AboutController : Controller
    {
        public readonly IAboutService _aboutManager;

        public AboutController(IAboutService aboutManager)
        {
            _aboutManager = aboutManager;
        }

        public IActionResult Index()
        {
            var value = _aboutManager.TGetList();
            return View(value);
        }

        [HttpGet]
        public IActionResult EditAbout(int id)
        {
            var value = _aboutManager.TGetByID(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult EditAbout(About about)
        {
            _aboutManager.TUpdate(about);
            return RedirectToAction("Index");
        }
    }
}
