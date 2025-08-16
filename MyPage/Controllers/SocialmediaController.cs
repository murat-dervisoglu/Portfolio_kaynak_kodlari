using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyPage.Controllers
{
    [Authorize]
    public class SocialmediaController : Controller
    {
        public readonly ISocialMediaService _socialmediaManager;

        public SocialmediaController(ISocialMediaService socialmediaManager)
        {
            _socialmediaManager = socialmediaManager;
        }

        public IActionResult Index()
        {
            var values = _socialmediaManager.TGetList();
            return View(values);
        }

        [HttpPost]
        public IActionResult AddSocialmedia(SocialMedia socialMedia)
        {
            _socialmediaManager.TAdd(socialMedia);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteSocialMedia(int id)
        {
            _socialmediaManager.TDelete(_socialmediaManager.TGetByID(id));
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult EditSocialmedia(SocialMedia socialMedia)
        {
            var existingData = _socialmediaManager.TGetByID(socialMedia.SocialMediaID);
            if (existingData != null)
            {
                existingData.Name = socialMedia.Name;
                existingData.Account = socialMedia.Account;
                existingData.Icon = socialMedia.Icon;
                _socialmediaManager.TUpdate(existingData);
            }
            return RedirectToAction("Index");
        }
    }
}
