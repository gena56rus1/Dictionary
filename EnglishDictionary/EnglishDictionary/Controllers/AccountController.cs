using EnglishDictionary.Data;
using EnglishDictionary.Models;
using EnglishDictionary.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace EnglishDictionary.Controllers
{
    public class AccountController : Controller
    {
        private MyDbContext db;
        public AccountController(MyDbContext context)
        {
            db = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await db.Users.FirstOrDefaultAsync(u => u.Login == model.Login && u.Password == model.Password);
                if (user != null)
                {
                    await Authenticate(model.Login); 
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(model);
        }

        private Task Authenticate(object login)
        {
            throw new NotImplementedException();
        }



        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await db.Users.FirstOrDefaultAsync(u => u.Email == model.Email || u.Login == model.Login);
                if (user == null)
                {
                    db.Users.Add(new User {Login = model.Login, Email = model.Email, Password = model.Password });
                    await db.SaveChangesAsync();

                    await Authenticate(model.Login); 

                    return RedirectToAction("Index", "Home");
                }
                else
                    return Content($"this {model.Login} or {model.Email} is available");
            }
            return View(model);
        }

        private async Task Authenticate(string userName)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
            };
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        public async Task<IActionResult> Exit()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }
        
        public async Task<IActionResult> Profile()
        {
            if (User.Identity.Name != null)
            {
                User user = await db.Users.FirstOrDefaultAsync(u => User.Identity.Name == u.Login);
                return View(user);
            }

            ModelState.AddModelError("", "ошибка");
            return RedirectToAction("Login", "Account");
        }
    }
}
