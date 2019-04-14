using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RA.Dto;

namespace RA.BusinessLayer
{
    public class DealProcess : IDealProcess
    {
        private static readonly IDictionary<int, DealDto> Deals = new Dictionary<int, DealDto>();
        public void Add(DealDto deal)
        {
            int max = Deals.Keys.Count == 0 ? 1 : Deals.Keys.Max(p => p) + 1;
            deal.DealID = max;
            Deals.Add(max, deal);
        }

        public void Delete(int DealID)
        {
            if (Deals.ContainsKey(DealID))
                Deals.Remove(DealID);
        }

        public DealDto Get(int DealID)
        {
            return Deals.ContainsKey(DealID) ? Deals[DealID] : null;
        }

        public IList<DealDto> GetList()
        {
            return new List<DealDto>(Deals.Values);
        }

        public void Update(DealDto deal)
        {
            if (Deals.ContainsKey(deal.DealID))
                Deals[deal.DealID] = deal;
        }
    }
}
