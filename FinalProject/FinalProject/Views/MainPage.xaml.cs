using FinalProject.ViewModel;
using FinalProject.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FinalProject
{
    public partial class MainPage : ContentPage
    {
        MainPageViewModel mainPageVM;
        public MainPage(string username)
        {
            InitializeComponent();
            mainPageVM = new MainPageViewModel();
            BindingContext = mainPageVM;
        }
        public MainPage()
        {
            InitializeComponent();
            mainPageVM = new MainPageViewModel();
            BindingContext = mainPageVM;
        }
        private async void loginBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new LoginPage());
        }
        private async void signUpBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new SignUpPage());
        }
        private async void TestButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new QRCodePage());
        }
        private async void TestButton1_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new QRScannerPage());
        }
    }
}
