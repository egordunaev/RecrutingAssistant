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
    public class PositionProcessDb : IPositionProcess
    {
        private readonly IPositionDao positionDao;
        public PositionProcessDb()
        {
            positionDao = DaoFactory.GetPositionDao();
        }
        public void Add(PositionDto position)
        {
            positionDao.Add(DtoConverter.Convert(position));
        }

        public void Delete(int PositionID)
        {
            positionDao.Delete(PositionID);
        }

        public PositionDto Get(int PositionID)
        {
            return DtoConverter.Convert(positionDao.Get(PositionID));
        }

        public IList<PositionDto> GetList()
        {
            return DtoConverter.Convert(positionDao.GetAll());
        }

        public IList<PositionDto> SearchPosition(string PositionName, string Employer)
        {
            return DtoConverter.Convert(positionDao.SearchPosition(PositionName, Employer));
        }

        public void Update(PositionDto position)
        {
            positionDao.Update(DtoConverter.Convert(position));
        }
    }
}
