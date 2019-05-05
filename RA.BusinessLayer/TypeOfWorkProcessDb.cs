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
    public class TypeOfWorkProcessDb : ITypeOfWorkProcess
    {
        private readonly ITypeOfWorkDao workDao;
        public TypeOfWorkProcessDb()
        {
            workDao = DaoFactory.GetTypeOfWorkDao();
        }
        public void Add(TypeOfWorkDto workDto)
        {
            workDao.Add(DtoConverter.Convert(workDto));
        }

        public void Delete(int WorkID)
        {
            workDao.Delete(WorkID);
        }

        public TypeOfWorkDto Get(int WorkID)
        {
            return DtoConverter.Convert(workDao.Get(WorkID));
        }

        public IList<TypeOfWorkDto> GetList()
        {
            return DtoConverter.Convert(workDao.GetAll());
        }

        public IList<TypeOfWorkDto> SearchWork(string TypeOfWork)
        {
            return DtoConverter.Convert(workDao.SearchWork(TypeOfWork));
        }

        public void Update(TypeOfWorkDto workDto)
        {
            workDao.Update(DtoConverter.Convert(workDto));
        }
    }
}
