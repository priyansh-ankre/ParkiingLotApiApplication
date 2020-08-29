using System.ComponentModel.DataAnnotations;

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
