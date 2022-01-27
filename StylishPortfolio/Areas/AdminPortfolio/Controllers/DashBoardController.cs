using Microsoft.AspNetCore.Mvc;

namespace StylishPortfolio.Areas.AdminPortfolio.Controllers
{
    public class DashBoardController : Controller
    {
        [Area("AdminPortfolio")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
