using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KursIntroduction.Models
{
    public class Fare
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Cost { get; set; }
        public List<Train> Trains { get; set; }
    }
}