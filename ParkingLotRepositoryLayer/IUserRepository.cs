using ParkingLotModelLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLotRepositoryLayer
{
    public interface IUserRepository
    {
        IEnumerable<UserType> GetUsers();
        UserType AddUserTypeData(UserType userType);
        object DeleteUserTypeData(int userId);
    }
}
