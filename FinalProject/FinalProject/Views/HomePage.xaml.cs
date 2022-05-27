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
    public partial class HomePage : ContentPage
    {
        HomePageViewModel homePageVM; 
        public HomePage()
        {
            InitializeComponent();
            homePageVM = new HomePageViewModel();
            BindingContext = homePageVM;
        }
    }
}