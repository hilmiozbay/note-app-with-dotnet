using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proje5.Models;
using Proje5.Utility;
using System;
using System.Linq;

namespace Proje5.Controllers
{
    public class UserController : Controller
    {
        private readonly UygulamaDbContext _context;

        public UserController(UygulamaDbContext context)
        {
            _context = context;
        }

        public IActionResult UserMenu()
        {
            return View();
        }

        public IActionResult AddNote()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddNote(NoteViewModel model)
        {
            if (ModelState.IsValid)
            {
                int accountId = HttpContext.Session.GetInt32("AccountId").Value;

                var note = new Notes
                {
                    Description = model.Description,
                    AccountId = accountId,
                    CreateTime = DateTime.UtcNow,
                    LastUpdateTime = DateTime.UtcNow
                };

                _context.Notes.Add(note);
                _context.SaveChanges(); 

                return RedirectToAction("ListNotes");
            }
            return View(model);
        }

        public IActionResult EditNote(int id)
        {
            var note = _context.Notes.Find(id);

            if (note == null || note.AccountId != HttpContext.Session.GetInt32("AccountId"))
            {
                return NotFound();
            }

            var model = new NoteViewModel
            {
                Id = note.Id,
                Description = note.Description
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult EditNote(NoteViewModel model)
        {
            if (ModelState.IsValid)
            {
                var note = _context.Notes.Find(model.Id);

                if (note == null || note.AccountId != HttpContext.Session.GetInt32("AccountId"))
                {
                    return NotFound();
                }

                note.Description = model.Description;
                note.LastUpdateTime = DateTime.UtcNow;

                _context.Notes.Update(note);
                _context.SaveChanges(); 

                return RedirectToAction("ListNotes");
            }
            return View(model);
        }

        public IActionResult DeleteNote(int id)
        {
            var note = _context.Notes.Find(id);

            if (note == null || note.AccountId != HttpContext.Session.GetInt32("AccountId"))
            {
                return NotFound();
            }
            return View(note);
        }

        [HttpPost, ActionName("DeleteNote")]
        public IActionResult DeleteConfirmed(int id)
        {
            var note = _context.Notes.Find(id);

            if (note == null || note.AccountId != HttpContext.Session.GetInt32("AccountId"))
            {
                return NotFound();
            }

            _context.Notes.Remove(note);
            _context.SaveChanges(); 

            return RedirectToAction("ListNotes");
        }

        public IActionResult ListNotes()
        {
            int accountId = HttpContext.Session.GetInt32("AccountId").Value;
            var notes = _context.Notes
                .Where(n => n.AccountId == accountId)
                .ToList(); 

            return View(notes);
        }

        public IActionResult UpdateUser()
        {
            int userId = HttpContext.Session.GetInt32("AccountId").Value;

            var user = _context.Users.Find(userId);

            if (user == null)
            {
                return NotFound();
            }

            var model = new UserViewModel
            {
                Id = user.Id,
                Firstname = user.Firstname,
                Surname = user.Surname,
                MailAddress = user.MailAddress
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult UpdateUser(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _context.Users.Find(model.Id);

                if (user == null)
                {
                    return NotFound();
                }

                user.Firstname = model.Firstname;
                user.Surname = model.Surname;
                user.MailAddress = model.MailAddress;

                _context.Users.Update(user);
                _context.SaveChanges(); // Senkron kaydetme

                return RedirectToAction("UserMenu");
            }
            return View(model);
        }
    }
}
