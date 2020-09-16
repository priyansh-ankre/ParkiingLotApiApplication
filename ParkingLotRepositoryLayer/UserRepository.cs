using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using ParkingLotModelLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ParkingLotRepositoryLayer
{
    public class UserRepository : IUserRepository
    {
        private readonly IConfiguration configuration;
        private readonly string connectionString;
        private readonly SqlConnection sqlConnection;
        private IDistributedCache distributedCache;

        public UserRepository(IConfiguration configuration,IDistributedCache distributedCache)
        {
            this.configuration = configuration;
            this.connectionString = this.configuration.GetConnectionString("UserDbConnection");
            this.sqlConnection = new SqlConnection(connectionString);
            this.distributedCache = distributedCache;
        }

        public string GenerateToken(UserLogin login)
        {

            try
            {
                var symmetricSecuritykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));

                var signingCreds = new SigningCredentials(symmetricSecuritykey, SecurityAlgorithms.HmacSha256);

                var claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Role, login.Role));
                claims.Add(new Claim("Email", login.Email.ToString()));
                claims.Add(new Claim("Password", login.Password.ToString()));
                var token = new JwtSecurityToken(configuration["Jwt:Issuer"],
                    configuration["Jwt:Issuer"],
                    claims,
                    expires: DateTime.Now.AddHours(120),
                    signingCredentials: signingCreds);
                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
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
            var json = JsonConvert.SerializeObject(userTypesList);
            this.distributedCache.SetString("UserDetails", json);
            return userTypesList;
        }

        public int UserLogin(UserLogin login)
        {
            int count = 0;

            SqlCommand sqlCommand = new SqlCommand("spUserLoginData", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            var encodedPassword = this.EncodePassword(login.Password);
            sqlCommand.Parameters.AddWithValue("Email", login.Email);
            sqlCommand.Parameters.AddWithValue("Password", encodedPassword);
            sqlCommand.Parameters.AddWithValue("Role", login.Role);
            sqlConnection.Open();

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            while (sqlDataReader.Read())
            {
                count++;
            }
            return count;
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
