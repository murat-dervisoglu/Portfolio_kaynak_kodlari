using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace MyPage.ViewComponents.Feature
{
    public class FeatureGet : ViewComponent
    {
        public readonly IFeatureService _featureService;

        public FeatureGet(IFeatureService featureservice)
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
