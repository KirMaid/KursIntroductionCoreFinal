using KursIntroduction.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KursIntroductionCore.Services
{
    public class FlightService : IFlightInterface
    {
        ApplicationContext db;
        public FlightService(/*ApplicationContext db*/)
        {
            this.db = new ApplicationContext();
        }
        public List<Flight> GetAllFlight()
        {
            var flight = db.Flights.OrderBy(n => n.DatetimeFlight).Include(u => u.Train).ThenInclude(c => c.Fare).ToList();
            foreach (var item in flight)
            {
                item.Train.Fare.Cost = (int)(item.Train.Fare.Cost * item.PriceModifier);
            }
            return flight;
        }

        public List<Transaction> GetAllFlightByUserId(User user)
        {
            return db.Transactions.Where(b => b.UserId == user.Id).Include(b => b.Flight).ThenInclude(u => u.Train).ThenInclude(c => c.Fare).ToList();
        }
    }
}
