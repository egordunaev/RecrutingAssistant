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
    public class JobSeekerDao : BaseDao, IJobSeekerDao
    {
        /// <summary>
        /// Добавить соискателя
        /// </summary>
        /// <param name="seeker">Соискатель</param>
        public void Add(JobSeeker seeker)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO JobSeeker(FirstName, SecondName, ThirdName, Qualification, AssumedSalary, Misc, WorkID)VALUES(@FirstName, @SecondName, @ThirdName, @Qualification, @AssumedSalary, @Misc, @WorkID)";
                    cmd.Parameters.AddWithValue("@FirstName", seeker.FirstName);
                    cmd.Parameters.AddWithValue("@SecondName", seeker.SecondName);
                    cmd.Parameters.AddWithValue("@WorkID", seeker.WorkID);
                    object ThirdName = (String.IsNullOrEmpty(seeker.ThirdName) == false) ? (object)seeker.ThirdName.ToString() : DBNull.Value;
                    cmd.Parameters.AddWithValue("@ThirdName", ThirdName);
                    object Misc = (String.IsNullOrEmpty(seeker.Misc) == false) ? (object)seeker.Misc.ToString() : DBNull.Value;
                    cmd.Parameters.AddWithValue("@Misc", Misc);
                    object AssumedSalary = seeker.AssumedSalary.HasValue ? (object)seeker.AssumedSalary.Value : DBNull.Value;
                    cmd.Parameters.AddWithValue("@AssumedSalary", AssumedSalary);
                    object qualification = (String.IsNullOrEmpty(seeker.Qualification) == false) ? (object)seeker.Qualification.ToString() : DBNull.Value;
                    cmd.Parameters.AddWithValue("@Qualification", qualification);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        /// <summary>
        /// Удалить соискателя
        /// </summary>
        /// <param name="SeekerID">Номер соискателя</param>
        public void Delete(int SeekerID)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM JobSeeker WHERE SeekerID=@SeekerID";
                    cmd.Parameters.AddWithValue("@SeekerID", SeekerID);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        /// <summary>
        /// Получить соискателя
        /// </summary>
        /// <param name="SeekerID">Номер соискателя</param>
        /// <returns></returns>
        public JobSeeker Get(int SeekerID)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT FirstName, SecondName, ThirdName, Qualification, AssumedSalary, Misc, WorkID FROM JobSeeker WHERE SeekerID=@SeekerID";
                    cmd.Parameters.AddWithValue("@SeekerID", SeekerID);
                    using (var datareader = cmd.ExecuteReader())
                    {
                        if (datareader.Read())
                        {
                            return !datareader.Read() ? null : LoadSeeker(datareader);
                        }
                        return null;
                    }
                }
            }
        }
        /// <summary>
        /// Получить всех соискателей
        /// </summary>
        /// <returns></returns>
        public IList<JobSeeker> GetAll()
        {
            IList<JobSeeker> seekers = new List<JobSeeker>();
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT SeekerID, FirstName, SecondName, ThirdName, Qualification, AssumedSalary, Misc, WorkID FROM JobSeeker";
                    using (var datareader = cmd.ExecuteReader())
                    {
                        while (datareader.Read())
                        {
                            seekers.Add(LoadSeeker(datareader));
                        }
                    }
                }
            }
            return seekers;
        }
        /// <summary>
        /// Изменить соискателя
        /// </summary>
        /// <param name="seeker">Соискатель</param>
        public void Update(JobSeeker seeker)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "UPDATE JobSeeker SET FirstName=@FirstName, SecondName=@SecondName, ThirdName=@ThirdName, Qualification=@Qualification, AssumedSalary=@AssumedSalary, Misc=@Misc, WorkID=@WorkID WHERE SeekerID=@SeekerID)";
                    cmd.Parameters.AddWithValue("@FirstName", seeker.FirstName);
                    cmd.Parameters.AddWithValue("@SecondName", seeker.SecondName);
                    cmd.Parameters.AddWithValue("@WorkID", seeker.WorkID);
                    object ThirdName = (String.IsNullOrEmpty(seeker.ThirdName) == false) ? (object)seeker.ThirdName.ToString() : DBNull.Value;
                    cmd.Parameters.AddWithValue("@ThirdName", ThirdName);
                    object Misc = (String.IsNullOrEmpty(seeker.Misc) == false) ? (object)seeker.Misc.ToString() : DBNull.Value;
                    cmd.Parameters.AddWithValue("@ThirdName", Misc);
                    object AssumedSalary = seeker.AssumedSalary.HasValue ? (object)seeker.AssumedSalary.Value : DBNull.Value;
                    cmd.Parameters.AddWithValue("@AssumedSalary", AssumedSalary);
                    object qualification = (String.IsNullOrEmpty(seeker.Qualification) == false) ? (object)seeker.Qualification.ToString() : DBNull.Value;
                    cmd.Parameters.AddWithValue("@Qualification", qualification);
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
        /// Загрузить соискателя
        /// </summary>
        /// <param name="reader">Считыватель</param>
        /// <returns></returns>
        private static JobSeeker LoadSeeker(SqlDataReader reader)
        {
            JobSeeker seeker = new JobSeeker();
            seeker.SeekerID = reader.GetInt32(reader.GetOrdinal("SeekerID"));
            int seekwork = reader.GetOrdinal("WorkID");
            seeker.WorkID = reader[seekwork] == DBNull.Value ? -1 : reader.GetInt32(seekwork);
            seeker.FirstName = reader.GetString(reader.GetOrdinal("FirstName"));
            seeker.SecondName = reader.GetString(reader.GetOrdinal("SecondName"));
            object thirdname = reader["ThirdName"];
            object qualification = reader["Qualification"];
            object assumedsalary = reader["AssumedSalary"];
            object misc = reader["Misc"];
            if (thirdname != DBNull.Value)
                seeker.ThirdName = reader.GetString(reader.GetOrdinal("ThirdName"));
            if (qualification != DBNull.Value)
                seeker.Qualification = reader.GetString(reader.GetOrdinal("Qualification"));
            if (assumedsalary != DBNull.Value)
                seeker.AssumedSalary = Convert.ToDecimal(reader["AssumedSalary"]);
            if (misc != DBNull.Value)
                seeker.Misc = reader.GetString(reader.GetOrdinal("Misc"));
            return seeker;
        }
    }
}
