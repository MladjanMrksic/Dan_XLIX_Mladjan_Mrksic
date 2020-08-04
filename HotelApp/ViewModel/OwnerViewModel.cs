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
    class OwnerViewModel : ViewModelBase
    {
        OwnerView view;
        EmployeeModel empMod = new EmployeeModel();

        public OwnerViewModel(OwnerView v)
        {
            employeeList = empMod.GetAllEmployees();
            view = v;
        }

        private List<Employee> employeeList;

        public List<Employee> EmployeeList
        {
            get { return employeeList; }
            set { employeeList = value; OnPropertyChanged("EmployeeList"); }
        }

        private Employee employee;

        public Employee Employee
        {
            get { return employee; }
            set { employee = value; OnPropertyChanged("Employee"); }
        }

        private ICommand deleteEmployee;
        public ICommand DeleteEmployee
        {
            get
            {
                if (deleteEmployee == null)
                {
                    deleteEmployee = new RelayCommand(param => DeleteEmployeeExecute(), param => CanDeleteEmployeeExecute());
                }
                return deleteEmployee;
            }
        }
        private void DeleteEmployeeExecute()
        {
            empMod.DeleteEmployee(Employee.EmployeeID);
            EmployeeList = empMod.GetAllEmployees();
        }
        private bool CanDeleteEmployeeExecute()
        {
            if (Employee == null)
            {
                return false;
            }
            else
            {
                return true;
            }            
        }

        private ICommand logout;
        public ICommand Logout
        {
            get
            {
                if (logout == null)
                {
                    logout = new RelayCommand(param => LogoutExecute(), param => CanLogoutExecute());
                }
                return logout;
            }
        }
        private void LogoutExecute()
        {
            LoginView logout = new LoginView();
            view.Close();
            logout.Show();
        }
        private bool CanLogoutExecute()
        {
            return true;
        }

        private ICommand addEmployee;
        public ICommand AddEmployee
        {
            get
            {
                if (addEmployee == null)
                {
                    addEmployee = new RelayCommand(param => AddEmployeeExecute(), param => CanAddEmployeeExecute());
                }
                return addEmployee;
            }
        }
        private void AddEmployeeExecute()
        {
            AddEmployeesView add = new AddEmployeesView();
            view.Close();
            add.Show();
        }
        private bool CanAddEmployeeExecute()
        {
            return true;
        }
    }
}
