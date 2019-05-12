using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RA.Dto;
using RA.BusinessLayer.Converters;
using RA.DataAccess;

namespace RA.BusinessLayer
{
    public class ReportItemProcess : IReportItemProcess
    {
        private static readonly IReportItemDao reportDao = new ReportItemDao();
        /// <summary>
        /// Получить комиссионные
        /// </summary>
        /// <param name="period">Период</param>
        /// <param name="start">Начало</param>
        /// <param name="stop">Конец</param>
        /// <returns></returns>
        public ObservableCollection<ReportItemDto> GetCommission(string period, DateTime start, DateTime stop)
        {
            IList<ReportItemDto> ReportList;
            switch(period)
            {
                case "day":
                    {
                        ReportList = DtoConverter.Convert(reportDao.getCommissionsPerDay(start, stop));
                        break;
                    }
                case "month":
                    {
                        ReportList = DtoConverter.Convert(reportDao.getCommissionsPerMonth(start, stop));
                        break;
                    }
                case "year":
                    {
                        ReportList = DtoConverter.Convert(reportDao.getCommissionsPerYear(start, stop));
                        break;
                    }
                default:
                    {
                        ReportList = null;
                        break;
                    }
            }
            return GetCollection(ReportList, period, start, stop);
        }
        private static ObservableCollection<ReportItemDto> GetCollection(IList<ReportItemDto> Items, string period, DateTime start, DateTime stop)
        {
            ObservableCollection<ReportItemDto> Collection = new ObservableCollection<ReportItemDto>();
            if (Items == null) { return null; }

            switch (period)
            {
                case "day":
                    {
                        DateTime d = start;
                        while (d <= stop)
                        {
                            ReportItemDto repItem = new ReportItemDto
                            {
                                date = d.Date.ToString("dd.MM.yyyy"),
                                count = 0,
                                commission = 0
                            };
                            foreach (var item in Items)
                            {
                                if (Convert.ToDateTime(item.date).Date == d)
                                {
                                    repItem.count += item.count;
                                    repItem.commission += item.commission;
                                }
                            }
                            Collection.Add(repItem);
                            d = d.AddDays(1);
                        }
                        break;
                    }
                case "month":
                    {

                        DateTime d = start;
                        while (d <= stop)
                        {
                            ReportItemDto repItem = new ReportItemDto
                            {
                                date = d.Date.ToString("Y"),
                                count = 0,
                                commission = 0
                            };
                            foreach (var item in Items)
                            {
                                if ((Convert.ToDateTime(item.date).Month == d.Month) && (Convert.ToDateTime(item.date).Year == d.Year))
                                {
                                    repItem.count += item.count;
                                    repItem.commission += item.commission;
                                }
                            }
                            Collection.Add(repItem);
                            d = d.AddMonths(1);
                        }
                        break;
                    }
                case "year":
                    {
                        DateTime d = start;
                        while (d <= stop)
                        {
                            ReportItemDto repItem = new ReportItemDto
                            {
                                date = d.Date.Year.ToString(),
                                count = 0,
                                commission = 0
                            };
                            foreach (var item in Items)
                            {
                                if (Convert.ToDateTime(item.date).Year == d.Year)

                                {
                                    repItem.count += item.count;
                                    repItem.commission += item.commission;
                                }
                            }
                            Collection.Add(repItem);
                            d = d.AddYears(1);
                        }
                        break;
                    }
            }
            return Collection;

        }

    }

}
