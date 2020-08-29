using ParkingLotModelLayer;
using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
