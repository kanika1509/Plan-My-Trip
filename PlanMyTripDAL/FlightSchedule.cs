//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PlanMyTripDAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class FlightSchedule
    {
        public int Id { get; set; }
        public string FlightNumber { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public System.DateTime DepartureTime { get; set; }
        public Nullable<System.DateTime> ArrivalTime { get; set; }
    
        public virtual Airport Airport { get; set; }
        public virtual Airport Airport1 { get; set; }
        public virtual Flight Flight { get; set; }
    }
}
