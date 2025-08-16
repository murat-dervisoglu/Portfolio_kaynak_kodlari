using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyPage.Controllers
{
    [Authorize]
    public class EducationController : Controller
    {
        public readonly IEducationService _educationManager;

        public EducationController(IEducationService educationManager)
        {
            _educationManager = educationManager;
        }

        public IActionResult Index()
        {
            var values = _educationManager.TGetList();
            return View(values);
        }


        [HttpGet]
        public IActionResult EditEducation(int id)
        {
            var value = _educationManager.TGetByID(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult EditEducation(Education education)
        {
            _educationManager.TUpdate(education);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult AddEducation()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddEducation(Education education)
        {
            _educationManager.TAdd(education);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteEducation(int id)
        {
            _educationManager.TDelete(_educationManager.TGetByID(id));
            return RedirectToAction("Index");
        }
    }
}
