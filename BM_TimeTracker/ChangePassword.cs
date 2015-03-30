using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BM_TimeTracker.Classes;

namespace BM_TimeTracker
{
    public partial class fChangePassword : Form
    {//Der User kann hier sein eigenes Passwort ändern
        #region attributes
        fTaskManagement _verwaltung;
        public fTaskManagement Verwaltung
        {
            set { _verwaltung = value; }
        }
        #endregion

        //Constructor
        public fChangePassword()
        {
            try
            {
                InitializeComponent();
                SetLocalization();
                ResetNotificationLabels();
            }
            catch (Exception ex)
            {
                Util.ShowError(ex);
            }
        }

        private void ResetNotificationLabels()
        {
            lblHinweis.Text = "";
            lblHinweis.Visible = false;
            lblHinweis.ForeColor = Color.Red;
        }

        private bool CheckInputs()
        {
            if (txtbOldPasswort.TextLength == 0 || txtbPasswort.TextLength == 0 || txtbPasswort2.TextLength == 0)
            {
                lblHinweis.Visible = true;
                lblHinweis.Text = Ressources.strings.changeuser_invalidvalue;
                return false;
            }

            if (txtbPasswort.Text != txtbPasswort2.Text)
            {
                lblHinweis.Visible = true;
                lblHinweis.Text = Ressources.strings.changeuser_passwordmustmatch;
                return false;
            }
            return true;
        }

        private void SetLocalization()
        {
            lblAltesPasswort.Text = Ressources.strings.changeuser_oldpassword;
            lblPasswort.Text = Ressources.strings.changeuser_newpassword;
            lblPasswort2.Text = Ressources.strings.changeuser_reenternewpassword;
            btnSpeichern.Text = Ressources.strings.changeuser_save;
            this.Text = Ressources.strings.changeuser_title;
        }


        #region events
        private void fChangePassword_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                this.Hide();
                _verwaltung.Show();
                _verwaltung.BringToFront();
            }
            catch (Exception ex)
            {
                Util.ShowError(ex);
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckInputs())
                {
                    User currentUser = _verwaltung.CurrentUser;
                    currentUser.UpdatePasswordInDataBase(txtbPasswort.Text);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                Util.ShowError(ex);
            }
        }

        #endregion
    }
}
