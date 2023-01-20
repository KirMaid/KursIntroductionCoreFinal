using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KursIntroduction.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public Flight FlightId;
        public Flight Flight;
        public int UserId { get; set; }
        public User User { get; set; }
    }
}