using System;
using System.Threading.Tasks;
using BETShop.Api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BETShop.Api.Controllers
{
    [Route("Account")]
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        [Route("Signin")]
        public IActionResult Signin()
        {
            if (_signInManager.IsSignedIn(User))
            {
                return RedirectToAction("", "Product");
            }
            return View();
        }

        [HttpPost]
        [Route("Signin")]
        public async Task<IActionResult> SignIn([FromForm] SignInModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, true, false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid email or password.");
                return View();
            }
        }

        [HttpGet]
        [Route("Signup")]
        public IActionResult Signup()
        {
            if (_signInManager.IsSignedIn(User))
            {
                return RedirectToAction("", "Product");
            }
            return View();
        }

        [HttpPost]
        [Route("Signup")]
        public async Task<IActionResult> SignUp([FromForm] SignUpModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var userExists = await _userManager.FindByNameAsync(model.Email);
            if (userExists != null)
                return Conflict("User already exists!");

            var user = new IdentityUser
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Email
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                return Ok("User creation failed! Please check user details and try again.");

            return Ok("User created successfully!");
        }

        [HttpGet("Signout")]
        public async Task<IActionResult> Signout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Signin", "Account");

        }
    }
}
