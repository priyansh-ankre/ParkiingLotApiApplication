using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ParkingLotBussinessLayer;
using ParkingLotModelLayer;
using System;
using System.Net;

namespace ParkingLotApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme,Roles ="POLICE,OWNER")]
    public class PoliceController : ControllerBase
    {
        private readonly IParkingLotBussiness parkingLotBussiness;
        private readonly MSMQ mSMQ = new MSMQ();
        public PoliceController(IParkingLotBussiness parkingLotBussiness)
        {
            this.parkingLotBussiness = parkingLotBussiness;
        }

        [HttpPost]
        [Route("Park")]
        public IActionResult AddParking([FromBody] Parking parking)
        {

            var parkingResult = this.parkingLotBussiness.AddParkingData(parking);
            try
            {
                if (parkingResult != null)
                {
                    mSMQ.Sender("Driver Parked Vehicle Having Number: " + parking.VehicleNumber);
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
        [Route("Unpark/{parkingSlot:int}")]
        public IActionResult Unparking(int parkingSlot)
        {
            var unparkingResult = this.parkingLotBussiness.Unparking(parkingSlot);
            try
            {
                if (unparkingResult != null)
                {
                    mSMQ.Sender("Driver unParked Vehicle Having Parking Slot: " + parkingSlot);
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
        [Route("GetParkingDetails/&vehicleNumber={vehicleNumber}")]
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
        [Route("GetParkingDetails/&parkingSlot={parkingSlot:int}")]
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
