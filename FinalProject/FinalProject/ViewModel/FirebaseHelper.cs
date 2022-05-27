using FinalProject.Models;
using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.ViewModel
{
    public class FirebaseHelper
    {
        public static FirebaseClient firebase = new FirebaseClient("https://actio-5ec97-default-rtdb.firebaseio.com/");
    
        //Read all
        public static async Task<List<Users>> GetAllUsers()
        {
            try
            {
                var userList = (await firebase
                    .Child("Users")
                    .OnceAsync<Users>()).Select(item =>
                    new Users
                    {
                        username = item.Object.username,
                        password = item.Object.password,

                    }).ToList();
                return userList;
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return null;
            }
        }
        //Read 
        public static async Task<Users> GetUser(string username)
        {
            try
            {
                var allUsers = await GetAllUsers();
                await firebase
                    .Child("Users")
                    .OnceAsync<Users>();
                return allUsers.Where(a => a.username == username).FirstOrDefault();
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return null;
            }
        }
        //Insert a user
        public static async Task<bool> AddUser(string Username, string Password)
        {
            try
            {
                await firebase.Child("Users").PostAsync(new Users()
                {
                    username = Username, password = Password
                });
                return true;
            }
            catch (Exception e )
            {
                Debug.WriteLine($"Error:{e}");
                return false;
            }
        }
        //Update
        public static async Task<bool> UpdateUser(string Username,string Password)
        {
            try
            {
                var toUpdateUser = (await firebase
                    .Child("Users")
                    .OnceAsync<Users>())
                    .Where(a => a.Object.username == Username).FirstOrDefault();
                await firebase
                    .Child("Users")
                    .Child(toUpdateUser.Key)
                    .PutAsync(new Users() { username = Username, password = Password });
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return false;
            }
        }

        //Delete User
        public static async Task<bool> DeleteUser(string Username)
        {
            try
            {
                var toDeletePerson = (await firebase
                    .Child("Users")
                    .OnceAsync<Users>())
                    .Where(a => a.Object.username == Username).FirstOrDefault();
                await firebase.Child("Users").Child(toDeletePerson.Key).DeleteAsync();
                return true;
            
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return false;

            }
        }

        public async Task<List<Room>> getRoomList()
        {
            return (await firebase
                .Child("ChatApp")
                .OnceAsync<Room>())
                .Select((item) =>
                new Room
                {
                    Key = item.Key,
                    roomName = item.Object.roomName
                }

                       ).ToList();
        }

        public async Task saveRoom(Room rm)
        {
            await firebase.Child("ChatApp")
                    .PostAsync(rm);

        }

        public async Task saveMessage(Chat _ch, string _room)
        {
            await firebase.Child("ChatApp/" + _room + "/Message")
                    .PostAsync(_ch);
        }
        public ObservableCollection<Chat> subChat(string _roomKEY)
        {

            return firebase.Child("ChatApp/" + _roomKEY + "/Message")
                           .AsObservable<Chat>()
                           .AsObservableCollection<Chat>();
        }


    }
}
