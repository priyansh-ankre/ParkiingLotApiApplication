using ParkingLotModelLayer;
using ParkingLotRepositoryLayer;

namespace ParkingLotBussinessLayer
{
    public class ParkingLotBussiness : IParkingLotBussiness
    {
        public readonly IParkingLotRepository parkingLot;

        public object GetAllParkingData()
        {
            return parkingLot.GetAllParkingData();
        }

        public void AddParkingData(Parking parking)
        {
            parkingLot.AddParkingData(parking);
        }

        public void AddParkingTypeData(ParkingType parkingType)
        {
            parkingLot.AddParkingTypeData(parkingType);
        }

        public void AddRolesData(Roles roles)
        {
            parkingLot.AddRolesData(roles);
        }
        
        public void AddUserTypeData(UserType userType)
        {
            parkingLot.AddUserTypeData(userType);
        }
        
        public void AddVehicleTypeData(VehicleType vehicleType)
        {
            parkingLot.AddVehicleTypeData(vehicleType);
        }
        
        public void DeleteParkingData(int parkingSlot)
        {
            parkingLot.DeleteParkingData(parkingSlot);
        }
        
        public void DeleteUserTypeData(int userId)
        {
            parkingLot.DeleteUserTypeData(userId);
        }
    }
}
