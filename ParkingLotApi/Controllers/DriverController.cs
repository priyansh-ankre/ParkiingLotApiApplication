using Microsoft.AspNetCore.Mvc;
using ParkingLotBussinessLayer;
using ParkingLotModelLayer;

namespace ParkingLotApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverController : ControllerBase
    {
        private readonly IParkingLotBussiness parkingLotBussiness;
        public DriverController(IParkingLotBussiness parkingLotBussiness)
        {
            this.parkingLotBussiness = parkingLotBussiness;
        }

        [HttpPost]
        public IActionResult AddParking(Parking parking)
        {

            var parkingResult = this.parkingLotBussiness.AddParkingData(parking);
            if (parkingResult != null)
            {
                return this.Ok(parkingResult);
            }
            return this.BadRequest();
        }

        [HttpPost]
        [Route("Unparking")]
        public IActionResult Unparking(int parkingSlotId)
        {
            var unparkingResult = this.parkingLotBussiness.Unparking(parkingSlotId);
            if (unparkingResult != null)
            {
                return this.Ok(unparkingResult);
            }
            return this.BadRequest();
        }
    }
}
