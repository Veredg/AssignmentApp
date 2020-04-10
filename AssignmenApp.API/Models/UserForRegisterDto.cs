using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AssignmenApp.API.Enums;

namespace AssignmenApp.API.Models
{
    public class UserForRegisterDto
    {
      [Required]
      public string UserName { get; set; }
      [Required]
      public string Password { get; set; }
      public string FirstName { get; set; }
      public string LastName { get; set; }
      public string PhoneNumber { get; set; }
      public string Email { get; set; }
      public string Gender { get; set; }
      public string Address { get; set; }
      public string City { get; set; }
     // public ICollection<TaskForUserDto> Tasks { get; set; }

    }
}