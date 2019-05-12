using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RA.DataAccess.Entities;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace RA.DataAccess
{
    /// <summary>
    /// Отчет
    /// </summary>
    public class ReportItemDao : BaseDao, IReportItemDao
    {
        /// <summary>
        /// Загрузка отчета
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        private static Report LoadReport(SqlDataReader reader)
        {
            Report report = new Report();
            try
            {
                report.date = reader.GetDateTime(reader.GetOrdinal("mydate"));
            }
            catch (Exception ex)
            {
                report.date = DateTime.Now.Date;
            }
            report.commission = reader.GetDecimal(reader.GetOrdinal("mysum"));
            report.count = reader.GetInt32(reader.GetOrdinal("mycount"));
            return report;
        }
        /// <summary>
        /// Комиссионные в день.
        /// </summary>
        /// <param name="start">Начало периода</param>
        /// <param name="end">Конец периода</param>
        /// <returns></returns>
        public IList<Report> getCommissionsPerDay(DateTime start, DateTime end)
        {
            IList<Report> reports = new List<Report>();
            //Получаем объект подключения к базе
            using (var conn = GetConnection())
            {
                //Открываем соединение
                conn.Open();
                //Создаем sql команду
                using (var cmd = conn.CreateCommand())
                {
                    //Задаём текст команды
                    cmd.CommandText = "select CONVERT(date, DateOfDeal, 105) as mydate, isnull(SUM(Commission), 0.0) as mysum, ISNULL(count(Commission), 0.0) as mycount from Deal where DateOfDeal between @start and @stop group by CONVERT(date, DateOfDeal, 105)";
                    //Добавляем значение параметра
                    cmd.Parameters.AddWithValue("@start", start);
                    cmd.Parameters.AddWithValue("@stop", end);
                    //Открываем SqlDataReader для чтения полученных в результате
                    // выполнения запроса данных
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            reports.Add(LoadReport(dataReader));
                        }
                    }
                }
            }
            return reports;
        }
        /// <summary>
        /// Комиссионные в месяц.
        /// </summary>
        /// <param name="start">Начало периода</param>
        /// <param name="end">Конец периода</param>
        /// <returns></returns>
        public IList<Report> getCommissionsPerMonth(DateTime start, DateTime end)
        {
            IList<Report> reports = new List<Report>();
            //Получаем объект подключения к базе
            using (var conn = GetConnection())
            {
                //Открываем соединение
                conn.Open();
                //Создаем sql команду
                using (var cmd = conn.CreateCommand())
                {
                    //Задаём текст команды
                    cmd.CommandText = "select CONVERT(date, DateOfDeal, 105) as mydate, isnull(SUM(Commission), 0.0) as mysum, ISNULL(count(Commission), 0.0) as mycount from Deal where DateOfDeal between @start and @stop group by CONVERT(date, DateOfDeal, 105)";
                    //Добавляем значение параметра
                    cmd.Parameters.AddWithValue("@start", start);
                    cmd.Parameters.AddWithValue("@stop", end);
                    //Открываем SqlDataReader для чтения полученных в результате
                    // выполнения запроса данных
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            reports.Add(LoadReport(dataReader));
                        }
                    }
                }
            }
            return reports;
        }
        /// <summary>
        /// Комиссионные в год.
        /// </summary>
        /// <param name="start">Начало периода</param>
        /// <param name="end">Конец периода</param>
        /// <returns></returns>
        public IList<Report> getCommissionsPerYear(DateTime start, DateTime end)
        {
            IList<Report> reports = new List<Report>();
            //Получаем объект подключения к базе
            using (var conn = GetConnection())
            {
                //Открываем соединение
                conn.Open();
                //Создаем sql команду
                using (var cmd = conn.CreateCommand())
                {
                    //Задаём текст команды
                    cmd.CommandText = "select CONVERT(date, DateOfDeal, 105) as mydate, isnull(SUM(Commission), 0.0) as mysum, ISNULL(count(Commission), 0.0) as mycount from Deal where DateOfDeal between DATEPART(YEAR,@start) and DATEPART(YEAR,@stop) group by CONVERT(date, DateOfDeal, 105)";
                    //Добавляем значение параметра
                    cmd.Parameters.AddWithValue("@start", start);
                    cmd.Parameters.AddWithValue("@stop", end);
                    //Открываем SqlDataReader для чтения полученных в результате
                    // выполнения запроса данных
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            reports.Add(LoadReport(dataReader));
                        }
                    }
                }
            }
            return reports;
        }
    }
}
