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
    public class ParkingLotRepository : IParkingLotRepository
    {
        private readonly IConfiguration configuration;
        private readonly string connectionString;
        private readonly SqlConnection sqlConnection;
        private readonly IDistributedCache distributedCache;
        public ParkingLotRepository(IConfiguration configuration, IDistributedCache distributedCache)
        {
            this.configuration = configuration;
            this.connectionString = this.configuration.GetConnectionString("UserDbConnection");
            this.sqlConnection = new SqlConnection(connectionString);
            this.distributedCache = distributedCache;
        }



        public IEnumerable<Parking> GetAllParkingData()
        {
            List<Parking> parkingList = new List<Parking>();
            SqlCommand sqlCommand = new SqlCommand("spGetAllParkingData", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            while (sqlDataReader.Read())
            {
                Parking parking = new Parking();

                parking.Id = Convert.ToInt32(sqlDataReader["Id"]);
                parking.ParkingSLot = Convert.ToInt32(sqlDataReader["ParkingSlot"]);
                parking.VehicleNumber = sqlDataReader["VehicleNumber"].ToString();
                parking.EntryTime = sqlDataReader["EntryTime"].ToString();
                parking.VehicleId = Convert.ToInt32(sqlDataReader["VehicleId"]);
                parking.ParkingId = Convert.ToInt32(sqlDataReader["ParkingId"]);
                parking.RolesId = Convert.ToInt32(sqlDataReader["RolesId"]);
                parking.Disabled = Convert.ToBoolean(sqlDataReader["Disabled"]);
                parking.ExitTime = sqlDataReader["ExitTime"].ToString();
                parking.Charges = Convert.ToInt32(sqlDataReader["Charges"]);

                parkingList.Add(parking);
            }
            this.PutListToCache(parkingList);
            return parkingList;
        }

        public Parking AddParkingData(Parking parking)
        {
            
            SqlCommand sqlCommand = new SqlCommand("spAddParkingData(Parking)", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            sqlCommand.Parameters.AddWithValue("@ParkingSLot", parking.ParkingSLot);
            sqlCommand.Parameters.AddWithValue("@VehicleNumber", parking.VehicleNumber);
            sqlCommand.Parameters.AddWithValue("@VehicleId", parking.VehicleId);
            sqlCommand.Parameters.AddWithValue("@ParkingId", parking.ParkingId);
            sqlCommand.Parameters.AddWithValue("@RolesId", parking.RolesId);
            sqlCommand.Parameters.AddWithValue("@Charges", parking.Charges);

            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            return parking;
        }

        public ParkingType AddParkingTypeData(ParkingType parkingType)
        {
            SqlCommand sqlCommand = new SqlCommand("spAddParkingTypeData", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;


            sqlCommand.Parameters.AddWithValue("ParkingTypes", parkingType.ParkingTypes);

            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            return parkingType;
        }

        public Roles AddRolesData(Roles roles)
        {
            SqlCommand sqlCommand = new SqlCommand("spAddRolesData", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            sqlCommand.Parameters.AddWithValue("Role", roles.Role);

            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            return roles;
        }

        public VehicleType AddVehicleTypeData(VehicleType vehicleType)
        {
            SqlCommand sqlCommand = new SqlCommand("spAddVehicleTypeData", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            sqlCommand.Parameters.AddWithValue("VehicleTypes", vehicleType.VehicleTypes);

            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            return vehicleType;
        }

        public object DeleteParkingDataByParkingSlot(int parkingSlot)
        {
            SqlCommand sqlCommand = new SqlCommand("spDeleteParkingDataByParkingSlot", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            sqlCommand.Parameters.AddWithValue("@ParkingSlot", parkingSlot);

            sqlConnection.Open();
            var result = sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            return result;
        }

        public object DeleteAllUnParkedData()
        {
            SqlCommand sqlCommand = new SqlCommand("[spDeleteAllUnParkedData]", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            sqlConnection.Open();
            var result = sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            return result;
        }

        public Parking GetParkingDataByVehicleNumber(string vehicleNumber)
        {
            Parking parking = new Parking();
            SqlCommand sqlCommand = new SqlCommand("spGetParkingDataByParkingSlot", sqlConnection);

            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            while (sqlDataReader.Read())
            {

                parking.Id = Convert.ToInt32(sqlDataReader["Id"]);
                parking.ParkingSLot = Convert.ToInt32(sqlDataReader["ParkingSlot"]);
                parking.VehicleNumber = sqlDataReader["VehicleNumber"].ToString();
                parking.EntryTime = sqlDataReader["EntryTime"].ToString();
                parking.VehicleId = Convert.ToInt32(sqlDataReader["VehicleId"]);
                parking.ParkingId = Convert.ToInt32(sqlDataReader["ParkingId"]);
                parking.RolesId = Convert.ToInt32(sqlDataReader["RoleId"]);
                parking.Disabled = Convert.ToBoolean(sqlDataReader["Disabled"]);
                parking.ExitTime = sqlDataReader["ExitTime"].ToString();
                parking.Charges = Convert.ToInt32(sqlDataReader["Charges"]);
            }
            return parking;
        }

        public Parking GetParkingDataByParkingSlot(int parkingSlot)
        {
            try
            {
                Parking parking = new Parking();
                string sqlQuery = "Select * From Parking Where ParkingSlot=" + parkingSlot;
                SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);

                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {

                    parking.Id = Convert.ToInt32(sqlDataReader["Id"]);
                    parking.ParkingSLot = Convert.ToInt32(sqlDataReader["ParkingSlot"]);
                    parking.VehicleNumber = sqlDataReader["VehicleNumber"].ToString();
                    parking.EntryTime = sqlDataReader["EntryTime"].ToString();
                    parking.VehicleId = Convert.ToInt32(sqlDataReader["VehicleId"]);
                    parking.ParkingId = Convert.ToInt32(sqlDataReader["ParkingId"]);
                    parking.RolesId = Convert.ToInt32(sqlDataReader["RolesId"]);
                    parking.Disabled = Convert.ToBoolean(sqlDataReader["Disabled"]);
                    parking.ExitTime = sqlDataReader["ExitTime"].ToString();
                    parking.Charges = Convert.ToInt32(sqlDataReader["Charges"]);
                }
                return parking;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                sqlConnection.Close();
            }

        }

        public object Unparking(int parkingSlot)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand("spUnparking", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@ParkingSlot", parkingSlot);

                sqlConnection.Open();
                var result = sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
                return result;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void PutListToCache(List<Parking> parking)
        {
            var json = JsonConvert.SerializeObject(parking);
            this.distributedCache.SetString("Park", json);
        }
    }
}
