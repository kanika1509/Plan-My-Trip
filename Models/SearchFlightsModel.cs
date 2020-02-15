using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PlanMyTripApp.Models
{
    public class SearchFlightsModel
    {
        [Key]
        public string FlightNumber { get; set; }
        public string FlightName { get; set; }
        public System.DateTime DepartureTime { get; set; }
        public Nullable<System.DateTime> ArrivalTime { get; set; }
        public int NoOfSeatsAvailable { get; set; }
        public string FlightType { get; set; }
    }
}