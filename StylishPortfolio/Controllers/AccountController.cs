using Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StylishPortfolio.ViewModels;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace StylishPortfolio.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        public AccountController(UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager)
        {

            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        // public IActionResult Index()
        // {
        //     return View();
        // }
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("index", "Home");
        }
        [HttpGet, AllowAnonymous]
        public IActionResult Register()
        {
            //UserRegistrationDto model = new UserRegistrationDto();
            //return View(model);
            return View();
        }
        [HttpPost, AllowAnonymous]
        public async Task<IActionResult> Register(Register reg)
        {
            if (ModelState.IsValid)
            {
                var userCheck = await userManager.FindByEmailAsync(reg.Email);
                if (userCheck == null)
                {
                    var user = new AppUser
                    {
                        UserName = reg.Email,
                        NormalizedUserName = reg.Email,
                        Email = reg.Email,
                        EmailConfirmed = true,
                        PhoneNumberConfirmed = true,
                    };
                    var result = await userManager.CreateAsync(user, reg.Password);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Login");
                    }
                    else
                    {
                        if (result.Errors.Count() > 0)
                        {
                            foreach (var error in result.Errors)
                            {
                                ModelState.AddModelError("message", error.Description);
                            }
                        }
                        return View(reg);
                    }
                }
                else
                {
                    ModelState.AddModelError("message", "Email already exists.");
                    return View(reg);
                }
            }
            return View(reg);

        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            //UserLoginDto model = new UserLoginDto();
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(Login model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(model.Email);
                if (user != null && !user.EmailConfirmed)
                {
                    ModelState.AddModelError("message", "Email not confirmed yet");
                    return View(model);

                }
                if (await userManager.CheckPasswordAsync(user, model.Password) == false)
                {
                    ModelState.AddModelError("message", "Invalid credentials");
                    return View(model);

                }

                var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, true);

                if (result.Succeeded)
                {
                    await userManager.AddClaimAsync(user, new Claim("UserRole", "Admin"));
                    return RedirectToAction("Index","Home");
                }
                else if (result.IsLockedOut)
                {
                    // return View("");
                }
                else
                {
                    ModelState.AddModelError("message", "Invalid login attempt");
                    return View(model);
                }
            }
            return View(model);
        }
    }
}
