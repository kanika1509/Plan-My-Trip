﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlanMyTripWebAPI.Models
{
    public class SearchHotelsView
    {
        public string HotelName { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string RoomName { get; set; }
        public string RoomType { get; set; }
        public Nullable<int> PerDayRate { get; set; }
    }
}