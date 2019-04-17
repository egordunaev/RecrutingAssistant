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
using System.Windows.Navigation;
using System.Windows.Shapes;
using RA.BusinessLayer;
using RA.Dto;
using RecrutingAssistantApp;

namespace RecrutingAssistant
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string status; // Статус таблицы с которой работаем
        public MainWindow()
        {
            InitializeComponent();
        }
        // 
        // ADD FUNCTIONS
        //
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            switch (status)
            {
                case "TypeOfWork":
                    this.btnAddWork_Click(sender, e);
                    break;
                case "JobSeeker":
                    this.btnAddSeeker_Click(sender, e);
                    break;
                case "Employer":
                    this.btnAddEmployer_Click(sender, e);
                    break;
                case "Position":
                    this.btnAddPosition_Click(sender, e);
                    break;
                case "Deal":
                    this.btnAddDeal_Click(sender, e);
                    break;
                default:
                    MessageBox.Show("Необходимо выбрать таблицу, в которую добавляется элемент!");
                    return;
            }
        }
        private void btnAddWork_Click(object sender, RoutedEventArgs e)
        {
            AddTypeOfWorkWindow window = new AddTypeOfWorkWindow();
            window.ShowDialog();

        }
        private void btnAddSeeker_Click(object sender, RoutedEventArgs e)
        {
            AddJobSeekerWindow window = new AddJobSeekerWindow();
            window.ShowDialog();
        }
        private void btnAddEmployer_Click(object sender, RoutedEventArgs e)
        {
            AddEmployerWindow window = new AddEmployerWindow();
            window.ShowDialog();
        }
        private void btnAddPosition_Click(object sender, RoutedEventArgs e)
        {
            AddPositionWindow window = new AddPositionWindow();
            window.ShowDialog();
        }
        private void btnAddDeal_Click(object sender, RoutedEventArgs e)
        {
            AddDealWindow window = new AddDealWindow();
            window.ShowDialog();
        }
        // 
        // REFRESH FUNCTIONS
        //
        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            switch (status)
            {
                case "TypeOfWork":
                    this.btnRefreshWork_Click(sender, e);
                    break;
                case "JobSeeker":
                    this.btnRefreshSeeker_Click(sender, e);
                    break;
                case "Employer":
                    this.btnRefreshEmployer_Click(sender, e);
                    break;
                case "Position":
                    this.btnRefreshPosition_Click(sender, e);
                    break;
                case "Deal":
                    this.btnRefreshDeal_Click(sender, e);
                    break;
                default:
                    MessageBox.Show("Необходимо выбрать таблицу, в которой обновляется элемент!");
                    return;
            }
        }
        private void btnRefreshWork_Click(object sender, RoutedEventArgs e)
        {
            dgTypeOfWork.ItemsSource = ProcessFactory.GetWorkProcess().GetList();
        }
        private void btnRefreshSeeker_Click(object sender, RoutedEventArgs e)
        {
            dgJobSeeker.ItemsSource = ProcessFactory.GetSeekerProcess().GetList();
        }
        private void btnRefreshEmployer_Click(object sender, RoutedEventArgs e)
        {
            dgEmployer.ItemsSource = ProcessFactory.GetEmployerProcess().GetList();
        }
        private void btnRefreshPosition_Click(object sender, RoutedEventArgs e)
        {
            dgPosition.ItemsSource = ProcessFactory.GetPositionProcess().GetList();
        }
        private void btnRefreshDeal_Click(object sender, RoutedEventArgs e)
        {
            dgDeal.ItemsSource = ProcessFactory.GetDealProcess().GetList();
        }
        // 
        // DELETE FUNCTIONS
        //
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            switch (status)
            {
                case "TypeOfWork":
                    this.btnDeleteWork_Click(sender, e);
                    break;
                case "JobSeeker":
                    this.btnDeleteSeeker_Click(sender, e);
                    break;
                case "Employer":
                    this.btnDeleteEmployer_Click(sender, e);
                    break;
                case "Position":
                    this.btnDeletePosition_Click(sender, e);
                    break;
                case "Deal":
                    this.btnDeleteDeal_Click(sender, e);
                    break;
                default:
                    MessageBox.Show("Необходимо выбрать таблицу, в которой удаляется элемент!");
                    return;
            }
        }
        private void btnDeleteWork_Click(object sender, RoutedEventArgs e)
        {
            TypeOfWorkDto item = dgTypeOfWork.SelectedItem as TypeOfWorkDto;
            if(item ==null)
            {
                MessageBox.Show("Выберите запись для удаления", "Удаление типов работ");
            }
            MessageBoxResult result = MessageBox.Show("Удалить тип: " + item.Name + "?", "Удаление типов работ", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result != MessageBoxResult.Yes)
                return;
            ProcessFactory.GetWorkProcess().Delete(item.WorkID);
            btnRefresh_Click(sender, e);
        }
        private void btnDeleteSeeker_Click(object sender, RoutedEventArgs e)
        {

        }
        private void btnDeleteEmployer_Click(object sender, RoutedEventArgs e)
        {

        }
        private void btnDeletePosition_Click(object sender, RoutedEventArgs e)
        {

        }
        private void btnDeleteDeal_Click(object sender, RoutedEventArgs e)
        {

        }
        // 
        // EDIT FUNCTIONS
        //
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            switch (status)
            {
                case "TypeOfWork":
                    this.btnEditWork_Click(sender, e);
                    break;
                case "JobSeeker":
                    this.btnEditSeeker_Click(sender, e);
                    break;
                case "Employer":
                    this.btnEditEmployer_Click(sender, e);
                    break;
                case "Position":
                    this.btnEditPosition_Click(sender, e);
                    break;
                case "Deal":
                    this.btnEditDeal_Click(sender, e);
                    break;
                default:
                    MessageBox.Show("Необходимо выбрать таблицу, в которой изменяется элемент!");
                    return;
            }
        }
        private void btnEditWork_Click(object sender, RoutedEventArgs e)
        {
            TypeOfWorkDto item = dgTypeOfWork.SelectedItem as TypeOfWorkDto;
            if(item==null)
            {
                MessageBox.Show("Выберите запись для редактирования", "Редактирование типов работ");
            }
            AddTypeOfWorkWindow window = new AddTypeOfWorkWindow();
            window.Load(item);
            window.ShowDialog();
            btnRefresh_Click(sender, e);
        }
        private void btnEditSeeker_Click(object sender, RoutedEventArgs e)
        {

        }
        private void btnEditEmployer_Click(object sender, RoutedEventArgs e)
        {

        }
        private void btnEditPosition_Click(object sender, RoutedEventArgs e)
        {

        }
        private void btnEditDeal_Click(object sender, RoutedEventArgs e)
        {

        }
        //
        //   STATUS
        //
        private void btnTypeOfWork_Click(object sender, RoutedEventArgs e)
        {
            switch(status)
            {
                case "JobSeeker":this.dgJobSeeker.Visibility = Visibility.Hidden;
                    break;
                case "Employer":
                    this.dgEmployer.Visibility = Visibility.Hidden;
                    break;
                case "Position":
                    this.dgPosition.Visibility = Visibility.Hidden;
                    break;
                case "Deal":
                    this.dgDeal.Visibility = Visibility.Hidden;
                    break;
            }
            this.dgTypeOfWork.Visibility = Visibility.Visible;
            status = "TypeOfWork";
            this.btnRefresh_Click(sender, e);
            this.statusLabel.Content = "Работа с таблицей: Виды работ";
        }

        private void btnJobSeeker_Click(object sender, RoutedEventArgs e)
        {
            switch (status)
            {
                case "TypeOfWork":
                    this.dgTypeOfWork.Visibility = Visibility.Hidden;
                    break;
                case "Employer":
                    this.dgEmployer.Visibility = Visibility.Hidden;
                    break;
                case "Position":
                    this.dgPosition.Visibility = Visibility.Hidden;
                    break;
                case "Deal":
                    this.dgDeal.Visibility = Visibility.Hidden;
                    break;
            }
            this.dgJobSeeker.Visibility = Visibility.Visible;
            status = "JobSeeker";
            this.btnRefresh_Click(sender, e);
            this.statusLabel.Content = "Работа с таблицей: Соискатели";
        }

        private void btnEmployer_Click(object sender, RoutedEventArgs e)
        {
            switch (status)
            {
                case "JobSeeker":
                    this.dgJobSeeker.Visibility = Visibility.Hidden;
                    break;
                case "TypeOfWork":
                    this.dgTypeOfWork.Visibility = Visibility.Hidden;
                    break;
                case "Position":
                    this.dgPosition.Visibility = Visibility.Hidden;
                    break;
                case "Deal":
                    this.dgDeal.Visibility = Visibility.Hidden;
                    break;
            }
            this.dgEmployer.Visibility = Visibility.Visible;
            status = "Employer";
            this.btnRefresh_Click(sender, e);
            this.statusLabel.Content = "Работа с таблицей: Работодатели";
        }

        private void btnPosition_Click(object sender, RoutedEventArgs e)
        {
            switch (status)
            {
                case "JobSeeker":
                    this.dgJobSeeker.Visibility = Visibility.Hidden;
                    break;
                case "Employer":
                    this.dgEmployer.Visibility = Visibility.Hidden;
                    break;
                case "TypeOfWork":
                    this.dgTypeOfWork.Visibility = Visibility.Hidden;
                    break;
                case "Deal":
                    this.dgDeal.Visibility = Visibility.Hidden;
                    break;
            }
            this.dgPosition.Visibility = Visibility.Visible;
            status = "Position";
            this.btnRefresh_Click(sender, e);
            this.statusLabel.Content = "Работа с таблицей: Вакансии";
        }

        private void btnDeal_Click(object sender, RoutedEventArgs e)
        {
            switch (status)
            {
                case "JobSeeker":
                    this.dgJobSeeker.Visibility = Visibility.Hidden;
                    break;
                case "Employer":
                    this.dgEmployer.Visibility = Visibility.Hidden;
                    break;
                case "Position":
                    this.dgPosition.Visibility = Visibility.Hidden;
                    break;
                case "TypeOfWork":
                    this.dgTypeOfWork.Visibility = Visibility.Hidden;
                    break;
            }
            this.dgDeal.Visibility = Visibility.Visible;
            status = "Deal";
            this.btnRefresh_Click(sender, e);
            this.statusLabel.Content = "Работа с таблицей: Сделки";
        }
        //
        //  SETTINGS
        //
        private void btnDatabase_Click(object sender, RoutedEventArgs e)
        {
            SettingsWindow window = new SettingsWindow();
            window.ShowDialog();
        }
    }
}
