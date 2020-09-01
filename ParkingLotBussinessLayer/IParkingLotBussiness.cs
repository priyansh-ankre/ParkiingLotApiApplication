using ParkingLotModelLayer;
using System.Collections.Generic;

namespace ParkingLotBussinessLayer
{
    public interface IParkingLotBussiness
    {
        IEnumerable<Parking> GetAllParkingData();
        Parking AddParkingData(Parking parking);
        ParkingType AddParkingTypeData(ParkingType parkingType);
        Roles AddRolesData(Roles roles);
        VehicleType AddVehicleTypeData(VehicleType vehicleType);
        object DeleteParkingDataByParkingSlot(int parkingSlot);
        object DeleteAllUnParkedData();
        Parking GetParkingDataByVehicleNumber(string vehicleNumber);
        Parking GetParkingDataByParkingSlot(int parkingSlot);
        object Unparking(int parkingSlot);
    }
}
