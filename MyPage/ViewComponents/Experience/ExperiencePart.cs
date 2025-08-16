using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace MyPage.ViewComponents.Experience
{
    public class ExperiencePart : ViewComponent
    {
        public readonly IExperienceService _experienceManager;

        public ExperiencePart(IExperienceService experienceManager)
        {
            _experienceManager = experienceManager;
        }

        public IViewComponentResult Invoke()
        {
            var values = _experienceManager.TGetList();
            return View(values);
        }
    }
}
