using Microsoft.Extensions.Configuration;
using ParkingLotModelLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ParkingLotRepositoryLayer
{
    public class UserRepository : IUserRepository
    {
        private readonly IConfiguration configuration;
        private readonly string connectionString;
        private readonly SqlConnection sqlConnection;
        public UserRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.connectionString = this.configuration.GetConnectionString("UserDbConnection");
            this.sqlConnection = new SqlConnection(connectionString);
        }

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

                userType.UserId =Convert.ToInt32(sqlDataReader["UserId"]);
                userType.Email = sqlDataReader["Email"].ToString();
                userType.Password = sqlDataReader["Password"].ToString();
                userType.Role = sqlDataReader["Role"].ToString();

                userTypesList.Add(userType);
            }
            return userTypesList;
        }

        public string EncodePassword(string password)
        {
            try
            {
                byte[] encPassword = new byte[password.Length];
                encPassword = Encoding.UTF8.GetBytes(password);
                string encodedPassword = Convert.ToBase64String(encPassword);
                return encodedPassword;
            }
            catch (Exception ex)
            {
                throw new Exception("Exception occured: "+ex);
            }
        }

        public UserType AddUserTypeData(UserType userType)
        {
            
            SqlCommand sqlCommand = new SqlCommand("spAddUserTypeData", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            var encodedPassword = this.EncodePassword(userType.Password);

            sqlCommand.Parameters.AddWithValue("Email", userType.Email);
            sqlCommand.Parameters.AddWithValue("Password", encodedPassword);
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
