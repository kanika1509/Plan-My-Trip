using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PlanMyTripApp.Models
{
    public class HotelClass
    {
        [Key]
        public int HoteId { get; set; }
    
        public string City { get; set; }
        public string HotelName { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public Nullable<int> AvrRoomRent { get; set; }
        [StringLength(10,ErrorMessage ="Incorrect Lenght",MinimumLength =6)]
        public string Phone { get; set; }
        public Nullable<int> Rating { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}