using FinalProject.Models;
using FinalProject.ViewModel;
using Firebase.Auth;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinalProject.Views
{
    public partial class HomePage : ContentPage
    {
        FirebaseHelper firebase = new FirebaseHelper();
        public static string webAPIkey = "AIzaSyDBOxgOxBZKB9jKezcVez5ho-nG1aIYmX8";
        List<Activities> activityList;
        HomePageViewModel homePageVM;
        FirebaseAuthProvider firebaseAuthProvider = new FirebaseAuthProvider(new FirebaseConfig(webAPIkey));
        FirebaseAuth firebaseAuth = new FirebaseAuth();
        
       
        public HomePage()
        {
            InitializeComponent();
            homePageVM = new HomePageViewModel();
            BindingContext = homePageVM;
            GetCurrentInfo();

        }

        private async void GetCurrentInfo()
        {
            try
            {
                var savedAuth = JsonConvert.DeserializeObject<Firebase.Auth.FirebaseAuth>(Preferences.Get("MyFirebaseRefreshToken", ""));
                var refreshedContent = await firebaseAuthProvider.RefreshAuthAsync(savedAuth);
                Preferences.Set("MyFirebaseRefreshToken", JsonConvert.SerializeObject(refreshedContent));
                usernameFromFirebase.Text = savedAuth.User.DisplayName;
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
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