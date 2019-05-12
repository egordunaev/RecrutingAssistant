using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RA.DataAccess.Entities;

namespace RA.DataAccess
{
    /// <summary>
    /// Декларация действий с отчетом
    /// </summary>
    public interface IReportItemDao
    {
        /// <summary>
        /// Комиссионные в день.
        /// </summary>
        /// <param name="start">Начало периода</param>
        /// <param name="end">Конец периода</param>
        /// <returns></returns>
        IList<Report> getCommissionsPerDay(DateTime start, DateTime end);
        /// <summary>
        /// Комиссионные в месяц.
        /// </summary>
        /// <param name="start">Начало периода</param>
        /// <param name="end">Конец периода</param>
        /// <returns></returns>
        IList<Report> getCommissionsPerMonth(DateTime start, DateTime end);
        /// <summary>
        /// Комиссионные в год.
        /// </summary>
        /// <param name="start">Начало периода</param>
        /// <param name="end">Конец периода</param>
        /// <returns></returns>
        IList<Report> getCommissionsPerYear(DateTime start, DateTime end);
    }
}
