using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using RA.DataAccess;
using RA.Dto;
using OfficeOpenXml;
using System.Threading;
using System.Globalization;
using OfficeOpenXml.Style;

namespace RA.BusinessLayer
{
    public class ReportGenerator : IReportGenerator
    {
        public void fillExcelByType(IEnumerable<object> grid, string status, FileInfo xlsxFile)
        {
            try
            {
                if (grid != null)
                {
                    ExcelPackage pck = new ExcelPackage(xlsxFile);
                    var excel = pck.Workbook.Worksheets.Add(status);
                    int x = 1;
                    int y = 1;
                    CultureInfo cultureInfo = new CultureInfo(Thread.CurrentThread.CurrentCulture.Name);
                    Thread.CurrentThread.CurrentCulture = cultureInfo;
                    cultureInfo.NumberFormat.NumberDecimalSeparator = ".";
                    // Первая строка (шапка таблицы) – жирным стилем.
                    excel.Cells["A1:Z1"].Style.Font.Bold = true;
                    // Выравнивание текста в ячейках – по левому краю.
                    excel.Cells.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                    // Устанавливает формат ячеек.
                    excel.Cells.Style.Numberformat.Format = "General";

                    Object dtObj = new Object();
                    switch (status)
                    {
                        case "JobSeeker":
                            dtObj = new JobSeekerDto();
                            break;
                        case "TypeOfWork":
                            dtObj = new TypeOfWorkDto();
                            break;
                        case "Employer":
                            dtObj = new EmployerDto();
                            break;
                        case "Position":
                            dtObj = new PositionDto();
                            break;
                        case "Deal":
                            dtObj = new DealDto();
                            break;
                    }
                    // Генерация шапки таблицы
                    foreach (var prop in dtObj.GetType().GetProperties())
                    {
                        excel.Cells[y, x].Value = prop.Name.Trim();
                        x++;
                    }
                    // Генерация строк-записей таблицы.
                    foreach (var item in grid)
                    {
                        y++;
                        Object itemObj = item;
                        x = 1;
                        foreach (var prop in itemObj.GetType().GetProperties())
                        {
                            object t = prop.GetValue(itemObj, null);
                            object val;
                            if (t == null)
                                val = "";
                            else
                            {
                                val = t.ToString();
                                if (t is TypeOfWorkDto)
                                    val = ((TypeOfWorkDto)t).Name;
                                if (t is JobSeekerDto)
                                    val = ((JobSeekerDto)t).FullName;
                                if (t is EmployerDto)
                                    val = ((EmployerDto)t).Name;
                                if (t is PositionDto)
                                    val = ((PositionDto)t).PositionName;
                            }
                            excel.Cells[y, x].Value = val;
                            x++;
                        }
                    }
                    excel.Cells.AutoFitColumns();
                    pck.Save();
                }
                else MessageBox.Show("Данные не загружены!");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString(), "ERROR");
                throw new Exception();
            }
        }
    }
}
