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
    public class JobSeekerDao : IJobSeekerDao
    {
        public void Add(JobSeeker seeker)
        {
            throw new NotImplementedException();
        }

        public void Delete(int SeekerID)
        {
            throw new NotImplementedException();
        }

        public JobSeeker Get(int SeekerID)
        {
            throw new NotImplementedException();
        }

        public IList<JobSeeker> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(JobSeeker seeker)
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
