using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Threading;

namespace BM_TimeTracker.Classes
{
    class Util
    {
        public static void ShowError(Exception ex)
        {
            System.Windows.Forms.MessageBox.Show(ex.Message);
        }

        /// <summary>
        /// Change a value in the settings file. Than reload the file to refresh the settings
        /// </summary>
        /// <param name="key">Name of the Setting you want to change</param>
        /// <param name="value">New Valeu for the Setting</param>
        public static void SetConfig(string key, string value)
        {
            Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            configuration.AppSettings.Settings[key].Value = value;
            configuration.Save();

            ConfigurationManager.RefreshSection("appSettings");
        }

        /// <summary>
        /// Get Value from the settings file with the specified key. Returns empty string if there is no such setting
        /// </summary>
        /// <param name="key">Name of the setting you want to retrieve</param>
        /// <returns>Value of the setting</returns>
        public static string GetConfig(string key)
        {
            var confValue = ConfigurationManager.AppSettings[key];
            if (confValue != null)
                return string.Empty;
            else
                return confValue.ToString();

        }

        public static string GetConnectionString()
        {
            string connection = ConfigurationManager.ConnectionStrings["SQLConnection"].ConnectionString;
            return connection.ToString();
        }

        public static void Exit()
        {
            System.Windows.Forms.Application.Exit();
        }

        public static Color GetGreen()
        {
            return Color.FromArgb(198, 241, 198);
        }
        public static Color GetRed()
        {
            return Color.FromArgb(245, 192, 192);
        }
    }
}
