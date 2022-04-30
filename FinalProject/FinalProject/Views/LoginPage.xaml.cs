using FinalProject.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AsyncTask = System.Threading.Tasks.Task;


namespace FinalProject.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        private string username;
        private string password;
        public LoginPage()
        {
            InitializeComponent();
        }
        private async void Login()
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                await App.Current.MainPage.DisplayAlert("Empty Values", "Please enter Email and Password", "OK");
            else
            {
                var user = await FirebaseHelper.GetUser(username);
                if(user!=null)
                    if(username == user.username && password == user.password)
                    {
                        await App.Current.MainPage.DisplayAlert("Login Success", "", "Ok");
                        await App.Current.MainPage.Navigation.PushAsync(new MainPage(username));
                    }
                    else
                        await App.Current.MainPage.DisplayAlert("Login Fail", "Please enter correct Email and Password", "OK");
                else
                    await App.Current.MainPage.DisplayAlert("Login Fail", "User not found", "OK");

            }
        }
        


    }
}