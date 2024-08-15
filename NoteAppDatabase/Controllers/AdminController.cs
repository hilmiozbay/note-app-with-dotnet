using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Proje5.Models;
using Proje5.Utility;

namespace Proje5.Controllers
{
    public class AdminController : Controller
    {

        private readonly UygulamaDbContext _context;

        public AdminController(UygulamaDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AdminMenu()
        {
            return View();
        }

        public IActionResult ListUsers()
        {
            var users = _context.Users.ToList();

            if (users == null)
            {
                users = new List<Users>();
            }

            return View(users);
        }

        [HttpPost]
        public IActionResult DeactivateUser(int id)
        {           
            var user = _context.Users.Find(id);
            
            if (user == null)
            {
                return NotFound(); 
            }

            user.IsActive = !user.IsActive;
   
            _context.Update(user);
            _context.SaveChanges();         
            return RedirectToAction("ListUsers");
        }



    }
}

