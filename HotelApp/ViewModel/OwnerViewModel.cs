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
        OwnerView view = new OwnerView();
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
    }
}
