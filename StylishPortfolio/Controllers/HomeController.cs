using Microsoft.AspNetCore.Mvc;


namespace StylishPortfolio.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
           
            return View();
        }
    }
}
