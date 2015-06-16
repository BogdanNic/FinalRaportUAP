using GalaSoft.MvvmLight;
using Library.Helper_Vm;
using System;
using System.Collections.Generic;
using System.Text;
using Library.Web;
using FinalRaport2.Model;
using Library.Model;

namespace FinalRaport2.ViewModel
{
    public class LoginVM:ViewModelBase
    {
        public LoginVM()
        {

            LoginCommand = new Command(LoginAction);
        }
        public async void LoginAction()
        {
            if(!string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Password))
            {
                User user=new User(){Username=Username,Password=Password};
                string resp=await RestBasedDB<PredRaport>.Login(user);
            }
        }
        public Command LoginCommand { get; set; }
        private string _username;
        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
                RaisePropertyChanged("Username");
            }
        }
        private string _password;
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                RaisePropertyChanged("Password");
            }
        }
        
    }
}
