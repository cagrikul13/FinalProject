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
    public partial class ActivityPage : ContentPage
    {
        public ActivityPage(string activityTime,string activityLocation, string activityCategory)
        {
            InitializeComponent();
            activity_Time.Text = activityTime;
            //activity_Location.Text = activityLocation;
            //activity_Category.Text = activityCategory;
        }
    }
}