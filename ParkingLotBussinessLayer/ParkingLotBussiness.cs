using ParkingLotModelLayer;
using ParkingLotRepositoryLayer;
using System.Collections.Generic;

namespace ParkingLotBussinessLayer
{
    public class ParkingLotBussiness : IParkingLotBussiness
    {
        public readonly IParkingLotRepository parkingLot;
        public ParkingLotBussiness(IParkingLotRepository parkingLot)
        {
            this.parkingLot = parkingLot;
        }

        public IEnumerable<Parking> GetAllParkingData()
        {
            return parkingLot.GetAllParkingData();
        }

        public Parking AddParkingData(Parking parking)
        {
            return parkingLot.AddParkingData(parking);
        }

        public ParkingType AddParkingTypeData(ParkingType parkingType)
        {
            return parkingLot.AddParkingTypeData(parkingType);
        }

        public Roles AddRolesData(Roles roles)
        {
            return parkingLot.AddRolesData(roles);
        }
        
        public VehicleType AddVehicleTypeData(VehicleType vehicleType)
        {
            return parkingLot.AddVehicleTypeData(vehicleType);
        }
        
        public object DeleteParkingDataByParkingSlot(int parkingSlot)
        {
            return parkingLot.DeleteParkingDataByParkingSlot(parkingSlot);
        }

        public object DeleteAllUnParkedData()
        {
            return parkingLot.DeleteAllUnParkedData();
        }
        
        public Parking GetParkingDataByVehicleNumber(string vehicleNumber)
        {
            return parkingLot.GetParkingDataByVehicleNumber(vehicleNumber);
        }

        public Parking GetParkingDataByParkingSlot(int parkingSlot)
        {
            return parkingLot.GetParkingDataByParkingSlot(parkingSlot);
        }

        public object Unparking(int parkingSlot, string exitTime, int charges)
        {
            return parkingLot.Unparking(parkingSlot,exitTime,charges);
        }
    }
}
