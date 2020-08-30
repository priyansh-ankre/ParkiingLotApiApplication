using ParkingLotModelLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ParkingLotRepositoryLayer
{
    public class ParkingLotRepository : IParkingLotRepository
    {
        public static readonly string connectionString = "Server=(LocalDB)\\MSSQLLocalDB;Database=ParkingLotDatabase;Trusted_Connection=True";

        SqlConnection sqlConnection = new SqlConnection(connectionString);

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
                parking.RolesId = Convert.ToInt32(sqlDataReader["RoleId"]);
                parking.Disabled = Convert.ToBoolean(sqlDataReader["Disabled"]);
                parking.ExitTime = sqlDataReader["ExitTime"].ToString();
                parking.Charges = Convert.ToInt32(sqlDataReader["Charges"]);

                parkingList.Add(parking);
            }
            return parkingList;
        }

        public void AddParkingData(Parking parking)
        {
            SqlCommand sqlCommand = new SqlCommand("spAddParkingData(Parking)", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            sqlCommand.Parameters.AddWithValue("@Id", parking.Id);
            sqlCommand.Parameters.AddWithValue("@ParkingSLot", parking.ParkingSLot);
            sqlCommand.Parameters.AddWithValue("@VehicleNumber", parking.VehicleNumber);
            sqlCommand.Parameters.AddWithValue("@EntryTime", parking.EntryTime);
            sqlCommand.Parameters.AddWithValue("@VehicleId", parking.VehicleId);
            sqlCommand.Parameters.AddWithValue("@ParkingId", parking.ParkingId);
            sqlCommand.Parameters.AddWithValue("@RolesId", parking.RolesId);
            sqlCommand.Parameters.AddWithValue("@Disabled", parking.Disabled);
            sqlCommand.Parameters.AddWithValue("@ExitTime", parking.ExitTime);
            sqlCommand.Parameters.AddWithValue("@Charges", parking.Charges);

            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public void AddParkingTypeData(ParkingType parkingType)
        {
            SqlCommand sqlCommand = new SqlCommand("spAddParkingTypeData", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            sqlCommand.Parameters.AddWithValue("ParkingTypes", parkingType.ParkingTypes);

            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public void AddRolesData(Roles roles)
        {
            SqlCommand sqlCommand = new SqlCommand("spAddRolesData", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            sqlCommand.Parameters.AddWithValue("Role", roles.Role);

            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public void AddUserTypeData(UserType userType)
        {
            SqlCommand sqlCommand = new SqlCommand("spAddUserTypeData", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            sqlCommand.Parameters.AddWithValue("Email", userType.Email);
            sqlCommand.Parameters.AddWithValue("Password", userType.Password);
            sqlCommand.Parameters.AddWithValue("Role", userType.Role);

            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public void AddVehicleTypeData(VehicleType vehicleType)
        {
            SqlCommand sqlCommand = new SqlCommand("spAddVehicleTypeData", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            sqlCommand.Parameters.AddWithValue("VehicleTypes", vehicleType.VehicleTypes);

            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public void DeleteParkingData(int parkingSlot)
        {
            SqlCommand sqlCommand = new SqlCommand("spDeleteParkingData", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            sqlCommand.Parameters.AddWithValue("@ParkingSlot", parkingSlot);

            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public void DeleteUserTypeData(int userId)
        {
            SqlCommand sqlCommand = new SqlCommand("spDeleteUserTypeData", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            sqlCommand.Parameters.AddWithValue("@UserId", userId);

            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public Parking GetParkingDataByVehicleNumber(string vehicleNumber)
        {
            Parking parking = new Parking();
            string sqlQuery = "Select * From Parking Where VehicleNumber=" + vehicleNumber;
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
                parking.RolesId = Convert.ToInt32(sqlDataReader["RoleId"]);
                parking.Disabled = Convert.ToBoolean(sqlDataReader["Disabled"]);
                parking.ExitTime = sqlDataReader["ExitTime"].ToString();
                parking.Charges = Convert.ToInt32(sqlDataReader["Charges"]);
            }
            return parking;
        }

        public Parking GetParkingDataByParkingSlot(string parkingSlot)
        {
            Parking parking = new Parking();
            string sqlQuery = "Select * From Parking Where VehicleNumber=" + parkingSlot;
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
                parking.RolesId = Convert.ToInt32(sqlDataReader["RoleId"]);
                parking.Disabled = Convert.ToBoolean(sqlDataReader["Disabled"]);
                parking.ExitTime = sqlDataReader["ExitTime"].ToString();
                parking.Charges = Convert.ToInt32(sqlDataReader["Charges"]);
            }
            return parking;
        }
    }
}
