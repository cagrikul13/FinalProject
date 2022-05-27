using FinalProject.Models;
using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
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

        public static async Task<List<Activities>> GetActivities()
        {
            var activityList = (await firebase
                .Child("Activities")
                .OnceAsync<Activities>()).Select(item => new Activities
                {
                    activityCategory = item.Object.activityCategory,
                    activityParticipiantCount = item.Object.activityParticipiantCount,
                    activityDate = item.Object.activityDate,
                    activityTime = item.Object.activityTime
                }).ToList();
            return activityList;
        }

        public static async Task<bool> AddActivity(string activity_Category, string activityParticipiant_Count, string activity_Date, string activity_Time)
        {

            await firebase.Child("Activities").PostAsync(new Activities()
            {
                activityParticipiantCount = activityParticipiant_Count,
                activityCategory = activity_Category,
                activityDate = activity_Date,
                activityTime = activity_Time
            });
            return true;
        }
    
    }
}
