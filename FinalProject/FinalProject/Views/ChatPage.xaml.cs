using FinalProject.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProject.Models;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinalProject.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChatPage : ContentPage
    {
        FirebaseHelper fbClient = new FirebaseHelper();

        Room room = new Room();

        Users user = new Users();
        public ChatPage()
        {
            InitializeComponent();

            MessagingCenter.Subscribe<ChatRoom, Room>(this, "RoomProp", (page, data) =>
            {
                room = data;
                chatListView.BindingContext = fbClient.subChat(data.Key);
                MessagingCenter.Unsubscribe<ChatRoom, Room>(this, "RoomProp");
            });
        }        

        private async void sendButtonClicked(object sender, EventArgs e)
        {
            var chatObject = new Chat
            {
                userMessage = messageToSent.Text,
                username = user.name
            };
            await fbClient.saveMessage(chatObject, room.Key);
            messageToSent.Text = String.Empty;
        }
    }
}