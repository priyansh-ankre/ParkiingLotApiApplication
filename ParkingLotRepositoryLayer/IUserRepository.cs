using ParkingLotModelLayer;
using System.Collections.Generic;

namespace ParkingLotRepositoryLayer
{
    public interface IUserRepository
    {
        IEnumerable<UserType> GetUsers();
        UserType AddUserTypeData(UserType userType);
        object DeleteUserTypeData(int userId);
        IEnumerable<UserLogin> UserLogin();
    }
}
