using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BM_TimeTracker.Classes
{
    public class Event
    {
        DateTime startdatum;
        DateTime enddatum;

        /// <summary>
        /// Creates an Event-Object from a DataRow
        /// </summary>
        /// <param name="row">DataRow from the database</param>
        public Event(DataRow row)
        {
            this.startdatum = Convert.ToDateTime(row["Startdatum"]);
            this.enddatum = row["enddatum"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(row["enddatum"]);
        }

        /// <summary>
        /// Gets the time in minutes from start to end of this Event
        /// </summary>
        /// <returns>Timespan in minutes</returns>
        public int GetTimeSpanInMinutes()
        {
            TimeSpan timespan = this.enddatum - this.startdatum;
            return (int)timespan.TotalMinutes;
        }

    }
}
