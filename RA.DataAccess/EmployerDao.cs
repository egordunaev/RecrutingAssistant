using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RA.DataAccess.Entities;
using System.Data.SqlClient;
using System.Configuration;

namespace RA.DataAccess
{
    public class EmployerDao : IEmployerDao
    {
        public void Add(Employer employer)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO Employer(Name, Address, PhoneNumber, WorkID)VALUES(@Name, @Address, @PhoneNumber, @WorkID)";
                    cmd.Parameters.AddWithValue("@Name", employer.Name);
                    cmd.Parameters.AddWithValue("@Address", employer.Address);
                    cmd.Parameters.AddWithValue("@WorkID", employer.WorkID);
                    object phonenumber = (String.IsNullOrEmpty(employer.PhoneNumber)==false) ? (object)employer.PhoneNumber.ToString() : DBNull.Value;
                    cmd.Parameters.AddWithValue("@PhoneNumber", phonenumber);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int EmployerID)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM Employer WHERE EmployerID=@EmployerID";
                    cmd.Parameters.AddWithValue("@EmployerID", EmployerID);
                }
            }
        }

        public Employer Get(int EmployerID)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT EmployerID, Name, Address, PhoneNumber, WorkID FROM Employer WHERE EmployerID=@EmployerID";
                    cmd.Parameters.AddWithValue("@EmployerID", EmployerID);
                    using (var datareader = cmd.ExecuteReader())
                    {
                        if (datareader.Read())
                        {
                            return !datareader.Read() ? null : LoadEmployer(datareader);
                        }
                        return null;
                    }
                }
            }
        }

        public IList<Employer> GetAll()
        {
            IList<Employer> employers = new List<Employer>();
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT EmployerID, Name, Address, PhoneNumber, WorkID FROM Employer";
                    using (var datareader = cmd.ExecuteReader())
                    {
                        while (datareader.Read())
                        {
                            employers.Add(LoadEmployer(datareader));
                        }
                    }
                }
            }
            return employers;
        }

        public void Update(Employer employer)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "UPDATE Employer SET Name=@Name, Address=@Address, PhoneNumber=@PhoneNumber, WorkID=@WorkID WHERE EmployerID=@EmployerID)";
                    cmd.Parameters.AddWithValue("@Name", employer.Name);
                    cmd.Parameters.AddWithValue("@Address", employer.Address);
                    cmd.Parameters.AddWithValue("@WorkID", employer.WorkID);
                    object phonenumber = (String.IsNullOrEmpty(employer.PhoneNumber) == false) ? (object)employer.PhoneNumber.ToString() : DBNull.Value;
                    cmd.Parameters.AddWithValue("@PhoneNumber", phonenumber);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        private static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["RecrutingDB"].ConnectionString;
        }
        private static SqlConnection GetConnection()
        {
            return new SqlConnection(GetConnectionString());
        }
        private static Employer LoadEmployer(SqlDataReader reader)
        {
            Employer employer = new Employer();
            employer.EmployerID = reader.GetInt32(reader.GetOrdinal("EmployerID"));
            employer.WorkID = reader.GetInt32(reader.GetOrdinal("WorkID"));
            employer.Name = reader.GetString(reader.GetOrdinal("Name"));
            employer.Address = reader.GetString(reader.GetOrdinal("Address"));
            object phonenumber = reader["PhoneNumber"];
            if (phonenumber != DBNull.Value)
                employer.PhoneNumber = reader.GetString(reader.GetOrdinal("PhoneNumber"));
            return employer;
        }
    }
}
