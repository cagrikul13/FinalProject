using FinalProject.Models;
using FinalProject.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinalProject.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
    {
        FirebaseHelper firebase = new FirebaseHelper();
        HomePageViewModel profilePageVM;
        List<Activities> profilePageList;

        public ProfilePage()
        {
            InitializeComponent();
            profilePageVM = new HomePageViewModel();
            BindingContext = profilePageVM;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            profilePageList = await firebase.GetActivities();
            ppActivityList.BindingContext = profilePageList;

        }
    }


}