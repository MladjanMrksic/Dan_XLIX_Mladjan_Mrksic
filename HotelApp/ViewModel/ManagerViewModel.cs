﻿using HotelApp.Command;
using HotelApp.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HotelApp.ViewModel
{
    class ManagerViewModel
    {
        ManagerView view;

        public ManagerViewModel(ManagerView mv)
        {
            view = mv;
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
    }
}
