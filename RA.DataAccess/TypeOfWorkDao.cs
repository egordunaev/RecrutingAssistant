﻿using System;
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
            throw new NotImplementedException();
        }

        public void Delete(int WorkID)
        {
            throw new NotImplementedException();
        }

        public TypeOfWork Get(int WorkID)
        {
            throw new NotImplementedException();
        }

        public IList<TypeOfWork> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(TypeOfWork work)
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
