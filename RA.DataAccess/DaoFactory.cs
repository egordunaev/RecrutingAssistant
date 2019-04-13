using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RA.DataAccess
{
    public class DaoFactory
    {
        public static IDealDao GetDealDao()
        {
            return new DealDao();
        }
        public static IEmployerDao GetEmployerDao()
        {
            return new EmployerDao();
        }
        public static IJobSeekerDao GetJobSeekerDao()
        {
            return new JobSeekerDao();
        }
        public static IPositionDao GetPositionDao()
        {
            return new PositionDao();
        }
        public static ITypeOfWorkDao GetTypeOfWorkDao()
        {
            return new TypeOfWorkDao();
        }
        public static SettingsDao GetSettingsDao()
        {
            return new SettingsDao();
        }
    }
}
