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
    /// Логика взаимодействия для AddEmployerWindow.xaml
    /// </summary>
    public partial class AddEmployerWindow : Window
    {
        private readonly IList<TypeOfWorkDto> Works = ProcessFactory.GetWorkProcess().GetList();
        private int _employerid;
        public void Load(EmployerDto employerDto)
        {
            if (employerDto == null)
                return;
            _employerid = employerDto.EmployerID;
            tbName.Text = employerDto.Name;
            tbAddress.Text = employerDto.Address;
            if (string.IsNullOrEmpty(employerDto.PhoneNumber) == false)
                tbPhoneNumber.Text = employerDto.PhoneNumber;
            if(employerDto.Work!=null)
            {
                foreach(TypeOfWorkDto workDto in Works)
                {
                    if(employerDto.Work.WorkID==workDto.WorkID)
                    {
                        this.cbTypeOfWork.SelectedItem = workDto;
                        break;
                    }
                }
            }
        }
        public AddEmployerWindow()
        {
            InitializeComponent();
            cbTypeOfWork.ItemsSource = (from W in Works orderby W.Name select W);
            cbTypeOfWork.SelectedIndex = 0;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrEmpty(tbName.Text))
            {
                MessageBox.Show("Имя работодателя не может быть пустым", "Проверка");
                return;
            }
            if(string.IsNullOrEmpty(tbAddress.Text))
            {
                MessageBox.Show("Адрес работодателя не может быть пустым", "Проверка");
                return;
            }
            EmployerDto employer = new EmployerDto();
            employer.Name = tbName.Text;
            employer.Address = tbAddress.Text;
            employer.PhoneNumber = tbPhoneNumber.Text;
            employer.Work = cbTypeOfWork.SelectedItem as TypeOfWorkDto;
            IEmployerProcess employerProcess = ProcessFactory.GetEmployerProcess();
            if(_employerid==0)
            {
                employerProcess.Add(employer);
            }
            else
            {
                employer.EmployerID = _employerid;
                employerProcess.Update(employer);
            }
            Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
