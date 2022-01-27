using Data.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StylishPortfolio.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace StylishPortfolio.Controllers
{
    public class HomeController : Controller
    {
        private AppDbContext _context { get; }
        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var projects = await _context.projects
                .Where(p => p.IsDeleted == false)
                .ToListAsync();
            HomeVM homeVm = new HomeVM
            {
                Projects = projects
            };
            return View(homeVm);
        }
    }
}
