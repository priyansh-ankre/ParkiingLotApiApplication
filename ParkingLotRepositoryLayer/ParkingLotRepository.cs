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
                parking.RolesId = Convert.ToInt32(sqlDataReader["RolesId"]);
                parking.Disabled = Convert.ToBoolean(sqlDataReader["Disabled"]);
                parking.ExitTime = sqlDataReader["ExitTime"].ToString();
                parking.Charges = Convert.ToInt32(sqlDataReader["Charges"]);

                parkingList.Add(parking);
            }
            return parkingList;
        }

        public Parking AddParkingData(Parking parking)
        {
            SqlCommand sqlCommand = new SqlCommand("spAddParkingData(Parking)", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

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
            int i = sqlCommand.ExecuteNonQuery();
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

        public Parking GetParkingDataByParkingSlot(int parkingSlot)
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

        public object Unparking(int parkingSlot)
        {
            SqlCommand sqlCommand = new SqlCommand("spUnparking", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            sqlCommand.Parameters.AddWithValue("@ParkingSlot", parkingSlot);

            sqlConnection.Open();
            var result = sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            return result;
        }
    }
}
