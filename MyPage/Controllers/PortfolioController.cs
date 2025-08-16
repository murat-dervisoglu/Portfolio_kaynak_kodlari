using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyPage.Models;
using Org.BouncyCastle.Bcpg.Sig;

namespace MyPage.Controllers
{
    [Authorize]
    public class PortfolioController : Controller
    {
        public readonly IPortfolioService _portfolioManager;

        public PortfolioController(IPortfolioService portfolioManager)
        {
            _portfolioManager = portfolioManager;
        }

        public IActionResult Index()
        {
            var values = _portfolioManager.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddPortfolio()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddPortfolio(EditPortfolioViewModel portfolio)
        {
            EntityLayer.Concrete.Portfolio  portfolio1 = new EntityLayer.Concrete.Portfolio();
            if (portfolio.ImageUrl1 != null)
            {
                var extension = Path.GetExtension(portfolio.ImageUrl1.FileName);
                var imagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", imagename);
                using (var stream = new FileStream(location, FileMode.Create))
                {
                    portfolio.ImageUrl1.CopyTo(stream);
                }
                portfolio1.ImageUrl1 = "/images/" + imagename;
            }

            if (portfolio.ImageUrl2 != null)
            {
                var extension = Path.GetExtension(portfolio.ImageUrl2.FileName);
                var imagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", imagename);
                using (var stream = new FileStream(location, FileMode.Create))
                {
                    portfolio.ImageUrl2.CopyTo(stream);
                }
                portfolio1.ImageUrl2 = "/images/" + imagename;
            }

            if (portfolio.ImageUrl3 != null)
            {
                var extension = Path.GetExtension(portfolio.ImageUrl3.FileName);
                var imagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", imagename);
                using (var stream = new FileStream(location, FileMode.Create))
                {
                    portfolio.ImageUrl3.CopyTo(stream);
                }
                portfolio1.ImageUrl3 = "/images/" + imagename;
            }

            if (portfolio.ImageUrl4 != null)
            {
                var extension = Path.GetExtension(portfolio.ImageUrl4.FileName);
                var imagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", imagename);
                using (var stream = new FileStream(location, FileMode.Create))
                {
                    portfolio.ImageUrl4.CopyTo(stream);
                }
                portfolio1.ImageUrl4 = "/images/" + imagename;
            }

            portfolio1.PortfolioName = portfolio.PortfolioName;
            portfolio1.Description = portfolio.Description;
            portfolio1.ProjectUrl = portfolio.ProjectUrl;
            portfolio1.PortfolioID = portfolio.PortfolioID;

            _portfolioManager.TAdd(portfolio1);
            return RedirectToAction("Index");
        }

        public IActionResult DeletePortfolio(int id)
        {
            _portfolioManager.TDelete(_portfolioManager.TGetByID(id));
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult EditPortfolio(int id)
        {
            var portfolio = _portfolioManager.TGetByID(id);

            if (portfolio == null)
            {
                return NotFound();
            }

            var model = new EditPortfolioViewModel
            {
                PortfolioID = portfolio.PortfolioID,
                PortfolioName = portfolio.PortfolioName,
                Description = portfolio.Description,
                ProjectUrl = portfolio.ProjectUrl,
                ImageUrl1 = null,
                ImageUrl2 = null,
                ImageUrl3 = null,
                ImageUrl4 = null,
                ExistingImage1 = portfolio.ImageUrl1,
                ExistingImage2 = portfolio.ImageUrl2,
                ExistingImage3 = portfolio.ImageUrl3,
                ExistingImage4 = portfolio.ImageUrl4
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult EditPortfolio(EditPortfolioViewModel model)
        {
            var portfolio = _portfolioManager.TGetByID(model.PortfolioID);

            portfolio.PortfolioName = model.PortfolioName;
            portfolio.Description = model.Description;
            portfolio.ProjectUrl = model.ProjectUrl;

            if (model.ImageUrl1 != null)
                portfolio.ImageUrl1 = SaveImage(model.ImageUrl1);

            if (model.ImageUrl2 != null)
                portfolio.ImageUrl2 = SaveImage(model.ImageUrl2);

            if (model.ImageUrl3 != null)
                portfolio.ImageUrl3 = SaveImage(model.ImageUrl3);

            if (model.ImageUrl4 != null)
                portfolio.ImageUrl4 = SaveImage(model.ImageUrl4);

            _portfolioManager.TUpdate(portfolio);
            return RedirectToAction("Index");
        }

        private string SaveImage(IFormFile image)
        {
            var extension = Path.GetExtension(image.FileName);
            var imagename = Guid.NewGuid() + extension;
            var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", imagename);
            using (var stream = new FileStream(location, FileMode.Create))
            {
                image.CopyTo(stream);
            }
            return "/images/" + imagename;
        }
    }
}
