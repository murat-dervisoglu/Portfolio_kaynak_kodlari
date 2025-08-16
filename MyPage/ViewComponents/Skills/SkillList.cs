using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace MyPage.ViewComponents.Skills
{
    public class SkillList : ViewComponent
    {
        public readonly ISkillsService _skillsService;

        public SkillList(ISkillsService skillsService)
        {
            _skillsService = skillsService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _skillsService.TGetList();
            return View(values);
        }
    }
}
