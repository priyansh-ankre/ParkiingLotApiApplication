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
        
        public UserType AddUserTypeData(UserType userType)
        {
            return parkingLot.AddUserTypeData(userType);
        }
        
        public VehicleType AddVehicleTypeData(VehicleType vehicleType)
        {
            return parkingLot.AddVehicleTypeData(vehicleType);
        }
        
        public object DeleteParkingData(int parkingSlot)
        {
            return parkingLot.DeleteParkingData(parkingSlot);
        }
        
        public object DeleteUserTypeData(int userId)
        {
            return parkingLot.DeleteUserTypeData(userId);
        }

        public Parking GetParkingDataByVehicleNumber(string vehicleNumber)
        {
            return parkingLot.GetParkingDataByVehicleNumber(vehicleNumber);
        }

        public Parking GetParkingDataByParkingSlot(int parkingSlot)
        {
            return parkingLot.GetParkingDataByParkingSlot(parkingSlot);
        }

        public object Unparking(int parkingSlot)
        {
            return parkingLot.Unparking(parkingSlot);
        }
    }
}
