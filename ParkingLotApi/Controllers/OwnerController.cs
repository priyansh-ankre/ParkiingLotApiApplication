using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using ParkingLotBussinessLayer;
using ParkingLotModelLayer;
using System;
using System.Collections.Generic;
using System.Net;

namespace ParkingLotApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme, Roles = "OWNER")]
    public class OwnerController : ControllerBase
    {
        private readonly IParkingLotBussiness parkingLotBussiness;
        private readonly MSMQ mSMQ = new MSMQ();
        public OwnerController(IParkingLotBussiness parkingLotBussiness)
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
                    this.mSMQ.Sender("Driver Parked Vehicle Having Number: " + parking.VehicleNumber);
                    return this.Ok(new Response(HttpStatusCode.Created, "List of Parking Data", parkingResult));
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
                return this.BadRequest(new Response(HttpStatusCode.BadRequest, "List of Parking Data cannot be displayed", null));
            }
        }

        [HttpGet]
        [Route("GetAllParkingData")]
        public IActionResult GetAllParkingData()
        {
            var getResult = this.parkingLotBussiness.GetAllParkingData();
            var jsonResult = JsonConvert.SerializeObject(getResult);
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
                return this.BadRequest(new Response(HttpStatusCode.BadRequest, "List of Parking Data cannot be Displayed", null));
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
                return this.BadRequest(new Response(HttpStatusCode.BadRequest, "List of Parking Data cannot be Displayed", null));
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
                return this.NotFound(new Response(HttpStatusCode.NotFound, "List of Parking Data is Not Found", getResult));
            }
            catch (Exception)
            {
                return this.BadRequest(new Response(HttpStatusCode.BadRequest, "List of Parking Data cannot be displayed", null));
            }
        }

        [HttpDelete]
        [Route("DeleteUnParkingData")]
        public IActionResult DeleteAllUnparkedData()
        {
            var deleteResult = this.parkingLotBussiness.DeleteAllUnParkedData();
            try
            {
                if (deleteResult != null)
                {
                    mSMQ.Sender("all the unparking vehicles information is deleted");
                    return this.Ok(new Response(HttpStatusCode.OK, "List of Parking Data", deleteResult));
                }
                return this.NotFound(new Response(HttpStatusCode.NotFound, "List of Parking Data is Not Found", deleteResult));
            }
            catch (Exception)
            {
                return this.BadRequest(new Response(HttpStatusCode.BadRequest, "List of Parking Data cannot be diplayed", null));
            }
        }

        [HttpDelete]
        [Route("DeleteParkingData/{parkingSlot:int}")]
        public IActionResult DeleteParkingDataByParkingSlot(int parkingSlot)
        {
            var deleteResult = parkingLotBussiness.DeleteParkingDataByParkingSlot(parkingSlot);
            try
            {
                if (deleteResult != null)
                {
                    mSMQ.Sender("Information of vehicle is deleted for Parking Slot: " + parkingSlot);
                    return this.Ok(new Response(HttpStatusCode.OK, "List of Parking Data", deleteResult));
                }
                return this.NotFound(new Response(HttpStatusCode.NotFound, "List of Parking Data is Not Found", deleteResult));
            }
            catch (Exception)
            {
                return this.BadRequest(new Response(HttpStatusCode.BadRequest, "List of Parking Data cannot be displayed", null));
            }
        }

        
    }
}
