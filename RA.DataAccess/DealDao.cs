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

    public class DealDao : BaseDao, IDealDao
    {
        /// <summary>
        /// Добавить новую сделку
        /// </summary>
        /// <param name="deal">Сделка</param>
        public void Add(Deal deal)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO Deal(DateOfDeal, Commission, PositionID, SeekerID)VALUES(@DateOfDeal, @Commission, @PositionID, @SeekerID)";
                    cmd.Parameters.AddWithValue("@SeekerID", deal.SeekerID);
                    cmd.Parameters.AddWithValue("@PositionID", deal.PositionID);
                    object dateofdeal = deal.DateOfDeal.HasValue ? (object)deal.DateOfDeal.Value : DBNull.Value;
                    object commission = deal.Commission.HasValue ? (object)deal.Commission.Value : DBNull.Value;
                    cmd.Parameters.AddWithValue("@Commission", commission);
                    cmd.Parameters.AddWithValue("@DateOfDeal", dateofdeal);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        /// <summary>
        /// Удалить сделку
        /// </summary>
        /// <param name="DealID">Номер сделки</param>
        public void Delete(int DealID)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM Deal WHERE DealID=@DealID";
                    cmd.Parameters.AddWithValue("@DealID", DealID);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Получить определенную сделку
        /// </summary>
        /// <param name="DealID">Номер сделки</param>
        /// <returns></returns>
        public Deal Get(int DealID)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT DealID, DateOfDeal, Commission, PositionID, SeekerID FROM Deal WHERE DealID=@DealID";
                    cmd.Parameters.AddWithValue("@DealID", DealID);
                    using (var datareader = cmd.ExecuteReader())
                    {
                        if(datareader.Read())
                        {
                            return !datareader.Read() ? null : LoadDeal(datareader);
                        }
                        return null;
                    }
                }
            }
        }
        /// <summary>
        /// Получить все сделки
        /// </summary>
        /// <returns></returns>
        public IList<Deal> GetAll()
        {
            IList<Deal> deals = new List<Deal>();
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT DealID, DateOfDeal, Commission, PositionID, SeekerID FROM Deal";
                    using (var datareader = cmd.ExecuteReader())
                    {
                        while(datareader.Read())
                        {
                            deals.Add(LoadDeal(datareader));
                        }
                    }
                }
            }
            return deals;
        }
        /// <summary>
        /// Изменить сделку
        /// </summary>
        /// <param name="deal">Сделка</param>
        public void Update(Deal deal)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "UPDATE Deal SET DateOfDeal=@DateOfDeal, Commission=@Commission, PositionID=@PositionID, SeekerID=@SeekerID WHERE DealID=@DealID";
                    cmd.Parameters.AddWithValue("@DealID", deal.DealID);
                    cmd.Parameters.AddWithValue("@SeekerID", deal.SeekerID);
                    cmd.Parameters.AddWithValue("@PositionID", deal.PositionID);
                    object dateofdeal = deal.DateOfDeal.HasValue ? (object)deal.DateOfDeal.Value : DBNull.Value;
                    object commission = deal.Commission.HasValue ? (object)deal.Commission.Value : DBNull.Value;
                    cmd.Parameters.AddWithValue("@Commission", commission);
                    cmd.Parameters.AddWithValue("@DateOfDeal", dateofdeal);
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
        /// Загрузить сделку
        /// </summary>
        /// <param name="reader">Считыватель</param>
        /// <returns></returns>
        private static Deal LoadDeal(SqlDataReader reader)
        {
            Deal deal = new Deal();
            deal.DealID = reader.GetInt32(reader.GetOrdinal("DealID"));
            deal.DateOfDeal = Convert.ToDateTime(reader["DateOfDeal"]);
            object commission = reader["Commission"];
            if (commission != DBNull.Value)
                deal.Commission = Convert.ToDecimal(commission);
            //deal.Commission = Convert.ToDecimal(reader["Commission"]);
            int dealpos = reader.GetOrdinal("PositionID");
            int dealseek = reader.GetOrdinal("SeekerID");
            deal.PositionID = reader[dealpos] == DBNull.Value ? -1 : reader.GetInt32(dealpos);
            deal.SeekerID = reader[dealseek] == DBNull.Value ? -1 : reader.GetInt32(dealseek);
            return deal;
        }
    }
}
