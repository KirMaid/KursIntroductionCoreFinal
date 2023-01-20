
using KursIntroduction.Models;
using KursIntroductionCore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace KursIntroductionCore.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationContext db;
        public HomeController(ApplicationContext context)
        {
            db = context;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            if (TempData["shortMessage"]!=null)
            {
                ViewBag.Message = TempData["shortMessage"].ToString();
            }
            if (TempData["count"] != null)
            {
                ViewBag.Count = TempData["count"].ToString();
            }
            var flight = await db.Flights.OrderBy(n=>n.DatetimeFlight).Include(u => u.Train).ThenInclude(c => c.Fare).ToListAsync();
            foreach (var item in flight)
            {
                item.Train.Fare.Cost = (int)(item.Train.Fare.Cost*item.PriceModifier);
            }
            return View(flight);
        }

        [HttpPost]
        public async Task<IActionResult> BuyTicket(Flight flt, Fare frs)
        {
            var flight = await db.Flights.FirstOrDefaultAsync(item => item.Id == flt.Id);
            var user = await db.Users.FirstOrDefaultAsync(item => item.Login == User.Identity.Name);
            //var price = await db.Fares.
            flight.CountTickets--;
            await db.SaveChangesAsync();
            // добавляем пользователя в бд
            await db.Transactions.AddAsync(new Transaction { /*Cost = (int)(frs.Cost * flt.PriceModifier), */Flight = flight,User = user });
            await db.SaveChangesAsync();
            TempData["shortMessage"] = "Билет успешно забронирован!";
            TempData["count"] = db.Transactions.Where(u => u.UserId == user.Id).Count();
            return RedirectToAction("Index", "Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
