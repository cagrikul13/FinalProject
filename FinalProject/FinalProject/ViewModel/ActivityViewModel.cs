using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace FinalProject.ViewModel
{
    public class ActivityViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string activityDate;
        private string activityTime;
        private string activityCategory;
        private string activityParticipiantCount;

        public string ActivityDate {
            get { return activityDate; }
            set {
                activityDate = value;
                PropertyChanged(this, new PropertyChangedEventArgs("ActivityDate"));
            } }

        public string ActivityTime
        {
            get { return activityTime; }
            set
            {
                activityTime = value;
                PropertyChanged(this, new PropertyChangedEventArgs("ActivityTime"));
            }
        }

        public string ActivityCategory
        {
            get { return activityCategory; }
            set
            {
                activityCategory = value;
                PropertyChanged(this, new PropertyChangedEventArgs("ActivityCategory"));
            }
        }

        public string ActivityParticipiantCount
        {
            get { return activityParticipiantCount; }
            set
            {
                activityParticipiantCount = value;
                PropertyChanged(this, new PropertyChangedEventArgs("ActivityParticipiantCount"));
            }
        }



        public Command AddActivity
        {
            get
            {
                return new Command(AddActivityCommand);
            }
        }

        private async void AddActivityCommand()
        {
            await FirebaseHelper.AddActivity(ActivityDate, ActivityTime, ActivityCategory, ActivityParticipiantCount);
            
        }
    }
}
