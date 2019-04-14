using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RA.BusinessLayer.Converters;
using RA.Dto;
using RA.DataAccess;

namespace RA.BusinessLayer
{
    public class EmployerProcessDb : IEmployerProcess
    {
        private readonly IEmployerDao employerDao;
        public EmployerProcessDb()
        {
            employerDao = DaoFactory.GetEmployerDao();
        }
        public void Add(EmployerDto employer)
        {
            employerDao.Add(DtoConverter.Convert(employer));
        }

        public void Delete(int EmployerID)
        {
            employerDao.Delete(EmployerID);
        }

        public EmployerDto Get(int EmployerID)
        {
            return DtoConverter.Convert(employerDao.Get(EmployerID));
        }

        public IList<EmployerDto> GetList()
        {
            return DtoConverter.Convert(employerDao.GetAll());
        }

        public void Update(EmployerDto employer)
        {
            employerDao.Update(DtoConverter.Convert(employer));
        }
    }
}
