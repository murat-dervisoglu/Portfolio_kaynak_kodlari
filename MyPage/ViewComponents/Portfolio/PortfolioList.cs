using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace MyPage.ViewComponents.Portfolio
{
    public class PortfolioList : ViewComponent
    {
        public readonly IPortfolioService _portfolioService;

        public PortfolioList(IPortfolioService portfolioService)
        {
            _portfolioService = portfolioService;
        }

        public IViewComponentResult Invoke()
        {
            return View(_portfolioService.TGetList());
        }
    }
}
