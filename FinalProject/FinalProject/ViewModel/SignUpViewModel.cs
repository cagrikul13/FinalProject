using FinalProject.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace FinalProject.ViewModel
{
    public class SignUpViewModel : INotifyPropertyChanged
    {
        private string username;
        
        public string Username
        {
            get { return username; }
            set
            {
                username = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Username"));
            }
        }

        private string password;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Password"));
            }
        }

        private string confirmpassword;
        public string ConfirmPassword
        {
            get { return confirmpassword; }
            set
            {
                confirmpassword = value;
                PropertyChanged(this, new PropertyChangedEventArgs("ConfirmPassword"));
            }
        }

        public Command SignUpCommand
        {
            get
            {
                return new Command(() =>
                {
                    if (Password == ConfirmPassword)
                        SignUp();
                    else
                        App.Current.MainPage.DisplayAlert("", "Password must be same as above!", "OK");
                });
            }
        }

        private async void SignUp()
        {
            if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password))
                await App.Current.MainPage.DisplayAlert("Empty Values", "Please enter Email and Password", "OK");
            else
            {
                //call AddUser function which we define in Firebase helper class    
                var user = await FirebaseHelper.AddUser(Username, Password);
                //AddUser return true if data insert successfuly     
                if (user)
                {
                    await App.Current.MainPage.DisplayAlert("SignUp Success", "", "Ok");
                    //Navigate to Wellcom page after successfuly SignUp    
                    //pass user email to welcom page    
                    await Application.Current.MainPage.Navigation.PushAsync(new HomePage());
                }
                else
                    await Application.Current.MainPage.DisplayAlert("Error", "SignUp Fail", "OK");

            }
        }



    }
}
