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
    public class EmployerDao : BaseDao, IEmployerDao
    {
        private static IDictionary<int, Employer> _Employers;
        /// <summary>
        /// Добавить нового работодателя
        /// </summary>
        /// <param name="employer">Работодатель</param>
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
        /// <summary>
        /// Удалить работодателя
        /// </summary>
        /// <param name="EmployerID">Номер работодателя</param>
        public void Delete(int EmployerID)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM Employer WHERE EmployerID=@EmployerID";
                    cmd.Parameters.AddWithValue("@EmployerID", EmployerID);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        /// <summary>
        /// Получить работодателя
        /// </summary>
        /// <param name="EmployerID">Номер работодателя</param>
        /// <returns></returns>
        public Employer Get(int EmployerID)
        {
            if (_Employers == null)
                Load();
            return _Employers.ContainsKey(EmployerID) ? _Employers[EmployerID] : null;
        }
        /// <summary>
        /// Получить всех работодателей
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// Изменить работодателя
        /// </summary>
        /// <param name="employer">Работодатель</param>
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
        /// <summary>
        /// Получить строку для подключения к базе
        /// </summary>
        /// <returns></returns>
        private static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["RecrutingDB"].ConnectionString;
        }
        /// <summary>
        /// Подключиться к базе
        /// </summary>
        /// <returns></returns>
        private static SqlConnection GetConnection()
        {
            return new SqlConnection(GetConnectionString());
        }
        /// <summary>
        /// Загрузить работодателя
        /// </summary>
        /// <param name="reader">Считыватель</param>
        /// <returns></returns>
        private static Employer LoadEmployer(SqlDataReader reader)
        {
            Employer employer = new Employer();
            employer.EmployerID = reader.GetInt32(reader.GetOrdinal("EmployerID"));
            int empwork = reader.GetOrdinal("WorkID");
            employer.WorkID = reader[empwork] == DBNull.Value ? -1 : reader.GetInt32(empwork);
            employer.Name = reader.GetString(reader.GetOrdinal("Name"));
            employer.Address = reader.GetString(reader.GetOrdinal("Address"));
            object phonenumber = reader["PhoneNumber"];
            if (phonenumber != DBNull.Value)
                employer.PhoneNumber = reader.GetString(reader.GetOrdinal("PhoneNumber"));
            return employer;
        }
        private IList<Employer> LoadInternal()
        {
            IList<Employer> employers = new List<Employer>();
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT EmployerID, Name, Address, PhoneNumber, WorkID FROM Employer";
                    cmd.CommandType = System.Data.CommandType.Text;
                    using (var reader = cmd.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            employers.Add(LoadEmployer(reader));
                        }
                    }
                }
            }
            return employers;
        }
        public IList<Employer> Load()
        {
            _Employers = new Dictionary<int, Employer>();
            var employers = LoadInternal();
            foreach(var employer in employers)
            {
                _Employers.Add(employer.EmployerID, employer);
            }
            return _Employers.Values.ToList();
        }
        public void Reset(int EmployerID)
        {
            if (_Employers == null)
                return;
             _Employers.Clear();
        }
    }
}
