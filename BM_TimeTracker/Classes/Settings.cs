using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BM_TimeTracker.Classes
{
    class Settings
    {
        static Settings _settings = null;

        int minTime;

        public int MinTime
        {
            get
            {
                minTime = TimeTrackerDataProvider.Instance().GetMindestZeit();
                return minTime;
            }
            set 
            {
                minTime = value;
                TimeTrackerDataProvider.Instance().SetMindestZeit(minTime);
            }
        }


        /// <summary>
        /// Get the global Settings-Object
        /// </summary>
        /// <returns>Return global Settings</returns>
        public static Settings GetSettings()
        {
            if (_settings == null)
                _settings = new Settings();
            return _settings;
        }
        /// <summary>
        /// Private constructor to initialize the Settings-Object
        /// </summary>
        private Settings()
        {
            minTime = TimeTrackerDataProvider.Instance().GetMindestZeit();
        }


    }
}
