using KursIntroduction.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KursIntroductionCore.Controllers
{
    public class PersonalPageController : Controller
    {
        private ApplicationContext db;

        public PersonalPageController(ApplicationContext db)
        {
            this.db = db;
        }

        [Authorize]
        public IActionResult Index()
        {
            if (TempData["shortMessage"] != null)
            {
                ViewBag.Message = TempData["shortMessage"].ToString();
            }
            var user = db.Users.FirstOrDefault(item => item.Login == User.Identity.Name);
            return View(user);
        }
        [Authorize]
        public IActionResult UpdateUser(User user)
        {
            db.Users.Attach(user);
            db.Entry(user).Property(x => x.Name).IsModified = true;
            db.SaveChanges();
            TempData["shortMessage"] = "ФИО успешно изменено!";
            return RedirectToAction("Index");
        }
    }
}
