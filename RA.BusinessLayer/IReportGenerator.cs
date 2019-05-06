using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace RA.BusinessLayer
{
    public interface IReportGenerator
    {
        void fillExcelByType(IEnumerable<object> grid, string status, FileInfo xlsxFile);
    }
}
