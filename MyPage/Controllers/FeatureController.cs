using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyPage.Models;
using System.Drawing;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;

namespace MyPage.Controllers
{
    [Authorize]
    public class FeatureController : Controller
    {
        public readonly IFeatureService _featureManager;

        public FeatureController(IFeatureService featureManager)
        {
            _featureManager = featureManager;
        }

        public IActionResult Index()
        {
            var value =  _featureManager.TGetList();
            return View(value);
        }

        [HttpGet]
        public IActionResult EditFeature(int id)
        {
            var feature = _featureManager.TGetByID(id);

            if (feature == null)
            {
                return NotFound();
            }

            var model = new EditProfileViewModel
            {
                Id = feature.FeatureID,
                Name = feature.Name,
                Surname = feature.Surname,
                Title = feature.Title,
                Image = null
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult EditFeature(EditProfileViewModel p)
        {
            var feature = _featureManager.TGetByID(p.Id);

            if (feature == null)
            {
                return NotFound();
            }

            if (p.Image != null)
            {
                var extension = Path.GetExtension(p.Image.FileName);
                var imagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", imagename);
                using (var stream = new FileStream(location, FileMode.Create))
                {
                    p.Image.CopyTo(stream);
                }
                feature.ImageUrl = "/images/" + imagename; 
            }

            feature.Name = p.Name;
            feature.Surname = p.Surname;
            feature.Title = p.Title;

            _featureManager.TUpdate(feature);
            return RedirectToAction("Index");
        }
    }
}
