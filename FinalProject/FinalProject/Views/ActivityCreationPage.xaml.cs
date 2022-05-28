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
            SelectDate.Text = DateTime.Now.ToString();
            SelectTime.Text = DateTime.Now.TimeOfDay.ToString();
        }

        
    }
}