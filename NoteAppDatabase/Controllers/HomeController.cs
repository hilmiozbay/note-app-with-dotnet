using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proje5.Models;
using Proje5.Utility;
using System;
using System.Linq;

namespace Proje5.Controllers
{
    public class HomeController : Controller
    {
        private readonly UygulamaDbContext _context;

        public HomeController(UygulamaDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var account = _context.Accounts
                    .Include(a => a.User)
                    .FirstOrDefault(a => a.Username == model.Username && a.Password == model.Password);

                if (account != null && account.IsActive==true)
                {  
                    HttpContext.Session.SetInt32("AccountId", account.Id);
                    if (account.IsAdmin)
                    {
                        return RedirectToAction("AdminMenu", "Admin");
                    }
                    return RedirectToAction("UserMenu", "User");
                }

                ModelState.AddModelError("", "Invalid username or password");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var existingUser = _context.Users
                    .FirstOrDefault(u => u.MailAddress == model.MailAddress);

                if (existingUser != null)
                {
                    ModelState.AddModelError("", "Email already registered.");
                    return View(model);
                }

                var user = new Users
                {
                    Firstname = model.Firstname,
                    Surname = model.Surname,
                    MailAddress = model.MailAddress,
                    CreateTime = DateTime.UtcNow,
                    LastUpdateTime = DateTime.UtcNow,
                    IsActive = true,
                    IsAdmin = false
                };

                var account = new Account
                {
                    Username = model.Username,
                    Password = model.Password,
                    IsActive = true,
                    User = user
                };

                _context.Add(account);
                _context.SaveChanges(); 

                return RedirectToAction("Login");
            }
            return View(model);
        }

        
    }
}
