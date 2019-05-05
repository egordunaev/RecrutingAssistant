using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RA.DataAccess.Entities;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows;
using System.Windows.Forms;

namespace RA.DataAccess
{
    public class PositionDao : BaseDao, IPositionDao
    {
        private static IDictionary<int, Position> Positions;
        private IList<Position> LoadInternal()
        {
            IList<Position> positions = new List<Position>();
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT PositionID, PositionName, IsOpen, Salary, EmployerID FROM Position";
                    cmd.CommandType = System.Data.CommandType.Text;
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            positions.Add(LoadPosition(reader));
                        }
                    }
                }
            }
            return positions;
        }
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
                    cmd.ExecuteNonQuery();
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
            if (Positions == null)
                Load();
            return Positions.ContainsKey(PositionID) ? Positions[PositionID] : null;
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
                    cmd.Parameters.AddWithValue("@PositionID", position.PositionID);
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
            position.PositionID = reader.GetInt32(reader.GetOrdinal("PositionID"));
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

        public IList<Position> Load()
        {
            Positions = new Dictionary<int, Position>();
            var positions = LoadInternal();
            foreach(var position in positions)
            {
                Positions.Add(position.PositionID, position);
            }
            return Positions.Values.ToList();
        }
        public void Reset()
        {
            if (Positions == null)
                return;
            Positions.Clear();
        }

        public IList<Position> SearchPosition(string PositionName, string Employer)
        {
            try
            {
                IList<Position> positions = new List<Position>();
                using (var conn = GetConnection())
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SELECT PositionID, PositionName, IsOpen, Salary, Position.EmployerID FROM Position JOIN Employer on Position.EmployerID = Employer.EmployerID WHERE PositionName like @Name AND Employer.Name like @Employer";
                        cmd.Parameters.AddWithValue("@Name", "%" + PositionName + "%");
                        cmd.Parameters.AddWithValue("@Employer", "%" + Employer);
                        using (var dataReader = cmd.ExecuteReader())
                        {
                            while (dataReader.Read())
                            {
                                positions.Add(LoadPosition(dataReader));
                            }
                        }
                    }
                }

                return positions;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString(), "ERROR");
                throw;
            }
        }
    }
}
