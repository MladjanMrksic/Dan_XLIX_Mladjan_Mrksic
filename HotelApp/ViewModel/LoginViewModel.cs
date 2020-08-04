using HotelApp.Command;
using HotelApp.Validation;
using HotelApp.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace HotelApp.ViewModel
{
    class LoginViewModel
    {
        LoginView login;
        LoginValidation lv = new LoginValidation();

        public LoginViewModel(LoginView log)
        {
            login = log;
        }

        private ICommand submit;

        public ICommand Submit
        {
            get
            {
                if (submit == null)
                {
                    submit = new RelayCommand(param => SubmitExecute(), param => CanSubmitExecute());
                }
                return submit;
            }
        }

        private void SubmitExecute()
        {
            login.passwordBox.Clear();
            lv.Login(login.usernameBox.Text, login.passwordBox.Password, login);
        }

        private bool CanSubmitExecute()
        {
            if (String.IsNullOrEmpty(login.usernameBox.Text) || String.IsNullOrEmpty(login.passwordBox.Password))
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
