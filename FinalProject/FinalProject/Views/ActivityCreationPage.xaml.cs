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
    public partial class ActivityCreationPage : ContentPage
        
    {
        public ActivityCreationPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            var navigationPage = Application.Current.MainPage as NavigationPage;
            navigationPage.BarBackgroundColor = Color.MediumPurple;
        }

        private void ClearAll_Clicked(object sender, EventArgs e)
        {
            var today = DateTime.Now;
            SelectCategory.SelectedIndex = -1;
            ParticipantAmount.SelectedIndex = -1;
            SelectDate.Date = DateTime.Now;
            SelectTime.Time = DateTime.Now.TimeOfDay;
        }

        private void CreateActivity_Clicked(object sender, EventArgs e)
        {
            HomePageViewModel homePageViewModel = new HomePageViewModel();
            homePageViewModel.ActivitiesList.Add(
                new Models.Activities()
                {
                    
                });
        }
    }
}