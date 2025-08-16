using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace MyPage.ViewComponents.Skills
{
    public class SkillsPart : ViewComponent
    {
        public readonly ISkillsService _skillsManager;

        public SkillsPart(ISkillsService skillsManager)
        {
            _skillsManager = skillsManager;
        }

        public IViewComponentResult Invoke()
        {
            var values = _skillsManager.TGetList();
            return View(values);
        }
    }
}
