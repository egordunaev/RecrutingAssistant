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
    public class PositionDao : BaseDao, IPositionDao
    {
        /// <summary>
        /// Добавить вакансию
        /// </summary>
        /// <param name="position">Вакансия</param>
        public void Add(Position position)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO Position(PositionName, IsOpen, Salary, EmployerID)VALUES(@PositionName, @IsOpen, @Salary, @EmployerID)";
                    cmd.Parameters.AddWithValue("@EmployerID", position.EmployerID);
                    object positionname = (String.IsNullOrEmpty(position.PositionName) == false) ? (object)position.PositionName.ToString() : DBNull.Value;
                    object isopen = (String.IsNullOrEmpty(position.IsOpen) == false) ? (object)position.IsOpen.ToString() : DBNull.Value;
                    object salary = position.Salary.HasValue ? (object)position.Salary.Value : DBNull.Value;
                    cmd.Parameters.AddWithValue("@PositionName", positionname);
                    cmd.Parameters.AddWithValue("@IsOpen", isopen);
                    cmd.Parameters.AddWithValue("@Salary", salary);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        /// <summary>
        /// Удалить вакансию
        /// </summary>
        /// <param name="PositionID">Номер вакансии</param>
        public void Delete(int PositionID)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM Position WHERE PositionID=@PositionID";
                    cmd.Parameters.AddWithValue("@PositionID", PositionID);
                }
            }
        }
        /// <summary>
        /// Получить вакансию
        /// </summary>
        /// <param name="PositionID">Номер вакансии</param>
        /// <returns></returns>
        public Position Get(int PositionID)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT PositionID, PositionName, IsOpen, Salary, EmployerID FROM Postion WHERE PositionID=@PositionID";
                    cmd.Parameters.AddWithValue("@PositionID", PositionID);
                    using (var datareader = cmd.ExecuteReader())
                    {
                        if (datareader.Read())
                        {
                            return !datareader.Read() ? null : LoadPosition(datareader);
                        }
                        return null;
                    }
                }
            }
        }
        /// <summary>
        /// Получить все вакансии
        /// </summary>
        /// <returns></returns>
        public IList<Position> GetAll()
        {
            IList<Position> positions = new List<Position>();
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT PositionID, PositionName, IsOpen, Salary, EmployerID FROM Position";
                    using (var datareader = cmd.ExecuteReader())
                    {
                        while (datareader.Read())
                        {
                            positions.Add(LoadPosition(datareader));
                        }
                    }
                }
            }
            return positions;
        }
        /// <summary>
        /// Изменить вакансию
        /// </summary>
        /// <param name="position">Вакансия</param>
        public void Update(Position position)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "UPDATE Position SET PositionName=@PositionName, IsOpen=@IsOpen, Salary=@Salary, EmployerID=@EmployerID WHERE PositionID=@PositionID)";
                    cmd.Parameters.AddWithValue("@EmployerID", position.EmployerID);
                    object positionname = (String.IsNullOrEmpty(position.PositionName) == false) ? (object)position.PositionName.ToString() : DBNull.Value;
                    object isopen = (String.IsNullOrEmpty(position.IsOpen) == false) ? (object)position.IsOpen.ToString() : DBNull.Value;
                    object salary = position.Salary.HasValue ? (object)position.Salary.Value : DBNull.Value;
                    cmd.Parameters.AddWithValue("@PositionName", positionname);
                    cmd.Parameters.AddWithValue("@IsOpen", isopen);
                    cmd.Parameters.AddWithValue("@Salary", salary);
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
        /// Загрузить вакансию
        /// </summary>
        /// <param name="reader">Считыватель</param>
        /// <returns></returns>
        private static Position LoadPosition(SqlDataReader reader)
        {
            Position position = new Position();
            position.PositionID = reader.GetInt16(reader.GetOrdinal("PositionID"));
            int posemp = reader.GetOrdinal("EmployerID");
            position.EmployerID = reader[posemp] == DBNull.Value ? -1 : reader.GetInt32(posemp);
            object positionname = reader["PositionName"];
            object isopen = reader["IsOpen"];
            object salary = reader["Salary"];
            if (positionname != DBNull.Value)
                position.PositionName = reader.GetString(reader.GetOrdinal("PositionName"));
            if (isopen != DBNull.Value)
                position.IsOpen = reader.GetString(reader.GetOrdinal("IsOpen"));
            if (salary != DBNull.Value)
                position.Salary = Convert.ToDecimal(reader["Salary"]);
            return position;
        }
    }
}
