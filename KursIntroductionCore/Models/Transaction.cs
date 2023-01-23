using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KursIntroduction.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public int FlightId { get; set; }
        public Flight Flight { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}