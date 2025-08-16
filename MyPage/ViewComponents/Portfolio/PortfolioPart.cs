using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace MyPage.ViewComponents.Portfolio
{
    public class PortfolioPart : ViewComponent
    {
        public readonly IPortfolioService  _portfolioService;

        public PortfolioPart(IPortfolioService portfolioService)
        {
            _portfolioService = portfolioService;
        }

        public IViewComponentResult Invoke()
        {
            return View(_portfolioService.TGetList());
        }
    }
}
