using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BM_TimeTracker.Classes
{
    public class CritItem
    {
        DateTime date;
        int time;

        User user;


        /// <summary>
        /// Returns the time in minutes of this critItem
        /// </summary>
        public int Time
        {
            get { return time; }
        }
        /// <summary>
        /// Returns the date of this critItem
        /// </summary>
        public DateTime Date
        {
            get { return date; }
        }

        public CritItem(DateTime dt, int intZeit)
        {
            date = dt;
            time = intZeit;
        }
        public int UserID
        {
            get { return user.ID; }
        }


        public CritItem(DateTime dt, int time, User user)
        {
            this.date = dt;
            this.time = time;

            this.user = user;
        }

        public override string ToString()
        {
            return Ressources.strings.global_time + ": " + user.Name + " (" + date.ToString("dd.MM.yyyy") + ") " + " " + Ressources.strings.global_time + ": " + time;
        }
        /// <summary>
        /// Get all critical items of all users
        /// </summary>
        /// <returns>List of critical items</returns>
        public static List<CritItem> GetAllFromDataBase()
        {
            List<CritItem> retList = new List<CritItem>();
            DataTable kritischTable = TimeTrackerDataProvider.Instance().GetAllUsersLoggedWithDate();
            foreach (DataRow row in kritischTable.Rows)
            {
                DateTime date = DateTime.ParseExact(row["datum"].ToString(), "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                int userID = Convert.ToInt32(row["UserID"]);
                string userName = row["Username"].ToString();

                User user = new User(userID, userName);
                if (User.UserDontBreaksCritTime(user, date))
                {
                    List<Task> aufgaben = user.GetTasksByStartEnd(date.Date, date.Date.AddDays(1));
                    int time = Task.CalcTimeFromTaskList(aufgaben);
                    retList.Add(new CritItem(date, time, user));
                }
            }

            return retList;
        }
    }
}
