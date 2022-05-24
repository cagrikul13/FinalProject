using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Models
{
    class ActivityRepo
    {
        public List<Activities> GetActivities { get; set; }

        public ActivityRepo()
        {
            GetActivities = new List<Activities>();
            GetActivities.Add(new Activities {
                activityTime = "15 Kasım Saat 13-15",
                activityLocation = "Çarşı A Spor Salonu",
                activityCategory = "Basketball"
            });
        }
    }
}
