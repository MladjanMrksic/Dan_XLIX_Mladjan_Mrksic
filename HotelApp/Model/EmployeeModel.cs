using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HotelApp.Model
{
    class EmployeeModel
    {
        public List<Employee> GetAllEmployees()
        {
            try
            {
                using (HotelDatabaseEntities context = new HotelDatabaseEntities())
                {
                    List<Employee> employees = new List<Employee>();
                    employees = (from e in context.Employees select e).ToList();
                    return employees;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception " + ex.Message.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
        }

        public List<Employee> GetAllWorkers()
        {
            try
            {
                using (HotelDatabaseEntities context = new HotelDatabaseEntities())
                {
                    List<Employee> employees = new List<Employee>();
                    employees = (from e in context.Employees where e.Responsibility!=null select e).ToList();
                    return employees;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception " + ex.Message.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
        }

        public List<Employee> GetAllManagers()
        {
            try
            {
                using (HotelDatabaseEntities context = new HotelDatabaseEntities())
                {
                    List<Employee> employees = new List<Employee>();
                    employees = (from e in context.Employees where e.ProfesionalQualifications!= null select e).ToList();
                    return employees;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception " + ex.Message.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
        }

        public Employee GetEmployee(int ID)
        {
            try
            {
                using (HotelDatabaseEntities context = new HotelDatabaseEntities())
                {                    
                    Employee employee = (from e in context.Employees where e.EmployeeID == ID select e).FirstOrDefault();
                    return employee;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception " + ex.Message.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
        }

        public void DeleteEmployee (int ID)
        {
            try
            {
                using (HotelDatabaseEntities context = new HotelDatabaseEntities())
                {
                    Employee employee = (from e in context.Employees where e.EmployeeID == ID select e).FirstOrDefault();
                    context.Employees.Remove(employee);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception " + ex.Message.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void AddEmployee (Employee e)
        {
            try
            {
                using (HotelDatabaseEntities context = new HotelDatabaseEntities())
                {
                    context.Employees.Add(e);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception " + ex.Message.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void UpdateEmployee(Employee emp)
        {
            try
            {
                using (HotelDatabaseEntities context = new HotelDatabaseEntities())
                {
                    Employee employee = (from e in context.Employees where e.EmployeeID == emp.EmployeeID select e).FirstOrDefault();
                    employee = emp;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception " + ex.Message.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
