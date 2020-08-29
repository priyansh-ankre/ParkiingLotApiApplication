using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ParkingLotModelLayer
{
    public class Roles
    {
        [Required]
        [Key]
        public int RolesId { get; set; }

        [Required]
        public string Role { get; set; }
    }
}
