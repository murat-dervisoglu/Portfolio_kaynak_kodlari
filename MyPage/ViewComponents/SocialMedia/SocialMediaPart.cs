using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace MyPage.ViewComponents.SocialMedia
{
    public class SocialMediaPart :ViewComponent
    {
        public readonly ISocialMediaService _socialmediaManager;

        public SocialMediaPart(ISocialMediaService socialmediaManager)
        {
            _socialmediaManager = socialmediaManager;
        }

        public IViewComponentResult Invoke()
        {
            var values = _socialmediaManager.TGetList();
            return View(values);
        }
    }
}
