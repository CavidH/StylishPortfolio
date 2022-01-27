using System.ComponentModel.DataAnnotations;

namespace StylishPortfolio.ViewModels
{
    public class Register
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
