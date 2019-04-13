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
    public class PositionDao : IPositionDao
    {
        public void Add(Position position)
        {
            throw new NotImplementedException();
        }

        public void Delete(int PositionID)
        {
            throw new NotImplementedException();
        }

        public Position Get(int PositionID)
        {
            throw new NotImplementedException();
        }

        public IList<Position> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Position position)
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
    }
}
