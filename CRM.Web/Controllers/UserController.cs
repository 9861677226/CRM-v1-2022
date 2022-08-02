using CRM.Data.Interfaces;
using CRM.Data.Interfaces.Models.Users;
using CRM.Service.Interfaces;
using CRM.Web.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace CRM.Web.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

     

        [AllowAnonymous]
        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> LoginAsync(UserModel userModel)
        {
            // username = anet
            var userModels = new UserModel();
            var allUsers = userModels.GetUsers().FirstOrDefault();
            if (userModel.GetUsers().Any(u => u.UserName == userModel.UserName))
            {
                var userClaims = new List<Claim>()
                {
                new Claim(ClaimTypes.Name, allUsers.UserName),
                new Claim(ClaimTypes.Email, allUsers.EmailId),
                new Claim(ClaimTypes.Role, allUsers.Role),
                 };

                var identity = new ClaimsIdentity(userClaims, CookieAuthenticationDefaults.AuthenticationScheme);
                //Initialize a new instance of the ClaimsPrincipal with ClaimsIdentity    
                var principal = new ClaimsPrincipal(identity);
                //SignInAsync is a Extension method for Sign in a principal for the specified scheme.    
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties()
                {
                    IsPersistent = true
                });

                return RedirectToAction("Dashboard", "Home");
            }
            return View(userModel);
        }

        //[HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "User");
        }


        public IActionResult Error()
        {
            ViewBag.Message = "An error occured...";
            return View();
        }
    }
}
