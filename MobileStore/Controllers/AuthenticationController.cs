using DataAccessLayer.Data;
using DataAccessLayer.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MobileStore.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IConfiguration _configuration;

        public AuthenticationController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<ApplicationUser> signInManager, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.signInManager = signInManager;
            _configuration = configuration;
        }

        public IActionResult Register() => View(new Register());

        // Registering a new user
        [HttpPost]
        public async Task<IActionResult> Register(Register model)
        {
            if (!ModelState.IsValid) return View(model);
            var userExists = await userManager.FindByNameAsync(model.Username);
            if (userExists != null)
            {
                TempData["Error"] = "This user name is already in use, please choose another one!";
                return View(model);
            }

            ApplicationUser user = new ApplicationUser()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username
            };

            var result = await userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                TempData["Error"] = "Your registration was unsuccessful, please make sure that your password contains one capital letter, one number and one symbol!";
                return View(model);
            }

            if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
            if (!await roleManager.RoleExistsAsync(UserRoles.User))
                await roleManager.CreateAsync(new IdentityRole(UserRoles.User));
            // Assigning an user role
            if (await roleManager.RoleExistsAsync(UserRoles.Admin))
            {
                await userManager.AddToRoleAsync(user, UserRoles.User);
            }

            TempData["Success"] = "Your registration was successful, you can now login to our system!";
            return RedirectToAction("Index", "Mobile");
        }

        [Authorize(Roles = UserRoles.Admin)]
        public IActionResult RegisterAdmin() => View(new RegisterAdmin());
        // Register Admin
        [HttpPost]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> RegisterAdmin(RegisterAdmin model)
        {
            var userExist = await userManager.FindByNameAsync(model.Username);
            if (userExist != null)
            {
                TempData["Error"] = "Admin already exists, please choose another Username!";
                return View(model);
            }

            ApplicationUser user = new ApplicationUser()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username
            };

            var result = await userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                TempData["Error"] = "Admin can't be registered at the moment. Please be sure that your password contains at least one capital letter, one number and one symbol!";
                return View(model);
            }

            if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
            if (!await roleManager.RoleExistsAsync(UserRoles.User))
                await roleManager.CreateAsync(new IdentityRole(UserRoles.User));
            // Assigning an admin role
            if (await roleManager.RoleExistsAsync(UserRoles.Admin))
            {
                await userManager.AddToRoleAsync(user, UserRoles.Admin);
            }

            TempData["Success"] = "New admin has been registered, you can now login to our system!";
            return RedirectToAction("Index", "Mobile");
        }

        public IActionResult Login() => View(new Login());
        // Login
        [HttpPost]
        public async Task<IActionResult> Login(Login model)
        {
            if (!ModelState.IsValid) return View(model);

            var doesUserExist = await userManager.FindByNameAsync(model.Username);
            if(doesUserExist == null)
            {
                TempData["Error"] = "User does not exist, please register in order to login!";
                return View(model);
            }

            var user = await userManager.FindByNameAsync(model.Username);
            if (user != null)
            {
                var passwordCheck = await userManager.CheckPasswordAsync(user, model.Password);
                if (passwordCheck)
                {
                    var userRoles = await userManager.GetRolesAsync(user);
                    var authClaims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.UserName)
                    };

                    foreach(var userRole in userRoles){
                        authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                    }
                    var result = await signInManager.PasswordSignInAsync(user, model.Password, false, false);
                    if (result.Succeeded)
                    {
                        TempData["Success"] = "Your login was successful, enjoy your shopping!";
                        return RedirectToAction("Index", "Mobile");
                    }
                }
                TempData["Error"] = "Wrong password. Please, try again!";
                return View(model);
            }

            TempData["Error"] = "Something went wrong, please try again later.";
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            TempData["Success"] = "Thank you for using our services, till next time!";
            return RedirectToAction("Index", "Mobile");
        }

        public IActionResult AccessDenied(string returnUrl)
        {
            return View();
        }
    }
}
