using Core.Entities;
using Data.DAL;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StylishPortfolio.Areas.AdminPortfolio.ViewModels;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace StylishPortfolio.Areas.AdminPortfolio.Controllers
{
    [Area("AdminPortfolio")]
    public class ProductController : Controller
    {
        private AppDbContext _context { get; }
        private IWebHostEnvironment _env { get; }
        public ProductController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {
            var projects = await _context.projects.Where(p => p.IsDeleted == false).ToListAsync();
            return View(projects);
        }
        public async Task<IActionResult> Create()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateVM createVm)
        {
             
            if (ModelState.IsValid)  
            {  
                string  FileName = ProcessUploadedFile(createVm.ImageFile);
                var project = new Project { 
                Name=createVm.Name,
                Summary=createVm.Summary,   
                Image= FileName
                };
                await _context.AddAsync(project);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }  
            return View(createVm);  
        }
        private string ProcessUploadedFile(IFormFile File)
        {
            string uniqueFileName = null;

            if (File  != null)
            {
                string uploadsFolder = Path.Combine(_env.WebRootPath, "assets","img");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + File.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    File.CopyTo(fileStream);
                }
            }

            return uniqueFileName;
        }

    }
}
