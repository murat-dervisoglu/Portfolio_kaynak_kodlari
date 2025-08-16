using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace MyPage.ViewComponents.Education
{
    public class EducationList : ViewComponent
    {
        public readonly IEducationService _educationService;

        public EducationList(IEducationService educationService)
        {
            _educationService = educationService;
        }

        public IViewComponentResult Invoke()
        {
            return View(_educationService.TGetList());
        }
    }
}
