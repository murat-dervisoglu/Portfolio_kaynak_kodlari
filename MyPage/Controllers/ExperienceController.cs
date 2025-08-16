using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyPage.Controllers
{
    [Authorize]
    public class ExperienceController : Controller
    {
        public readonly IExperienceService _experienceManager;

        public ExperienceController(IExperienceService experienceManager)
        {
            _experienceManager = experienceManager;
        }

        public IActionResult Index()
        {
            var values = _experienceManager.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult EditExperience(int id)
        {
            var value = _experienceManager.TGetByID(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult EditExperience(Experience experience)
        {
            _experienceManager.TUpdate(experience);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult AddExperience()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddExperience(Experience experience)
        {
            _experienceManager.TAdd(experience);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteExperience(int id)
        {
            _experienceManager.TDelete(_experienceManager.TGetByID(id));
            return RedirectToAction("Index");
        }
    }
}
