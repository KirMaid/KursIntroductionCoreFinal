using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KursIntroduction.Models
{
    public class Train
    {
        public int Id { get; set; }
        public string TrainNumber { get; set; }
        public string NumberOfWagons { get; set; }
        public int FareId { get; set; }
        public Fare Fare { get; set; }
        public List<Flight> Flights { get; set; }
    }
}