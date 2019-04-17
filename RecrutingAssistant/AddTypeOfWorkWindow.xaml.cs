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
    /// Логика взаимодействия для AddTypeOfWorkWindow.xaml
    /// </summary>
    public partial class AddTypeOfWorkWindow : Window
    {
        public AddTypeOfWorkWindow()
        {
            InitializeComponent();
        }
        private int _workid;
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrEmpty(tbName.Text))
            {
                MessageBox.Show("Тип работы не может быть пустым", "Проверка");
                return;
            }
            TypeOfWorkDto typeOfWork = new TypeOfWorkDto();
            typeOfWork.Name = tbName.Text;
            ITypeOfWorkProcess typeOfWorkProcess = ProcessFactory.GetWorkProcess();
            if(_workid==0)
            {
                typeOfWorkProcess.Add(typeOfWork);
            }
            else
            {
                typeOfWork.WorkID = _workid;
                typeOfWorkProcess.Update(typeOfWork);
            }
            Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        public void Load(TypeOfWorkDto typeOfWork)
        {
            if (typeOfWork == null)
                return;
            _workid = typeOfWork.WorkID;
            tbName.Text = typeOfWork.Name;
        }
    }
}
