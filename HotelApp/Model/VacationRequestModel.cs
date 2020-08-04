using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HotelApp.Model
{
    class VacationRequestModel
    {
        public List<VacationRequest> GetAllVacationRequests()
        {
            try
            {
                using (HotelDatabaseEntities context = new HotelDatabaseEntities())
                {
                    return (from r in context.VacationRequests select r).ToList(); ;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception " + ex.Message.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
        }

        public VacationRequest GetVacationRequest(int ID)
        {
            try
            {
                using (HotelDatabaseEntities context = new HotelDatabaseEntities())
                {
                    return (from r in context.VacationRequests where r.RequestID == ID select r).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception " + ex.Message.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
        }

        public void DeleteVacationRequest(int ID)
        {
            try
            {
                using (HotelDatabaseEntities context = new HotelDatabaseEntities())
                {
                    context.VacationRequests.Remove((from r in context.VacationRequests where r.RequestID == ID select r).FirstOrDefault());
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception " + ex.Message.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void AddVacationRequest(VacationRequest vr)
        {
            try
            {
                using (HotelDatabaseEntities context = new HotelDatabaseEntities())
                {
                    context.VacationRequests.Add(vr);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception " + ex.Message.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void UpdateVacationRequest(VacationRequest vr)
        {
            try
            {
                using (HotelDatabaseEntities context = new HotelDatabaseEntities())
                {
                    VacationRequest request = (from r in context.VacationRequests where r.RequestID == vr.RequestID select r).FirstOrDefault();
                    request = vr;
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
