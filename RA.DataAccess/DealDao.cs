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
    public class DealDao : IDealDao
    {
        public void Add(Deal deal)
        {
            
        }

        public void Delete(int DealID)
        {
            throw new NotImplementedException();
        }

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

        public void Update(Deal deal)
        {
            throw new NotImplementedException();
        }
        private static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["RecrutingDB"].ConnectionString;
        }
        private static SqlConnection GetConnection()
        {
            return new SqlConnection(GetConnectionString());
        }
        private static Deal LoadDeal(SqlDataReader reader)
        {
            Deal deal = new Deal();
            deal.DealID = reader.GetInt32(reader.GetOrdinal("DealID"));
            deal.DateOfDeal = Convert.ToDateTime(reader["DateOfDeal"]);
            object commission = reader["Commission"];
            if (commission != DBNull.Value)
                deal.Commission = Convert.ToDecimal(commission);
            //deal.Commission = Convert.ToDecimal(reader["Commission"]);
            deal.PositionID = Convert.ToInt32(reader["PositionID"]);
            deal.SeekerID = Convert.ToInt32(reader["SeekerID"]);
            return deal;
        }
    }
}
