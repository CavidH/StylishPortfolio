using Microsoft.AspNetCore.Http;

namespace StylishPortfolio.Areas.AdminPortfolio.ViewModels
{
    public class CreateVM
    {
        public string Name { get; set; }
        public string Summary { get; set; }
        public IFormFile ImageFile { get; set; }
    }
}
