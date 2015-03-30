using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

using BM_TimeTracker.Classes;

namespace BM_TimeTracker.Classes
{
    public class User
    {//Object that represents a user
        int id;
        string name;
        string password;
        bool admin;

        public bool Admin
        {
            get { return admin; }
            set { admin = value; }
        }

        public int ID
        {
            get { return id; }
        }
        public string Name
        {
            get { return name; }
        }

        /// <summary>
        /// Creates a user from a DataRow 
        /// </summary>
        /// <param name="row">Row from the database</param>
        public User(DataRow row)
        {
            this.id = Convert.ToInt32(row["userID"]);
            this.name = row["Username"].ToString();
            this.admin = Convert.ToBoolean(row["admin"]);
        }
        public User(string Username, string Password)
        {
            this.name = Username;
            this.password = Password;
        }
        public User(int UserID, string Username)
        {
            id = UserID;
            name = Username;
        }
        public User(int UserID)
        {
            this.id = UserID;
        }

        /// <summary>
        /// Verifies the User against the database.
        /// If the Verification is successful it loads the ID and Admin Value of the User
        /// </summary>
        /// <returns>Returns if the Verification was successful</returns>
        public bool VerifyUser()
        {
            DataTable userTable = TimeTrackerDataProvider.Instance().GetUserByUserName(this.name);
            if (userTable.Rows.Count > 0)
            {
                string guidString = userTable.Rows[0]["guid"].ToString();
                string hashFromUser = Hash.HashString(this.password + guidString, "CoastComTimeTracker");

                string hashFromDataBase = userTable.Rows[0]["password"].ToString();
                string userNameFromDataBase = userTable.Rows[0]["username"].ToString();

                if (hashFromUser == hashFromDataBase && name == userNameFromDataBase)
                {
                    this.id = Convert.ToInt32(userTable.Rows[0]["userID"]);
                    this.admin = Convert.ToBoolean(userTable.Rows[0]["admin"]);
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Checks if the User exists in the Database or not
        /// </summary>
        public bool ExistsInDataBase
        {
            get { return TimeTrackerDataProvider.Instance().GetUserByUserName(this.name).Rows.Count > 0; }
        }

        /// <summary>
        /// Creates a User in the Database
        /// </summary>
        public void CreateUserInDataBaseGetID()
        {
            bool admin = false;
            CreateUserInDataBaseGetID(admin);
        }
        /// <summary>
        /// Creates a Admin in the Database
        /// </summary>
        public void CreateAdminInDataBaseGetID()
        {
            bool admin = true;
            CreateUserInDataBaseGetID(admin);
        }
        /// <summary>
        /// updates the current users password in the database
        /// </summary>
        /// <param name="newPassword">New Password before hash</param>
        public void UpdatePasswordInDataBase(string newPassword)
        {
            string userGuid = TimeTrackerDataProvider.Instance().GetUserGuidByID(this.id).Rows[0][0].ToString();
            string newPasswordHash = Hash.HashString(newPassword + userGuid, "CoastComTimeTracker");
            TimeTrackerDataProvider.Instance().UpdateUserPassword(this.id, newPasswordHash);
        }
        /// <summary>
        /// Updates the admin and the password value of this user in the database
        /// </summary>
        /// <param name="newPassword">New password before hash</param>
        /// <param name="admin">New admin value</param>
        public void UpdateAdminPasswordInDataBase(string newPassword, bool admin)
        {
            string userGuid = TimeTrackerDataProvider.Instance().GetUserGuidByID(this.id).Rows[0][0].ToString();
            string newPasswordHash = Hash.HashString(newPassword + userGuid, "CoastComTimeTracker");
            TimeTrackerDataProvider.Instance().UpdateUserPasswordAdmin(this.id, newPasswordHash, admin);
        }
        public void DeleteInDataBase()
        {
            TimeTrackerDataProvider.Instance().DeleteUserByUserID(this.id);
        }
        /// <summary>
        /// Creates a user or a admin in the database
        /// </summary>
        /// <param name="admin">Is the user a admin or not?</param>
        private void CreateUserInDataBaseGetID(bool admin)
        {
            string userGuid = Guid.NewGuid().ToString();
            string passwordHash = Hash.HashString(this.password + userGuid, "CoastComTimeTracker");
            DataTable userID = TimeTrackerDataProvider.Instance().InsertUserGetID(this.name, passwordHash, userGuid, admin);
            this.id = Convert.ToInt32(userID.Rows[0][0]);
        }
        /// <summary>
        /// Get all aufgabe objects between start and end of the current User
        /// </summary>
        /// <param name="start">start datetime</param>
        /// <param name="end">end datetime</param>
        /// <returns></returns>
        public List<Task> GetTasksByStartEnd(DateTime start, DateTime end)
        {
            List<Task> retList = new List<Task>();
            foreach (DataRow row in TimeTrackerDataProvider.Instance().GetAufgabeByStartdatumEnddatumUser(this.id, start, end).Rows)
            {
                retList.Add(new Task(row, this));
            }
            return retList;
        }
        /// <summary>
        /// Get all aufgabe objects that are active between start and end of the current user
        /// </summary>
        /// <param name="start">start datetime</param>
        /// <param name="end">end datetime</param>
        /// <returns></returns>
        public List<Task> GetTasksByStartEndActive(DateTime start, DateTime end)
        {
            List<Task> retList = new List<Task>();
            foreach (DataRow row in TimeTrackerDataProvider.Instance().GetAufgabeByStartdatumEnddatumUserAktiv(this.id, start, end).Rows)
            {
                retList.Add(new Task(row, this));
            }
            return retList;
        }
        /// <summary>
        /// Stops the current running aufgabe object of the current User
        /// </summary>
        public void StopCurrentTask()
        {
            TimeTrackerDataProvider.Instance().StopCurrentRunnigEvent(this.id);
        }
        /// <summary>
        /// Gets the id of the current running task of the current user. Returns 0 if there is no current running task.
        /// </summary>
        /// <returns></returns>
        private int GetActiveTaskID()
        {
            return TimeTrackerDataProvider.Instance().GetActiveAufgabeID(this.id);
        }
        public Task GetActiveTask()
        {
            int aufgabeID = TimeTrackerDataProvider.Instance().GetActiveAufgabeID(this.id);
            if (aufgabeID == 0)
                return null;
            else
            {
                Task retaufgabe = new Task(TimeTrackerDataProvider.Instance().GetAufgabeByID(aufgabeID).Rows[0], this);
                return retaufgabe;
            }

        }
        /// <summary>
        /// Gets all tasks days of the user where he/she logged less time that required. These days then get returned in form of this list of critical-items-list
        /// </summary>
        /// <returns>List of the critical days</returns>
        public List<CritItem> GetCritical()
        {
            List<CritItem> retCrit = new List<CritItem>();
            DataTable loggedDays = TimeTrackerDataProvider.Instance().GetLoggedWithDateByUserID(this.id);
            foreach (DataRow row in loggedDays.Rows)
            {
                DateTime date = DateTime.ParseExact(row["datum"].ToString(), "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);

                if (User.UserDontBreaksCritTime(this, date))
                {
                    int time = Task.CalcTimeFromTaskList(this.GetTasksByStartEnd(date.Date, date.Date.AddDays(1)));
                    retCrit.Add(new CritItem(date, time, this));
                }
            }

            return retCrit;
        }

        /// <summary>
        /// Gets the last task corresponding to the user. Returns null if there are no tasks
        /// </summary>
        /// <returns>Returns the last task</returns>
        public Task GetLastTask()
        {
            DataTable lastTable = TimeTrackerDataProvider.Instance().GetLastAufgabe(this.id);
            if (lastTable != null)
            {
                Task last = new Task(lastTable.Rows[0], this);
                return last;
            }
            else
                return null;

        }

        /// <summary>
        /// Gets the username as a string
        /// </summary>
        /// <returns>The Username of the current User</returns>
        public override string ToString()
        {
            return name;
        }

        /// <summary>
        /// Gets the current Count of Users
        /// </summary>
        /// <returns>Usercount</returns>
        public static int GetUserCount()
        {
            return TimeTrackerDataProvider.Instance().GetUserAnzahl();
        }
        /// <summary>
        /// Checks if the specified User has more time logged than required
        /// </summary>
        /// <param name="user">User to chekc</param>
        /// <param name="date">Date when the user logged the time</param>
        /// <returns></returns>
        public static bool UserDontBreaksCritTime(User user, DateTime date)
        {
            List<Task> aufgaben = user.GetTasksByStartEnd(date.Date, date.Date.AddDays(1));
            int sum = Task.CalcTimeFromTaskList(aufgaben);

            return sum < Settings.GetSettings().MinTime;
        }


        /// <summary>
        /// Creates new User if there are no users
        /// </summary>
        public static void CheckStandardAdmin()
        {
            if (GetUserCount() == 0)
            {
                User user = new User("admin", "admin");
                user.CreateAdminInDataBaseGetID();
            }
        }

        /// <summary>
        /// Returns all users from  the database
        /// </summary>
        /// <returns>List of users</returns>
        public static List<User> GetAllUsersFromDataBase()
        {
            List<User> retList = new List<User>();
            foreach (DataRow row in TimeTrackerDataProvider.Instance().GetAllUsers().Rows)
            {
                retList.Add(new User(row));
            }
            return retList;
        }

        /// <summary>
        /// Gets a user object with this specific Id from the database. Returns null if there is no such user
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public static User GetUserByID(int userID)
        {
            DataTable userTable = TimeTrackerDataProvider.Instance().GetUserByID(userID);
            if (userTable.Rows.Count > 0)
                return new User(userTable.Rows[0]);
            else
                throw new Exception("No User With this ID found");
        }

    }
}
