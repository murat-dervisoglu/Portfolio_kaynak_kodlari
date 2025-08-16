using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyPage.Controllers
{
    [Authorize]
    public class SkillController : Controller
    {
        public readonly ISkillsService _skillsManager;

        public SkillController(ISkillsService skillsManager)
        {
            _skillsManager = skillsManager;
        }

        public IActionResult Index()
        {
            var values = _skillsManager.TGetList();
            return View(values);
        }

        [HttpPost]
        public IActionResult AddSkill(Skills skills)
        {
            _skillsManager.TAdd(skills);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteSkill(int id)
        {
            _skillsManager.TDelete(_skillsManager.TGetByID(id));
            return RedirectToAction("Index");
        }

    }
}
