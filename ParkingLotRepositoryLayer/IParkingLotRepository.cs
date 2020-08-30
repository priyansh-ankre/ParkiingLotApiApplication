using ParkingLotModelLayer;
using System.Collections.Generic;

namespace ParkingLotRepositoryLayer
{
    public interface IParkingLotRepository
    {
        public IEnumerable<Parking> GetAllParkingData();
        public void AddParkingData(Parking parking);
        public void AddParkingTypeData(ParkingType parkingType);
        public void AddRolesData(Roles roles);
        public void AddUserTypeData(UserType userType);
        public void AddVehicleTypeData(VehicleType vehicleType);
        public void DeleteParkingData(int parkingSlot);
        public void DeleteUserTypeData(int userId);
        public Parking GetParkingDataByVehicleNumber(string vehicleNumber);
        public Parking GetParkingDataByParkingSlot(string parkingSlot);
    }
}
