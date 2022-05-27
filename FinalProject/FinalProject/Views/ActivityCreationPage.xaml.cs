using FinalProject.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProject.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinalProject.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ActivityCreationPage : ContentPage
        
    {

        ActivityViewModel activityViewModel;
        public ActivityCreationPage()
        {
            InitializeComponent();
            activityViewModel = new ActivityViewModel();
            BindingContext = activityViewModel;

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
            homePageViewModel.ActivitiesList.Add(new Activities
            {
                activityCategory = SelectCategory.SelectedIndex.ToString(),
                activityParticipiantCount = ParticipantAmount.SelectedIndex.ToString(),
                activityDate = SelectDate.Date.ToString(),
                activityTime = SelectTime.Time.ToString(),
            });
               
                
        }
    }
}