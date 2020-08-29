using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ParkingLotModelLayer
{
    public class ParkingType
    {
        [Required]
        [Key]
        public int ParkingId { get; set; }

        [Required]
        public string ParkingTypes { get; set; }
    }
}
