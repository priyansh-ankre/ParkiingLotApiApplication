using System;
using System.Collections.Generic;
using System.Linq;
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

        [HttpPost]
        [Route("GetParkingByVehicleNumber")]
        public IActionResult GetParkingDataByVehicleNumber(string vehicleNumber)
        {
            var getResult = this.parkingLotBussiness.GetParkingDataByVehicleNumber(vehicleNumber);
            if (getResult != null)
            {
                return this.Ok(getResult);
            }
            return this.BadRequest();
        }

        [HttpPost]
        [Route("GetParkingByParkingSlot")]
        public IActionResult GetParkingDataByParkingSlot(int parkingSlot)
        {
            var getResult = this.parkingLotBussiness.GetParkingDataByParkingSlot(parkingSlot);
            if (getResult != null)
            {
                return this.Ok(getResult);
            }
            return this.BadRequest();
        }
    }
}
