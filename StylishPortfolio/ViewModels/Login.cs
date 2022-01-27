using System.ComponentModel.DataAnnotations;

namespace StylishPortfolio.ViewModels
{
    public class Login
    {
        public string Email { get; set; }
 
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me")]
        public bool RememberMe { get; set; }
    }
}
