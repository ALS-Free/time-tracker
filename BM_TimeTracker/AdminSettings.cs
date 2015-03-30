using System;
using System.Collections.Generic;
using System.ComponentModel;

using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;

using BM_TimeTracker.Classes;

namespace BM_TimeTracker
{
    public partial class fAdminSettings : Form
    {
        #region attributes
        fAdmin _fAdmin;
        public fAdmin fAdmin
        {
            set { _fAdmin = value; }
        }
        #endregion

        //constructor
        public fAdminSettings()
        {
            try
            {
                InitializeComponent();
                SetLocalization();
                ShowMinTime();
                ResetNotificationLabels();
            }
            catch (Exception ex)
            {
                Util.ShowError(ex);
            }
        }

        private void ShowMinTime()
        {

            int mindestZeit = Settings.GetSettings().MinTime;
            txtbZeit.Text = mindestZeit.ToString();
        }

        private bool CheckInputs()
        {
            int time;
            if (!Int32.TryParse(txtbZeit.Text, out time))
            {
                lbInvalidTime.Visible = true;
                return false;
            }
            return true;
        }

        private void ResetNotificationLabels()
        {
            lbInvalidTime.Visible = false;
        }

        private void SetLocalization()
        {
            lbMindest.Text = Ressources.strings.adminSettings_minTime;
            btnSave.Text = Ressources.strings.adminSettings_save;
            lbInvalidTime.Text = Ressources.strings.adminSettings_invalidTime;
        }

        #region events
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                ResetNotificationLabels();
                if (CheckInputs())
                {
                    Settings.GetSettings().MinTime = Convert.ToInt32(txtbZeit.Text);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                Util.ShowError(ex);
            }
        }
        private void fAdminSettings_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                _fAdmin.Show();
                _fAdmin.LoadCritItemListToList();

            }
            catch (Exception ex)
            {
                Util.ShowError(ex);
            }
        }
        #endregion
     
    }
}
