using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParkingLotModelLayer
{
    public class Parking
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ParkingSLot { get; set; }

        [Required]
        public string VehicleNumber { get; set; }

        public string EntryTime { get; set; }

        [Required]
        [ForeignKey("VehicleType")]
        public int VehicleId { get; set; }

        [Required]
        [ForeignKey("ParkingType")]
        public int ParkingId { get; set; }

        [Required]
        [ForeignKey("Roles")]
        public int RolesId { get; set; }

        public bool Disabled { get; set; }

        public string ExitTime { get; set; }

        [Required]
        public int Charges { get; set; }
    }
}
