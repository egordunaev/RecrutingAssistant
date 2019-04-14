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
    public class TypeOfWorkDao : ITypeOfWorkDao
    {
        public void Add(TypeOfWork work)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO TypeOfWork(Name)VALUES(@Name)";
                    cmd.Parameters.AddWithValue("@Name", work.Name);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int WorkID)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM TypeOfWork WHERE WorkID=@WorkID";
                    cmd.Parameters.AddWithValue("@WorkID", WorkID);
                }
            }
        }

        public TypeOfWork Get(int WorkID)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT WorkID, Name FROM TypeOfWork WHERE WorkID=@WorkID";
                    cmd.Parameters.AddWithValue("@WorkID", WorkID);
                    using (var datareader = cmd.ExecuteReader())
                    {
                        if (datareader.Read())
                        {
                            return !datareader.Read() ? null : LoadTypeOfWork(datareader);
                        }
                        return null;
                    }
                }
            }
        }

        public IList<TypeOfWork> GetAll()
        {
            IList<TypeOfWork> works = new List<TypeOfWork>();
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT WorkID, Name FROM TypeOfWork";
                    using (var datareader = cmd.ExecuteReader())
                    {
                        while (datareader.Read())
                        {
                            works.Add(LoadTypeOfWork(datareader));
                        }
                    }
                }
            }
            return works;
        }

        public void Update(TypeOfWork work)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "UPDATE TypeOfWork SET Name=@Name WHERE WorkID=@WorkID)";
                    cmd.Parameters.AddWithValue("@Name", work.Name);
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
        private static TypeOfWork LoadTypeOfWork(SqlDataReader reader)
        {
            TypeOfWork work = new TypeOfWork();
            work.WorkID = reader.GetInt16(reader.GetOrdinal("WorkID"));
            work.Name = reader.GetString(reader.GetOrdinal("Name"));
            return work;
        }
    }
}
