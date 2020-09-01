using ParkingLotModelLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLotBussinessLayer
{
    public interface IUserBussiness
    {
        IEnumerable<UserType> GetUsers();
        UserType AddUserTypeData(UserType userType);
        object DeleteUserTypeData(int userId);
    }
}
