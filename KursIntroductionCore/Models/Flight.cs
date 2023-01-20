using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KursIntroduction.Models
{
    public class Flight
    {
        public int Id { get; set; }
        public string NumberFlight { get; set; }
        public DateTime DatetimeFlight { get; set; }
        public DateTime DatetimeFlightArrival { get; set; }
        public string Departure { get; set; }
        public string Arrival { get; set; }
        public double PriceModifier { get; set; }
        public int CountTickets { get; set; }
        public int TrainId { get; set; }
        public Train Train { get; set; }
    }
}