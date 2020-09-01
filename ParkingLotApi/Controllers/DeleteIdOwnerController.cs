using Microsoft.AspNetCore.Mvc;
using ParkingLotBussinessLayer;

namespace ParkingLotApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeleteIdOwnerController : ControllerBase
    {
        private readonly IParkingLotBussiness parkingLotBussiness;
        public DeleteIdOwnerController(IParkingLotBussiness parkingLotBussiness)
        {
            this.parkingLotBussiness = parkingLotBussiness;
        }

        [HttpDelete]
        public IActionResult DeleteParkingDataByParkingSlot(int parkingSlot)
        {
            var deleteResult = parkingLotBussiness.DeleteParkingDataByParkingSlot(parkingSlot);
            if (deleteResult != null)
            {
                return this.Ok(deleteResult);
            }
            return this.BadRequest();
        }
    }
}
