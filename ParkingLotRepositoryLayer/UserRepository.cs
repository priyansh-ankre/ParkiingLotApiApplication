using ParkingLotModelLayer;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ParkingLotRepositoryLayer
{
    public class UserRepository : IUserRepository
    {
        public static readonly string connectionString = "Server=(LocalDB)\\MSSQLLocalDB;Database=ParkingLotDatabase;Trusted_Connection=True";

        SqlConnection sqlConnection = new SqlConnection(connectionString);

        public IEnumerable<UserType> GetUsers()
        {
            List<UserType> userTypesList = new List<UserType>();

            SqlCommand sqlCommand = new SqlCommand("spGetUserTypeData", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            while (sqlDataReader.Read())
            {
                UserType userType = new UserType();

                userType.Email = sqlDataReader["Email"].ToString();
                userType.Password = sqlDataReader["Password"].ToString();
                userType.Role = sqlDataReader["Role"].ToString();

                userTypesList.Add(userType);
            }
            return userTypesList;
        }

        public UserType AddUserTypeData(UserType userType)
        {
            SqlCommand sqlCommand = new SqlCommand("spAddUserTypeData", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            sqlCommand.Parameters.AddWithValue("Email", userType.Email);
            sqlCommand.Parameters.AddWithValue("Password", userType.Password);
            sqlCommand.Parameters.AddWithValue("Role", userType.Role);

            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            return userType;
        }

        public object DeleteUserTypeData(int userId)
        {
            SqlCommand sqlCommand = new SqlCommand("spDeleteUserTypeData", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            sqlCommand.Parameters.AddWithValue("@UserId", userId);

            sqlConnection.Open();
            var result = sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            return result;
        }
    }
}
