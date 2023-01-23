using KursIntroduction.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KursIntroductionCore.Services
{
    public interface IFlightInterface
    {
        public List<Transaction> GetAllFlightByUserId(User user);
        public List<Flight> GetAllFlight();
    }
}
