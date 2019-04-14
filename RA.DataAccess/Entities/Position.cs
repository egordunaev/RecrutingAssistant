using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RA.DataAccess.Entities
{
    public class Position
    {
        public int PositionID;
        public string PositionName;
        public string IsOpen;
        public decimal? Salary;
        public int EmployerID;
    }
}
