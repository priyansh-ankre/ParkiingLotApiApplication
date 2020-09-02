using Microsoft.AspNetCore.Mvc;
using ParkingLotBussinessLayer;
using ParkingLotModelLayer;
using System;
using System.Net;

namespace ParkingLotApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly IParkingLotBussiness parkingLotBussiness;
        public OwnerController(IParkingLotBussiness parkingLotBussiness)
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
                    return this.Ok(new Response(HttpStatusCode.OK,"List of Parking Data",parkingResult));
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
                    return this.Ok(new Response(HttpStatusCode.OK, "List of Parking Data", unparkingResult));
                }
                return this.NotFound();
            }
            catch (Exception)
            {

                return this.BadRequest();
            }
        }

        [HttpGet]
        public IActionResult GetAllParkingData()
        {
            var getResult = this.parkingLotBussiness.GetAllParkingData();
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
                return this.NotFound();
            }
            catch (Exception)
            {

                return this.BadRequest();
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
                    return this.Ok(getResult);
                }
                return this.NotFound();
            }
            catch (Exception)
            {

                return this.BadRequest();
            }
        }

        [HttpDelete]
        [Route("DeleteAllUnparkedData")]
        public IActionResult DeleteAllUnparkedData()
        {
            var deleteResult = this.parkingLotBussiness.DeleteAllUnParkedData();
            try
            {
                if (deleteResult != null)
                {
                    return this.Ok(new Response(HttpStatusCode.OK, "List of Parking Data", deleteResult));
                }
                return this.NotFound();
            }
            catch (Exception)
            {

                return this.BadRequest();
            }
        }

        [HttpDelete]
        [Route("{DeleteParkingDataByParkingSlot}")]
        public IActionResult DeleteParkingDataByParkingSlot(int parkingSlot)
        {
            var deleteResult = parkingLotBussiness.DeleteParkingDataByParkingSlot(parkingSlot);
            try
            {
                if (deleteResult != null)
                {
                    return this.Ok(new Response(HttpStatusCode.OK, "List of Parking Data", deleteResult));
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
