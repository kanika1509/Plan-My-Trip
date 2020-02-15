using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PlanMyTripApp.Models
{
    public class Flight
    {
        [Key]
        public string FlightNumber { get; set; }
        public string FlightName { get; set; }
        public int SeatsCapacity { get; set; }
        public int NoOfSeatsAvailable { get; set; }
        public string FlightType { get; set; }

    }
}