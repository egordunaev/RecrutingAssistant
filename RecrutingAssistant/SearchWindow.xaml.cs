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
    /// Логика взаимодействия для SearchWindow.xaml
    /// </summary>
    public partial class SearchWindow : Window
    {
        private readonly IList<JobSeekerDto> AllowSeekers = ProcessFactory.GetSeekerProcess().GetList();
        private readonly IList<TypeOfWorkDto> AllowWorks = ProcessFactory.GetWorkProcess().GetList();
        private readonly IList<EmployerDto> AllowEmployers = ProcessFactory.GetEmployerProcess().GetList();
        private readonly IList<PositionDto> AllowPositions = ProcessFactory.GetPositionProcess().GetList();
        private readonly IList<DealDto> AllowDeals = ProcessFactory.GetDealProcess().GetList();

        public IList<JobSeekerDto> FoundSeekers;
        public IList<TypeOfWorkDto> FoundWorks;
        public IList<EmployerDto> FoundEmployers;
        public IList<PositionDto> FoundPositions;
        public IList<DealDto> FoundDeals;

        public bool exec;
        public SearchWindow(string status)
        {
            InitializeComponent();
            this.cbSeekerTypeOfWork.ItemsSource = AllowWorks;
            this.cbEmployerTypeOfWork.ItemsSource = AllowWorks;
            this.cbEmployer.ItemsSource = AllowEmployers;
            this.cbJobSeeker.ItemsSource = AllowSeekers;
            this.cbPosition.ItemsSource = AllowPositions;
            switch(status)
            {
                case "JobSeeker":
                    this.sDeals.Visibility = Visibility.Collapsed;
                    this.sEmployers.Visibility = Visibility.Collapsed;;
                    this.sTypeOfWork.Visibility = Visibility.Collapsed;
                    this.sPositions.Visibility = Visibility.Collapsed;
                    break;
                case "TypeOfWork":
                    this.sDeals.Visibility = Visibility.Collapsed;
                    this.sEmployers.Visibility = Visibility.Collapsed; ;
                    this.sJobSeeker.Visibility = Visibility.Collapsed;
                    this.sPositions.Visibility = Visibility.Collapsed;
                    break;
                case "Employer":
                    this.sDeals.Visibility = Visibility.Collapsed;
                    this.sJobSeeker.Visibility = Visibility.Collapsed; ;
                    this.sTypeOfWork.Visibility = Visibility.Collapsed;
                    this.sPositions.Visibility = Visibility.Collapsed;
                    break;
                case "Position":
                    this.sDeals.Visibility = Visibility.Collapsed;
                    this.sEmployers.Visibility = Visibility.Collapsed; ;
                    this.sTypeOfWork.Visibility = Visibility.Collapsed;
                    this.sJobSeeker.Visibility = Visibility.Collapsed;
                    break;
                case "Deal":
                    this.sJobSeeker.Visibility = Visibility.Collapsed;
                    this.sEmployers.Visibility = Visibility.Collapsed; ;
                    this.sTypeOfWork.Visibility = Visibility.Collapsed;
                    this.sPositions.Visibility = Visibility.Collapsed;
                    break;
            }
        }

        private void btnSearchSeeker_Click(object sender, RoutedEventArgs e)
        {
            this.FoundSeekers = ProcessFactory.GetSeekerProcess().SearchSeekers(this.SeekerFirstName.Text, this.SeekerSecondName.Text, this.cbSeekerTypeOfWork.Text);
            this.exec = true;
            this.Close();
        }

        private void BtnCancelSeeker_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnSearchTypeOfWork_Click(object sender, RoutedEventArgs e)
        {
            this.FoundWorks = ProcessFactory.GetWorkProcess().SearchWork(this.TypeOfWorkName.Text);
            this.exec = true;
            this.Close();
        }

        private void BtnCancelTypeOfWork_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnSearchEmployer_Click(object sender, RoutedEventArgs e)
        {
            this.FoundEmployers = ProcessFactory.GetEmployerProcess().SearchEmployer(this.EmployerName.Text, this.cbEmployerTypeOfWork.Text);
            this.exec = true;
            this.Close();
        }

        private void BtnCancelEmployer_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnSearchPosition_Click(object sender, RoutedEventArgs e)
        {
            this.FoundPositions = ProcessFactory.GetPositionProcess().SearchPosition(this.PositionName.Text, this.cbEmployer.Text);
            this.exec = true;
            this.Close();
        }

        private void BtnCancelPosition_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnSearchDeal_Click(object sender, RoutedEventArgs e)
        {
            this.FoundDeals = ProcessFactory.GetDealProcess().SearchDeal(this.cbJobSeeker.Text, this.cbPosition.Text, this.Commission.Text);
            this.exec = true;
            this.Close();
        }

        private void BtnCancelDeal_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
