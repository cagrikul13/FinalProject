using FinalProject.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinalProject
{
    
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ProfilePage), typeof(ProfilePage));
            Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));
            Routing.RegisterRoute(nameof(ActivityCreationPage), typeof(ActivityCreationPage));
        }
        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.Navigation.PushAsync(new LoginPage());
        }
    }
}