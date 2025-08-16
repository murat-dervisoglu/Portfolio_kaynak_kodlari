using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace MyPage.ViewComponents.Testimonial
{
    public class TestimonialList : ViewComponent
    {
        public readonly ITestimonialService _testimonialService;

        public TestimonialList(ITestimonialService testimonialService)
        {
            _testimonialService = testimonialService;
        }

        public IViewComponentResult Invoke()
        {       
            return View(_testimonialService.TGetList());
        }
    }
}
