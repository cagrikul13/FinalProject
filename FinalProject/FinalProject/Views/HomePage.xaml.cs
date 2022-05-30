using FinalProject.Models;
using FinalProject.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinalProject.Views
{
    public partial class HomePage : ContentPage
    {
        FirebaseHelper firebase = new FirebaseHelper();
        List<Activities> activityList;
        HomePageViewModel homePageVM; 
        public HomePage()
        {
            InitializeComponent();
            homePageVM = new HomePageViewModel();
            BindingContext = homePageVM;
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            activityList = await firebase.GetActivities();
            myActivityList.BindingContext = activityList;
        }

        
        async private void Settings_Clicked(object sender, EventArgs e)
        {
                await Navigation.PushModalAsync(new SettingsPage());
        }
    }
}