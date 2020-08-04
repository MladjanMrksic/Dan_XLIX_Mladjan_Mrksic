using HotelApp.Model;
using HotelApp.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HotelApp.Validation
{
    class LoginValidation
    {
        EmployeeModel empmod = new EmployeeModel();
        public void Login (string username, string password, LoginView view)
        {
            List<Employee> employees = empmod.GetAllEmployees();
            if (username == "Master" && password == "Master")
            {
                OwnerView ov = new OwnerView();                
                view.Close();
                ov.Show();
            }
            else if (employees.Contains((from e in employees where e.Username == username && e.Password == password select e).FirstOrDefault()))
            {
                Employee employee = (from e in employees where e.Username == username && e.Password == password select e).FirstOrDefault();
                if (employee.Responsibility!=null)
                {
                    WorkerView wv = new WorkerView();
                    view.Close();
                    wv.Show();
                }
                else
                {
                    ManagerView mv = new ManagerView();
                    view.Close();
                    mv.Show();
                }
            }
            else
            {
                MessageBox.Show("Username or Password was incorrect ", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
