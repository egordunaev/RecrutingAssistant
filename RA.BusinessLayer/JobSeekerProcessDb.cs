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
    public class JobSeekerProcessDb : IJobSeekerProcess
    {
        private readonly IJobSeekerDao seekerDao;
        public JobSeekerProcessDb()
        {
            seekerDao = DaoFactory.GetJobSeekerDao();
        }
        public void Add(JobSeekerDto seekerDto)
        {
            seekerDao.Add(DtoConverter.Convert(seekerDto));
        }

        public void Delete(int SeekerID)
        {
            seekerDao.Delete(SeekerID);
        }

        public JobSeekerDto Get(int SeekerID)
        {
            return DtoConverter.Convert(seekerDao.Get(SeekerID));
        }

        public IList<JobSeekerDto> GetList()
        {
            return DtoConverter.Convert(seekerDao.GetAll());
        }

        public void Update(JobSeekerDto seekerDto)
        {
            seekerDao.Update(DtoConverter.Convert(seekerDto));
        }
        public IList<JobSeekerDto> SearchSeekers(string FirstName, string SecondName, string TypeOfWork)
        {
            return DtoConverter.Convert(seekerDao.SearchSeekers(FirstName, SecondName, TypeOfWork));
        }
    }
}
