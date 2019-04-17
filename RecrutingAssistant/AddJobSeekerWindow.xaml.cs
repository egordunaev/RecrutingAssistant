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
    /// Логика взаимодействия для AddJobSeekerWindow.xaml
    /// </summary>
    public partial class AddJobSeekerWindow : Window
    {
        private readonly IList<TypeOfWorkDto> Works = ProcessFactory.GetWorkProcess().GetList();
        private int _seekerid;
        public void Load(JobSeekerDto jobSeeker)
        {
            if (jobSeeker == null)
                return;
            _seekerid = jobSeeker.SeekerID;
            tbFirstName.Text = jobSeeker.FirstName;
            tbSecondName.Text = jobSeeker.SecondName;
            if (string.IsNullOrEmpty(jobSeeker.ThirdName) == false)
                tbThirdName.Text = jobSeeker.ThirdName;
            if (string.IsNullOrEmpty(jobSeeker.Qualification) == false)
                tbQualification.Text = jobSeeker.Qualification;
            if (jobSeeker.AssumedSalary.HasValue)
                tbAssumedSalary.Text = jobSeeker.AssumedSalary.ToString();
            if (string.IsNullOrEmpty(jobSeeker.Misc) == false)
                tbMisc.Text = jobSeeker.Misc;
            if(jobSeeker.Work != null)
            {
                foreach(TypeOfWorkDto workDto in Works)
                {
                    if(jobSeeker.Work.WorkID==workDto.WorkID)
                    {
                        this.cbTypeOfWork.SelectedItem = workDto;
                        break;
                    }
                }
            }
        }
        public AddJobSeekerWindow()
        {
            InitializeComponent();
            cbTypeOfWork.ItemsSource = (from W in Works orderby W.Name select W);
            cbTypeOfWork.SelectedIndex = 0;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrEmpty(tbFirstName.Text))
            {
                MessageBox.Show("Имя не должно быть пустым", "Проверка");
                return;
            }
            if (string.IsNullOrEmpty(tbSecondName.Text))
            {
                MessageBox.Show("Фамилия не должна быть пустой", "Проверка");
                return;
            }
            decimal salary;
            decimal.TryParse(tbAssumedSalary.Text, out salary);
            JobSeekerDto jobSeeker = new JobSeekerDto();
            jobSeeker.FirstName = tbFirstName.Text;
            jobSeeker.SecondName = tbSecondName.Text;
            jobSeeker.ThirdName = tbThirdName.Text;
            jobSeeker.Qualification = tbQualification.Text;
            jobSeeker.AssumedSalary = salary ;
            jobSeeker.Misc = tbMisc.Text;
            jobSeeker.Work = cbTypeOfWork.SelectedItem as TypeOfWorkDto;
            IJobSeekerProcess seekerProcess = ProcessFactory.GetSeekerProcess();
            if(_seekerid==0)
            {
                seekerProcess.Add(jobSeeker);
            }
            else
            {
                jobSeeker.SeekerID = _seekerid;
                seekerProcess.Update(jobSeeker);
            }
            Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
