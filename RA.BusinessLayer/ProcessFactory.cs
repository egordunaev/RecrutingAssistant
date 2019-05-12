using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RA.BusinessLayer
{
    public class ProcessFactory
    {
        public static IDealProcess GetDealProcess()
        {
            return new DealProcessDb();
        }
        public static IEmployerProcess GetEmployerProcess()
        {
            return new EmployerProcessDb();
        }
        public static IJobSeekerProcess GetSeekerProcess()
        {
            return new JobSeekerProcessDb();
        }
        public static IPositionProcess GetPositionProcess()
        {
            return new PositionProcessDb();
        }
        public static ITypeOfWorkProcess GetWorkProcess()
        {
            return new TypeOfWorkProcessDb();
        }
        public static ISettingsProcess GetSettingsProcess()
        {
            return new SettingsProcess();
        }
        public static IReportGenerator GetReport()
        {
            return new ReportGenerator();
        }
        public static IReportItemProcess GetReportProcess()
        {
            return new ReportItemProcess();
        }
    }
}
