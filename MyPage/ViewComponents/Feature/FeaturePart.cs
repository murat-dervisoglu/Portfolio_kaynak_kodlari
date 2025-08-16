using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace MyPage.ViewComponents.Feature
{
    public class FeaturePart : ViewComponent
    {
        public readonly IFeatureService _featureManager;

        public FeaturePart(IFeatureService featureManager)
        {
            _featureManager = featureManager;
        }


        public IViewComponentResult Invoke()
        {
            var values = _featureManager.TGetList();
            return View(values);  
        }
    }
}
