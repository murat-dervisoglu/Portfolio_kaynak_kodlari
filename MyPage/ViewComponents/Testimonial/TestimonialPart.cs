using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace MyPage.ViewComponents.Testimonial
{
    public class TestimonialPart : ViewComponent
    {
        public ITestimonialService _testimonialManager;

        public TestimonialPart(ITestimonialService testimonialManager)
        {
            _testimonialManager = testimonialManager;
        }

        public IViewComponentResult Invoke()
        {
            var values = _testimonialManager.TGetList();
            return View(values);
        }
    }
}
