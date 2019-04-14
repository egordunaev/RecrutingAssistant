using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RA.DataAccess.Entities
{
    public class Deal
    {
        public int DealID;
        public DateTime? DateOfDeal;
        public decimal? Commission;
        public int PositionID;
        public int SeekerID;
    }
}
