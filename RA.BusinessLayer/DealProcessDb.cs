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
    public class DealProcessDb : IDealProcess
    {
        private readonly IDealDao dealDao;
        public DealProcessDb()
        {
            dealDao = DaoFactory.GetDealDao();
        }
        public void Add(DealDto deal)
        {
            dealDao.Add(DtoConverter.Convert(deal));
        }

        public void Delete(int DealID)
        {
            dealDao.Delete(DealID);
        }

        public DealDto Get(int DealID)
        {
            return DtoConverter.Convert(dealDao.Get(DealID));
        }

        public IList<DealDto> GetList()
        {
            return DtoConverter.Convert(dealDao.GetAll());
        }

        public void Update(DealDto deal)
        {
            dealDao.Update(DtoConverter.Convert(deal));
        }
    }
}
