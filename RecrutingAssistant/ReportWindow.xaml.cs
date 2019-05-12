using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Forms.DataVisualization.Charting;
using RA.Dto;
using RA.BusinessLayer;
using System.Collections.ObjectModel;

namespace RecrutingAssistantApp
{
    /// <summary>
    /// Логика взаимодействия для ReportWindow.xaml
    /// </summary>
    public partial class ReportWindow : Window
    {
        private ObservableCollection<ReportItemDto> collection = new ObservableCollection<ReportItemDto>();
        private readonly List<decimal> axisYDataCommission = new List<decimal>();
        private readonly List<string> axisXData = new List<string>();

        public ReportWindow()
        {
            InitializeComponent();

            chart.ChartAreas.Add(new ChartArea("Default"));
            chart.Series.Add(new Series("Комиссионные"));
            chart.Series["Комиссионные"].ChartArea = "Default";

            chart.Legends.Add(new Legend("Legend"));
            chart.Legends["Legend"].DockedToChartArea = "Default";
            chart.Series["Комиссионные"].Legend = "Legend";
            chart.Series["Комиссионные"].IsVisibleInLegend = false;
        }
        
        private void btnAccept_Click(object sender, RoutedEventArgs e)
        {
            DateCompare();
            FillCollection();
            GraphType();
            DrawGraph();
        }

        private void FillCollection()
        {
            axisYDataCommission.Clear();
            if(radioDay.IsChecked!=null && radioDay.IsChecked.Value)
            {
                TimeSpan timeSpan = (Convert.ToDateTime(datePicker2.Text)).Subtract(Convert.ToDateTime(datePicker1.Text));
                if(timeSpan.Days > 30)
                {
                    MessageBox.Show("Выбранный Вами период времени слишком велик! \n Максимальная длина периода - 30 дней ");
                    datePicker2.Text = Convert.ToDateTime(datePicker1.Text).Date.AddDays(30).ToString();
                }
            }
            if (radioMonth.IsChecked != null && radioMonth.IsChecked.Value)
            {
                TimeSpan ts = (Convert.ToDateTime(datePicker2.Text)).Subtract(Convert.ToDateTime(datePicker1.Text));
                if (ts.Days / 30 > 12)
                {
                    MessageBox.Show("Выбранный Вами период времени слишком велик! \n Максимальная длина периода - 12 месяцев ");
                    datePicker2.Text =
                   Convert.ToDateTime(datePicker1.Text).Date.AddMonths(12).ToString();
                }
                collection.Clear();
                collection = ProcessFactory.GetReportProcess().GetCommission("month", Convert.ToDateTime(datePicker1.Text), Convert.ToDateTime(datePicker2.Text));
            }
            if (radioYear.IsChecked != null && radioYear.IsChecked.Value)
            {
                TimeSpan ts =
                   (Convert.ToDateTime(datePicker2.Text)).Subtract(Convert.ToDateTime(datePicker1.Text));
                if (ts.Days / (30 * 12) > 10)
                {
                    MessageBox.Show("Выбранный Вами период времени слишком велик! \n Максимальная длина периода - 10 лет ");
                    datePicker2.Text = Convert.ToDateTime(datePicker1.Text).Date.AddYears(10).ToString();
                }
                collection.Clear();
                collection = ProcessFactory.GetReportProcess().GetCommission("year", Convert.ToDateTime(datePicker1.Text), Convert.ToDateTime(datePicker2.Text));
            }

            foreach (var item in collection)
            {
                axisYDataCommission.Add(item.commission);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            IList<DealDto> deal = ProcessFactory.GetDealProcess().GetList();
            datePicker1.Text = deal[0].DateOfDeal.ToString();
            datePicker2.Text = deal[deal.Count - 1].DateOfDeal.ToString();
            btnAccept_Click(sender, e);
        }
        private void DateCompare()
        {
            if ((Convert.ToDateTime(datePicker1.Text)) >=
           Convert.ToDateTime(datePicker2.Text))
            {
                MessageBox.Show("Дата окончания интервала запроса \n меньше либо равна дате начала");
            }
        }
        private void GraphType()
        {
            if(radioGist.IsChecked!=null && radioGist.IsChecked.Value)
            {
                chart.Series["Комиссионные"].ChartType = SeriesChartType.Column;
            }
            if(radioSpline.IsChecked!=null && radioSpline.IsChecked.Value)
            {
                chart.Series["Комиссионные"].ChartType = SeriesChartType.Line;
            }
        }
        private void DrawGraph()
        {
            axisXData.Clear();
            chart.Series["Комиссионные"].Points.Clear();
            foreach (var item in collection)
                axisXData.Add(item.date);
            if (axisYDataCommission.Count != 0)
                chart.Series["Комиссионные"].IsVisibleInLegend = true;
            else
                chart.Series["Комиссионные"].IsVisibleInLegend = false;
            if (axisYDataCommission.Count != 0)
                chart.Series["Комиссионные"].Points.DataBindXY(axisXData, axisYDataCommission);
        }
    }
}
