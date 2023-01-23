using KursIntroductionCore.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using KursIntroductionCore.Models;

namespace KursIntroductionCore.Controllers
{
    public class UserPageController : Controller
    {
        private ApplicationContext db;
        IFlightInterface flightService;
        public UserPageController(/*ApplicationContext context*/)
        {
            db = new ApplicationContext();
            flightService = new FlightService();
        }

        [Authorize]
        public IActionResult Index()
        {
            var FinalPrice = 0;
            var user = db.Users.FirstOrDefault(item => item.Login == User.Identity.Name);
            double discount = (100 - user.Discount)/100.0;
            ViewBag.Discount = user.Discount;
            var flight = flightService.GetAllFlightByUserId(user);
            foreach (var item in flight)
            {
                FinalPrice += item.Flight.Train.Fare.Cost * Convert.ToInt32(item.Flight.PriceModifier);
            }
            ViewBag.FinalPrice = FinalPrice * discount;
            return View("~/Views/Home/UserPage.cshtml", flight);
        }



        [Authorize]
        [HttpPost]
        public IActionResult DeleteTicket(KursIntroduction.Models.Transaction transaction)
        {
            db.Transactions.Attach(transaction);
            db.Transactions.Remove(transaction);
            db.SaveChanges();
            return RedirectToAction("Index","UserPage");
        }

    }
}
