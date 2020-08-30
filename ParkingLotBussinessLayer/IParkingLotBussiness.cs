using ParkingLotModelLayer;

namespace ParkingLotBussinessLayer
{
    public interface IParkingLotBussiness
    {
        public object GetAllParkingData();
        public void AddParkingData(Parking parking);
        public void AddParkingTypeData(ParkingType parkingType);
        public void AddRolesData(Roles roles);
        public void AddUserTypeData(UserType userType);
        public void AddVehicleTypeData(VehicleType vehicleType);
        public void DeleteParkingData(int parkingSlot);
        public void DeleteUserTypeData(int userId);
        public object GetParkingDataByVehicleNumber(string vehicleNumber);
        public object GetParkingDataByParkingSlot(string parkingSlot);
    }
}
