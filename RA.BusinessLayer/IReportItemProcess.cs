using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RA.Dto;
using System.Collections.ObjectModel;

namespace RA.BusinessLayer
{
    public interface IReportItemProcess
    {
        /// <summary>
        /// Получить комиссионные
        /// </summary>
        /// <param name="period">Период</param>
        /// <param name="start">Начало</param>
        /// <param name="stop">Конец</param>
        /// <returns></returns>
        ObservableCollection<ReportItemDto> GetCommission(string period, DateTime start, DateTime stop);
    }
}
