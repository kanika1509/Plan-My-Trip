using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlanMyTripApp.Models
{
    public class FlightSchedule
    {
        public int Id { get; set; }
        public string FlightNumber { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public System.DateTime DepartureTime { get; set; }
        public Nullable<System.DateTime> ArrivalTime { get; set; }
        public List<Models.AirportModel> Airports { get; set; }
    }
}