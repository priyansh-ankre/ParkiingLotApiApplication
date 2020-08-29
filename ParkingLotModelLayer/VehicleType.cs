using System.ComponentModel.DataAnnotations;

namespace ParkingLotModelLayer
{
    public class VehicleType
    {
        [Required]
        [Key]
        public int VehicleId { get; set; }

        [Required]
        public string VehicleTypes { get; set; }
    }
}
