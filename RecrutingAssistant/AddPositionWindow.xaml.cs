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
    /// Логика взаимодействия для AddPositionWindow.xaml
    /// </summary>
    public partial class AddPositionWindow : Window
    {
        private readonly IList<EmployerDto> Employers = ProcessFactory.GetEmployerProcess().GetList();
        private int _positionid;
        public void Load(PositionDto positionDto)
        {
            if (positionDto == null)
                return;
            _positionid = positionDto.PositionID;
            if (positionDto.Salary.HasValue)
                tbSalary.Text = positionDto.Salary.ToString();
            if (!string.IsNullOrEmpty(positionDto.PositionName))
                tbPositionName.Text = positionDto.PositionName;
            if (!string.IsNullOrEmpty(positionDto.IsOpen))
                tbIsOpen.Text = positionDto.IsOpen;
            if(positionDto.employer!=null)
            {
                foreach(EmployerDto employerDto in Employers)
                {
                    if(positionDto.employer.EmployerID==employerDto.EmployerID)
                    {
                        this.cbEmployer.SelectedItem = employerDto;
                        break;
                    }
                }
            }
        }
        public AddPositionWindow()
        {
            InitializeComponent();
            cbEmployer.ItemsSource = (from E in Employers orderby E.Name select E);
            cbEmployer.SelectedIndex = 0;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbPositionName.Text))
            {
                MessageBox.Show("Название вакансии не может быть пустым", "Проверка");
                return;
            }
            if (string.IsNullOrEmpty(tbIsOpen.Text))
            {
                MessageBox.Show("Открытость вакансии не может быть пустой", "Проверка");
                return;
            }
            decimal salary;
            decimal.TryParse(tbSalary.Text, out salary);
            PositionDto position = new PositionDto();
            position.PositionName = tbPositionName.Text;
            position.IsOpen = tbIsOpen.Text;
            position.Salary = salary;
            position.employer = cbEmployer.SelectedItem as EmployerDto;
            IPositionProcess positionProcess = ProcessFactory.GetPositionProcess();
            if(_positionid==0)
            {
                positionProcess.Add(position);
            }
            else
            {
                position.PositionID = _positionid;
                positionProcess.Update(position);
            }
            Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
