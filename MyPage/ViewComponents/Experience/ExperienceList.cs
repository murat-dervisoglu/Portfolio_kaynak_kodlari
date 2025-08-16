using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace MyPage.ViewComponents.Experience
{
    public class ExperienceList : ViewComponent
    {
        public readonly IExperienceService _experienceService;

        public ExperienceList(IExperienceService experienceService)
        {
            _experienceService = experienceService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _experienceService.TGetList();
            return View(values);
        }
    }
}
