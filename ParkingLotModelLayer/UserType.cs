﻿using System.ComponentModel.DataAnnotations;

namespace ParkingLotModelLayer
{
    public class UserType
    {
        [Required]
        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Wrong Field Name Please Write Email")]
        [RegularExpression(@"^[a-zA-Z0-9.+_-]+[@][a-zA-Z0-9]+[.]co(m|.in)$")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Wrong Field Name Please Write Password")]
        //[RegularExpression(@"^[A-Z]{1}[a-z]")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Wrong Field Name Please Write UserType")]
        public string Role { get; set; }
    }
}
