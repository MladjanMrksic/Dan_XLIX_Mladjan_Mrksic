using HotelApp.Command;
using HotelApp.Model;
using HotelApp.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HotelApp.ViewModel
{
    class AddEmployeesViewModel : ViewModelBase
    {
        AddEmployeesView addEmpView;
        EmployeeModel empMod = new EmployeeModel();
        public AddEmployeesViewModel(AddEmployeesView aev)
        {
            addEmpView = aev;
        }

        private Employee employee;

        public Employee Employee
        {
            get { return employee; }
            set { employee = value; OnPropertyChanged("Employee"); }
        }

        private ICommand createManager;
        public ICommand CreateManager
        {
            get
            {
                if (createManager == null)
                {
                    createManager = new RelayCommand(param => CreateManagerExecute(), param => CanCreateManagerExecute());
                }
                return createManager;
            }
        }
        private void CreateManagerExecute()
        {
            addEmpView.Gender.Visibility = System.Windows.Visibility.Hidden;
            addEmpView.Citizenship.Visibility = System.Windows.Visibility.Hidden;
            addEmpView.Responsibility.Visibility = System.Windows.Visibility.Hidden;
            addEmpView.Paycheck.Visibility = System.Windows.Visibility.Hidden;
            addEmpView.txtGender.Visibility = System.Windows.Visibility.Hidden;
            addEmpView.txtCitizenship.Visibility = System.Windows.Visibility.Hidden;
            addEmpView.txtResponsibility.Visibility = System.Windows.Visibility.Hidden;
            addEmpView.txtPaycheck.Visibility = System.Windows.Visibility.Hidden;            
            addEmpView.WorkExperience.Visibility = System.Windows.Visibility.Visible;
            addEmpView.ProfessionalQualifications.Visibility = System.Windows.Visibility.Visible;
            addEmpView.txtWorkExperience.Visibility = System.Windows.Visibility.Visible;
            addEmpView.txtProfessionalQualifications.Visibility = System.Windows.Visibility.Visible;
        }
        private bool CanCreateManagerExecute()
        {
            return true;
        }

        private ICommand createWorker;
        public ICommand CreateWorker
        {
            get
            {
                if (createWorker == null)
                {
                    createWorker = new RelayCommand(param => CreateWorkerExecute(), param => CanCreateWorkerExecute());
                }
                return createWorker;
            }
        }
        private void CreateWorkerExecute()
        {
            addEmpView.Gender.Visibility = System.Windows.Visibility.Visible;
            addEmpView.Citizenship.Visibility = System.Windows.Visibility.Visible;
            addEmpView.Responsibility.Visibility = System.Windows.Visibility.Visible;
            addEmpView.Paycheck.Visibility = System.Windows.Visibility.Visible;
            addEmpView.txtGender.Visibility = System.Windows.Visibility.Visible;
            addEmpView.txtCitizenship.Visibility = System.Windows.Visibility.Visible;
            addEmpView.txtResponsibility.Visibility = System.Windows.Visibility.Visible;
            addEmpView.txtPaycheck.Visibility = System.Windows.Visibility.Visible;
            addEmpView.WorkExperience.Visibility = System.Windows.Visibility.Hidden;
            addEmpView.ProfessionalQualifications.Visibility = System.Windows.Visibility.Hidden;
            addEmpView.txtWorkExperience.Visibility = System.Windows.Visibility.Hidden;
            addEmpView.txtProfessionalQualifications.Visibility = System.Windows.Visibility.Hidden;
        }
        private bool CanCreateWorkerExecute()
        {
            return true;
        }

        private ICommand save;
        public ICommand Save
        {
            get
            {
                if (save == null)
                {
                    save = new RelayCommand(param => SaveExecute(), param => CanSaveExecute());
                }
                return save;
            }
        }
        private void SaveExecute()
        {
            empMod.AddEmployee(Employee);
            OwnerView ov = new OwnerView();
            addEmpView.Close();
            ov.Show();
        }
        private bool CanSaveExecute()
        {
            return true;
        }



    }
}
