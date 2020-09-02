using Microsoft.AspNetCore.Mvc;
using ParkingLotBussinessLayer;
using ParkingLotModelLayer;
using System;
using System.Net;

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
            try
            {
                if (parkingResult != null)
                {
                    return this.Ok(new Response(HttpStatusCode.OK, "List of Parking Data", parkingResult));
                }
                return this.NotFound();
            }
            catch (Exception)
            {

                return this.BadRequest();
            }
        }

        [HttpPut]
        public IActionResult Unparking(int parkingSlotId)
        {
            var unparkingResult = this.parkingLotBussiness.Unparking(parkingSlotId);
            try
            {
                if (unparkingResult != null)
                {
                    return this.Ok(new Response(HttpStatusCode.OK, "List of Parking Data", parkingResult));
                }
                return this.NotFound();
            }
            catch (Exception)
            {

                return this.BadRequest();
            }
        }
    }
}
