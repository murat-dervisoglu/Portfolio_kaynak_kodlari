using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyPage.Controllers
{
    [Authorize]
    public class TestimonialController : Controller
    {
        public readonly ITestimonialService _testimonialManager;

        public TestimonialController(ITestimonialService testimonialManager)
        {
            _testimonialManager = testimonialManager;
        }

        public IActionResult Index()
        {
            var values = _testimonialManager.TGetList();
            return View(values);
        }


        [HttpGet]
        public IActionResult EditTestimonial(int id)
        {
            var value = _testimonialManager.TGetByID(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult EditTestimonial(Testimonial testimonial)
        {
            _testimonialManager.TUpdate(testimonial);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult AddTestimonial()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddTestimonial(Testimonial testimonial)
        {
            _testimonialManager.TAdd(testimonial);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteTestimonial(int id)
        {
            _testimonialManager.TDelete(_testimonialManager.TGetByID(id));
            return RedirectToAction("Index");
        }
    }
}
