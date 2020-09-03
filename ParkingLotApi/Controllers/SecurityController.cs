using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkingLotBussinessLayer;
using ParkingLotModelLayer;

namespace ParkingLotApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        private readonly IParkingLotBussiness parkingLotBussiness;
        public SecurityController(IParkingLotBussiness parkingLotBussiness)
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
                return this.NotFound(new Response(HttpStatusCode.NotFound, "List of Parking Data is Not Found", parkingResult));
            }
            catch (Exception)
            {

                return this.BadRequest(new Response(HttpStatusCode.BadRequest, "List of Parking Data cannot be displayed", null));
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
                    return this.Ok(new Response(HttpStatusCode.OK, "List of Parking Data", unparkingResult));
                }
                return this.NotFound(new Response(HttpStatusCode.NotFound, "List of Parking Data is Not Found", unparkingResult));
            }
            catch (Exception)
            {

                return this.BadRequest(new Response(HttpStatusCode.BadRequest, "List of Parking Data cannot be diplayed", null));
            }
        }

        [HttpGet]
        [Route("GetParkingByVehicleNumber")]
        public IActionResult GetParkingDataByVehicleNumber(string vehicleNumber)
        {
            var getResult = this.parkingLotBussiness.GetParkingDataByVehicleNumber(vehicleNumber);
            try
            {
                if (getResult != null)
                {
                    return this.Ok(new Response(HttpStatusCode.OK, "List of Parking Data", getResult));
                }
                return this.NotFound(new Response(HttpStatusCode.NotFound, "List of Parking Data is Not Found", getResult));
            }
            catch (Exception)
            {

                return this.BadRequest(new Response(HttpStatusCode.BadRequest, "List of Parking Data cannot be diplayed", null));
            }
        }

        [HttpGet]
        [Route("{GetParkingByParkingSlot}")]
        public IActionResult GetParkingDataByParkingSlot(int parkingSlot)
        {
            var getResult = this.parkingLotBussiness.GetParkingDataByParkingSlot(parkingSlot);
            try
            {
                if (getResult != null)
                {
                    return this.Ok(new Response(HttpStatusCode.OK, "List of Parking Data", getResult));
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
