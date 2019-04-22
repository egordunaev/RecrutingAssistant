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
using RA.Dto;
using RA.BusinessLayer;

namespace RecrutingAssistantApp
{
    /// <summary>
    /// Логика взаимодействия для AddDealWindow.xaml
    /// </summary>
    public partial class AddDealWindow : Window
    {
        private static IList<JobSeekerDto> Seekers = ProcessFactory.GetSeekerProcess().GetList();
        private static IList<PositionDto> Positions = ProcessFactory.GetPositionProcess().GetList();
        private int _dealID;
        public void Load(DealDto dealDto)
        {
            if (dealDto == null)
                return;
            _dealID = dealDto.DealID;
            if (dealDto.DateOfDeal.HasValue)
                dpDateOfDeal.DisplayDate = dealDto.DateOfDeal.Value;
            if (dealDto.Commission.HasValue)
                tbCommissions.Text = dealDto.Commission.ToString();
            if(dealDto.Position!=null)
            {
                foreach(PositionDto positionDto in Positions)
                {
                    if(dealDto.Position.PositionID==positionDto.PositionID)
                    {
                        this.cbPosition.SelectedItem = positionDto;
                        break;
                    }
                }
            }
            if(dealDto.Seeker!=null)
            {
                foreach(JobSeekerDto jobSeekerDto in Seekers)
                {
                    if(dealDto.Seeker.SeekerID==jobSeekerDto.SeekerID)
                    {
                        this.cbSeeker.SelectedItem = jobSeekerDto;
                        break;
                    }
                }
            }
        }
        public AddDealWindow()
        {
            InitializeComponent();
            cbPosition.ItemsSource = (from P in Positions orderby P.PositionName select P);
            cbPosition.SelectedIndex = 0;
            cbSeeker.ItemsSource = (from S in Seekers orderby (S.FirstName + S.SecondName) select S);
            cbSeeker.SelectedIndex = 0;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if(cbSeeker.SelectedItem==null)
            {
                MessageBox.Show("Выберите соискателя", "Проверка");
                return;
            }
            if(cbPosition.SelectedItem==null)
            {
                MessageBox.Show("Выберите вакансию", "Проверка");
                return;
            }
            if (dpDateOfDeal.DisplayDate == null)
            {
                MessageBoxResult result = MessageBox.Show("При указании пустой даты будет указана сегодняшняя дата: "+DateTime.Today.ToShortDateString()+"\nВы уверены?", "Проверка", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result != MessageBoxResult.Yes)
                    return;
            }
            decimal commission;
            decimal.TryParse(tbCommissions.Text, out commission);
            DealDto deal = new DealDto();
            deal.DateOfDeal = dpDateOfDeal.DisplayDate;
            deal.Commission = commission;
            deal.Position = cbPosition.SelectedItem as PositionDto;
            deal.Seeker = cbSeeker.SelectedItem as JobSeekerDto;
            IDealProcess dealProcess = ProcessFactory.GetDealProcess();
            if(_dealID==0)
            {
                dealProcess.Add(deal);
            }
            else
            {
                deal.DealID = _dealID;
                dealProcess.Update(deal);
            }
            Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
