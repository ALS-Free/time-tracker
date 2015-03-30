using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace BM_TimeTracker.Classes
{
    public class Task
    {
        int id = -1;

        User user;
        string name;
        bool intern;
        int time;
        DateTime date;
        bool finished;


        /// <summary>
        /// Id this task holds in the database
        /// </summary>
        public int ID
        {
            get { return id; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        /// <summary>
        /// Task finished or not
        /// </summary>
        public bool Finished
        {
            get { return finished; }
            set { finished = value; }
        }
        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }
        public int Time
        {
            get { return time; }
            set { time = value; }
        }


        /// <summary>
        /// Returns the user this task belongs to
        /// </summary>
        public User User
        {
            get { return user; }
        }
        public bool Intern
        {
            get { return intern; }
            set { intern = value; }
        }

        /// <summary>
        /// Creates a Task from a DataRow
        /// </summary>
        /// <param name="row">DataRow from Database</param>
        /// <param name="user">User this task belongs to</param>
        public Task(DataRow row, User user)
        {
            this.id = Convert.ToInt32(row["AufgabeID"]);
            this.user = user;
            this.name = row["AufgabeName"].ToString();
            this.intern = Convert.ToBoolean(row["Intern"]);
            this.time = row["Zeit"] == DBNull.Value ? CalcTimeFromEvents() : Convert.ToInt32(row["Zeit"]); //if there is no time specified in the database, calculate it
            this.date = row["Datum"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(row["Datum"]); //if there is no Date for the end in the database, take today
            this.finished = Convert.ToBoolean(row["abgeschlossen"]);
        }
        public Task(User user, string name, bool intern)
        {
            this.user = user;
            this.name = name;
            this.intern = intern;
        }
        /// <summary>
        /// Gets the time from all events associated with this task. Then sums this time to the total time of this task
        /// </summary>
        /// <returns>Time logged for this task</returns>
        public int CalcTimeFromEvents()
        {
            List<Event> events = GetEvents();
            int time = 0;
            foreach (Event thisevent in events)
            {
                time += thisevent.GetTimeSpanInMinutes();
            }
            return time;
        }
        /// <summary>
        /// Get all Events associated with this task
        /// </summary>
        /// <returns></returns>
        private List<Event> GetEvents()
        {
            List<Event> retEvents = new List<Event>();
            foreach (DataRow row in TimeTrackerDataProvider.Instance().GetEventsByAufgabe(this.id).Rows)
            {
                retEvents.Add(new Event(row));
            }
            return retEvents;
        }
        /// <summary>
        /// Starts the Task
        /// </summary>
        public void Start()
        {
            if (id != -1)
                TimeTrackerDataProvider.Instance().InsertEventEnddatumNULL(this.id, DateTime.Now);
        }
        /// <summary>
        /// Stops the Task
        /// </summary>
        public void Stop()
        {
            if (id != -1)
                TimeTrackerDataProvider.Instance().UpdateEventWhereEnddatumNULLByAufgabeID(this.id);
        }
        /// <summary>
        /// Deletes the task from the database
        /// </summary>
        public void Delete()
        {
            if (id != -1)
                TimeTrackerDataProvider.Instance().UpdateAufgabeGeloescht(this.id);
        }

        /// <summary>
        /// Save this Task to the database. If it already exists, it gets updated. Otherwise it gets created
        /// </summary>
        public void SaveToDataBase()
        {
            if (this.id == -1)
            {
                DataTable aufgabeData = TimeTrackerDataProvider.Instance().InsertAufgabeGetData(user.ID);
                this.id = Convert.ToInt32(aufgabeData.Rows[0][0]);
                this.date = DateTime.Now;

                SaveToDataBase();
            }
            else
            {
                if (this.finished == true)
                    TimeTrackerDataProvider.Instance().UpdateAufgabe(this.id, this.name, this.intern, this.time, this.date, this.finished);
                else
                    TimeTrackerDataProvider.Instance().UpdateAufgabeZeitNULL(this.id, this.name, this.intern, this.date, this.finished);
            }

        }


        /// <summary>
        /// Gets the time for each task and sums it up 
        /// </summary>
        /// <param name="tasks">List of Tasks</param>
        /// <returns>Sum of time logged for these List of tasks</returns>
        public static int CalcTimeFromTaskList(List<Task> tasks)
        {
            int sum = 0;
            foreach (Task task in tasks)
            {
                sum += task.Time;
            }
            return sum;
        }

    }
}
