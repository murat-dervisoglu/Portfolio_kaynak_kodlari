using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace MyPage.ViewComponents.SocialMedia
{
    public class SocialMediaFooter : ViewComponent 
    {
        public readonly ISocialMediaService _socialMediaService;

        public SocialMediaFooter(ISocialMediaService socialMediaService)
        {
            _socialMediaService = socialMediaService;
        }

        public IViewComponentResult Invoke()
        {
            return View(_socialMediaService.TGetList());
        }
    }
}
