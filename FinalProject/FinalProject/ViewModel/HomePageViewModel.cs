using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace FinalProject.ViewModel
{
    class HomePageViewModel 
    {
        public List<Activities> ActivityList { get; set; } 

        public List<ObservableCollection<Activities>> GroupedData { get; set; }

        public HomePageViewModel()
        {
            var repo = new ActivityRepo();
            ActivityList = repo.GetActivities.OrderBy(p => p.activityLocation).ToList();
            GroupedData = ActivityList
                .GroupBy(p=>p.activityCategory.ToString())
                .Select(p => new ObservableCollection<Activities>(p))
                .ToList();
        }

        /*private string username;
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
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Password"));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public Command UpdateCommand
        {
            get { return new Command(Update); }
        }

        private async void Update()
        {
            try
            {
                if (!string.IsNullOrEmpty(Password))
                {
                    var isUpdate = await FirebaseHelper.UpdateUser(Username, Password);
                    if (isUpdate)
                        await App.Current.MainPage.DisplayAlert("Update Success", "", "Ok");
                    else
                        await App.Current.MainPage.DisplayAlert("Error", "Record not updated", "Ok");
                }
                else
                    await App.Current.MainPage.DisplayAlert("Password Require", "Please Enter your password", "Ok");
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
            }
        }

        public Command DeleteCommand
        {
            get { return new Command(Delete); }
        }

        private async void Delete()
        {
            try
            {
                var isDelete = await FirebaseHelper.DeleteUser(Username);
                if (isDelete)
                    await App.Current.MainPage.Navigation.PopAsync();
                else
                    await App.Current.MainPage.DisplayAlert("Error", "Record not deleted", "Ok");
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
            }
        }

        public Command LogoutCommand
        {
            get
            {
                return new Command(() =>
                {
                    App.Current.MainPage.Navigation.PopAsync();
                });
            }
        }*/

    }
}

