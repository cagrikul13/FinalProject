using FinalProject.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;

namespace FinalProject.ViewModel
{
    class MainPageViewModel
    {
        public Command Login
        {
            get
            {
                return new Command(OpenLoginPage);
            }
        }
        private async void OpenLoginPage()
        {
            await App.Current.MainPage.Navigation.PushAsync(new LoginPage());
        }
        public Command SignUp
        {
            get
            {
                return new Command(OpenSignUpPage);
            }
        }
        private async void OpenSignUpPage()
        {
            await App.Current.MainPage.Navigation.PushAsync(new SignUpPage());
        }
    }
}
