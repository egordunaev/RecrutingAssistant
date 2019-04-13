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
            throw new NotImplementedException();
        }

        public void Delete(int EmployerID)
        {
            throw new NotImplementedException();
        }

        public Employer Get(int EmployerID)
        {
            throw new NotImplementedException();
        }

        public IList<Employer> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Employer employer)
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
