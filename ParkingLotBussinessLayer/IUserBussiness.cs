using ParkingLotModelLayer;
using System.Collections.Generic;

namespace ParkingLotBussinessLayer
{
    public interface IUserBussiness
    {
        IEnumerable<UserType> GetUsers();
        UserType AddUserTypeData(UserType userType);
        object DeleteUserTypeData(int userId);
        IEnumerable<UserLogin> UserLogin();
    }
}
