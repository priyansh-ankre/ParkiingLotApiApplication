using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkingLotBussinessLayer;

namespace ParkingLotApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeleteOwnerController : ControllerBase
    {
        private readonly IParkingLotBussiness parkingLotBussiness;
        public DeleteOwnerController(IParkingLotBussiness parkingLotBussiness)
        {
            this.parkingLotBussiness = parkingLotBussiness;
        }

        [HttpDelete]
        public IActionResult DeleteAllUnparkedData()
        {
            var deleteResult = this.parkingLotBussiness.DeleteAllUnParkedData();
            if(deleteResult != null)
            {
                return this.Ok(deleteResult);
            }
            return this.BadRequest();
        } 
    }
}
