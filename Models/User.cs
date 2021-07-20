using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Dungeons.Models
{
    public class User
    {
        [Key]
        public int User_ID { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z0-9 ]+$",
            ErrorMessage = "Username can only contain letters numbers and spaces.")]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,30}$",
            ErrorMessage = "Password must be between 8 and 30 characters and contain atleast 1 lowercase, uppercase a number and symbol")]
        public string Password { get; set; }
    }
}
