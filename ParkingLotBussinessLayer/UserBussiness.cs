using System.Collections.Generic;
using ParkingLotRepositoryLayer;
using ParkingLotModelLayer;
using ParkingLotBussinessLayer;

namespace userRepositoryBussinessLayer
{
    public class UserBussiness : IUserBussiness
    {
        public readonly IUserRepository userRepository;
        public UserBussiness(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public IEnumerable<UserType> GetUsers()
        {
            return userRepository.GetUsers();
        }

        public UserType AddUserTypeData(UserType userType)
        {
            return userRepository.AddUserTypeData(userType);
        }

        public object DeleteUserTypeData(int userId)
        {
            return userRepository.DeleteUserTypeData(userId);
        }

        public IEnumerable<UserLogin> UserLogin()
        {
            return userRepository.UserLogin();
        }
    }
}
