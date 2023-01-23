
using KursIntroduction.Models;
using KursIntroductionCore.Models;
using KursIntroductionCore.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace KursIntroductionCore.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationContext db;
        IFlightInterface flightService;
        public HomeController(/*IFlightInterface fls*/)
        {
            db = new ApplicationContext();
            flightService = new FlightService();
        }
         
        [Authorize]
        public  IActionResult Index()
        {
           if (TempData["shortMessage"] != null)
            {
                ViewBag.Message = TempData["shortMessage"].ToString();
            }
            if (TempData["count"] != null)
            {
                ViewBag.Count = TempData["count"].ToString();
            }
            var flight = flightService.GetAllFlight();
            //var flight = await db.Flights.OrderBy(n=>n.DatetimeFlight).Include(u => u.Train).ThenInclude(c => c.Fare).ToListAsync();
            return View(flight);
        }


        [HttpPost]
        public  IActionResult BuyTicket(Flight flt)
        {
            var flight = db.Flights.FirstOrDefault(item => item.Id == flt.Id);
            var user = db.Users.FirstOrDefault(item => item.Login == User.Identity.Name);
            flight.CountTickets--;
            db.Transactions.AddAsync(new Transaction {Flight = flight,User = user });
            db.SaveChanges();
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
