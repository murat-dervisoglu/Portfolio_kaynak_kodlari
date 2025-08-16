using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace MyPage.ViewComponents.Education
{
    public class EducationPart : ViewComponent
    {
        public readonly IEducationService _educationMAnager;

        public EducationPart(IEducationService educationMAnager)
        {
            _educationMAnager = educationMAnager;
        }

        public IViewComponentResult Invoke()
        {
            var values = _educationMAnager.TGetList();
            return View(values);
        }
    }
}
