using DVD_Rental_Application.Models;
using DVD_Rental_Application.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace DVD_Rental_Application.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext dataBaseContext;
        private readonly UserService _userService;

        public HomeController(AppDbContext db, UserService userService)
        {
            dataBaseContext = db;
            _userService = userService;
        }

        public IActionResult Index(bool Islogout = false)
        {
            ViewBag.islogout = Islogout;
            return View();
        }

        //register an admin
        public IActionResult Register(User users)
        {
          
            users.UserName = "adminusser";
            users.Password = ("admin");
            users.UserType = "admin";
            dataBaseContext.users.Add(users);
            dataBaseContext.SaveChanges();
            return View();
        }


        //login "GET" Request
        [HttpGet]
        public IActionResult Login(string ReturnUrl)
        {
            ViewData["ReturnUrl"] = ReturnUrl;
            return View();
        }

        //Login "POST" Request
        [HttpPost]
        public async Task<IActionResult> Login(string username, string password, string ReturnUrl)
        {
       
            ViewData["ReturnUrl"] = ReturnUrl;

            if (_userService.TryValidateUser(username, password, out List<Claim> claims))
            {
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                await HttpContext.SignInAsync(claimsPrincipal);
                if (ReturnUrl != null)
                {
                    return Redirect(ReturnUrl);
                }
                else
                {
                    //return RedirectToAction("privcy", "Home", new { IsLogin = true });
                    return Redirect("home/privacy");
                }
            }
            else
            {
                TempData["Error"] = "Invalid username or password";
                return Redirect("/");
            }
        }

        //Logout
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }
    }
}
