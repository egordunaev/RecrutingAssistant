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
    public class JobSeekerDao : BaseDao, IJobSeekerDao
    {

        private static IDictionary<int, JobSeeker> Seekers;
        private IList<JobSeeker> LoadInternal()
        {
            try
            {
                IList<JobSeeker> jobSeekers = new List<JobSeeker>();
                using (var conn = GetConnection())
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SELECT SeekerID, FirstName, SecondName, ThirdName, Qualification, AssumedSalary, Misc, WorkID FROM JobSeeker";
                        cmd.CommandType = System.Data.CommandType.Text;
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                jobSeekers.Add(LoadSeeker(reader));
                            }
                        }
                    }
                }
                return jobSeekers;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString(), "ERROR");
                throw;
            }
        }
        /// <summary>
        /// Добавить соискателя
        /// </summary>
        /// <param name="seeker">Соискатель</param>
        public void Add(JobSeeker seeker)
        {
            try
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
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString(), "ERROR");
            }
        }
        /// <summary>
        /// Удалить соискателя
        /// </summary>
        /// <param name="SeekerID">Номер соискателя</param>
        public void Delete(int SeekerID)
        {
            try
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
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString(), "ERROR");
                throw;
            }
        }
        /// <summary>
        /// Получить соискателя
        /// </summary>
        /// <param name="SeekerID">Номер соискателя</param>
        /// <returns></returns>
        public JobSeeker Get(int SeekerID)
        {
            try
            {
                if (Seekers == null)
                    Load();
                return Seekers.ContainsKey(SeekerID) ? Seekers[SeekerID] : null;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString(), "ERROR");
                throw;
            }
        }
        /// <summary>
        /// Получить всех соискателей
        /// </summary>
        /// <returns></returns>
        public IList<JobSeeker> GetAll()
        {
            try
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
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString(), "ERROR");
                throw;
            }
        }
        /// <summary>
        /// Изменить соискателя
        /// </summary>
        /// <param name="seeker">Соискатель</param>
        public void Update(JobSeeker seeker)
        {
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "UPDATE JobSeeker SET FirstName=@FirstName, SecondName=@SecondName, ThirdName=@ThirdName, Qualification=@Qualification, AssumedSalary=@AssumedSalary, Misc=@Misc, WorkID=@WorkID WHERE SeekerID=@SeekerID)";
                        cmd.Parameters.AddWithValue("@SeekerID", seeker.SeekerID);
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
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString(), "ERROR");
                throw;
            }
        }
        /// <summary>
        /// Получить строку для подключения к базе
        /// </summary>
        /// <returns></returns>
        private static string GetConnectionString()
        {
            try
            {
                return ConfigurationManager.ConnectionStrings["RecrutingDB"].ConnectionString;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString(), "ERROR");
                throw;
            }
        }
        /// <summary>
        /// Подключиться к базе
        /// </summary>
        /// <returns></returns>
        private static SqlConnection GetConnection()
        {
            try
            {
                return new SqlConnection(GetConnectionString());
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString(), "ERROR");
                throw;
            }
        }
        /// <summary>
        /// Загрузить соискателя
        /// </summary>
        /// <param name="reader">Считыватель</param>
        /// <returns></returns>
        private static JobSeeker LoadSeeker(SqlDataReader reader)
        {
            try
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
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString(), "ERROR");
                throw;
            }
        }

        public IList<JobSeeker> Load()
        {
            try
            {
                Seekers = new Dictionary<int, JobSeeker>();
                var seekers = LoadInternal();
                foreach (var seeker in seekers)
                {
                    Seekers.Add(seeker.SeekerID, seeker);
                }
                return Seekers.Values.ToList();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString(), "ERROR");
                throw;
            }
        }
        public void Reset()
        {
            try
            {
                if (Seekers == null)
                    return;
                Seekers.Clear();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString(), "ERROR");
                throw;
            }
        }
        public IList<JobSeeker> SearchSeekers(string FirstName, string SecondName, string TypeOfWork)
        {
            try
            {
                IList<JobSeeker> seekers = new List<JobSeeker>();
                using (var conn = GetConnection())
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SELECT SeekerID, FirstName, SecondName, ThirdName, Qualification, AssumedSalary, Misc, JobSeeker.WorkID FROM JobSeeker JOIN TypeOfWork on JobSeeker.WorkID = TypeOfWork.WorkID WHERE FirstName like @FirstName AND SecondName like @SecondName AND TypeOfWork.Name like @Name";
                        cmd.Parameters.AddWithValue("@FirstName", "%" + FirstName + "%");
                        cmd.Parameters.AddWithValue("@SecondName", "%" + SecondName + "%");
                        cmd.Parameters.AddWithValue("@Name", "%" + TypeOfWork);
                        using (var dataReader = cmd.ExecuteReader())
                        {
                            while (dataReader.Read())
                            {
                                seekers.Add(LoadSeeker(dataReader));
                            }
                        }
                    }
                }

                return seekers;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString(), "ERROR");
                throw;
            }
        }
    }
}
