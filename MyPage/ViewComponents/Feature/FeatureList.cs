using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace MyPage.ViewComponents.Feature
{
    public class FeatureList : ViewComponent
    {
        public readonly IFeatureService _featureService;

        public FeatureList(IFeatureService featureservice)
        {
            _featureService = featureservice;
        }

        public IViewComponentResult Invoke()
        {
            var values = _featureService.TGetList();
            return View(values);
        }
    }
}
