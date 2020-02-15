using System;
using System.ComponentModel.DataAnnotations;
namespace PlanMyTripApp.Models
{
    public class UsersModel
    {
        [Key]
        public int UserId { get; set; }
        [Required(ErrorMessage ="Required")]
        [RegularExpression("^([a-zA-Z0-9]$)", ErrorMessage ="Enter Valid Data")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [DataType (DataType.EmailAddress,ErrorMessage ="Please Enter valid email")]
        public string EmailId { get; set; }
        [DataType (DataType.Password,ErrorMessage ="Inappropriate Password")]
        public string Password { get; set; }
        public Nullable<int> RoleId { get; set; }
    }
}