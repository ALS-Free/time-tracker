using System;
using System.Collections.Generic;
using System.ComponentModel;

using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Security.Cryptography;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

using System.Threading;
using System.Globalization;
using System.Configuration;
using System.IO;

using BM_TimeTracker.Classes;

namespace BM_TimeTracker
{
    public partial class fLogin : Form
    {//Login Bildschirm

        //Constructor
        public fLogin()
        {
            try
            {
                InitializeComponent();
                SetLocalization();

                GetLastEnteredUsernameFromConfig();
                CheckUsers();
            }
            catch (Exception ex)
            {
                Util.ShowError(ex);
            }

        }

        /// <summary>
        /// Check if there are no users in the database. If that is true it creates the standard admin
        /// </summary>
        private void CheckUsers()
        {
            User.CheckStandardAdmin();
        }

        private void GetLastEnteredUsernameFromConfig()
        {//lade den letzten Usernamen aus der Settings-datei
            string username = Util.GetConfig("LastUsername");
            txtbUsername.Text = username;
        }
        private void SetLastEntererUsernameInConfig(string strText)
        {//speichere den zuletzt benutzten Usernamen in die SettingsDatei
            Util.SetConfig("LastUsername", strText);
        }

        private void ShowVerwaltung(User currentUser)
        {
            fTaskManagement verwaltung = new fTaskManagement();
            verwaltung.CurrentUser = currentUser;
            verwaltung.FillDataGrid();
            verwaltung.LoadUserLoggedInAs();
            verwaltung.Location = this.Location;
            verwaltung.Show();

            verwaltung.LoadCrit();

        }

        private void SetLocalization()
        {//set localization to the language in the thread
            lbPassword.Text = Ressources.strings.login_password;
            lbUsername.Text = Ressources.strings.login_username;
            lnkNeuUser.Text = Ressources.strings.login_newuser;
        }

        #region events

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                User currentUser = new User(txtbUsername.Text, txtbPassword.Text);
                if (currentUser.VerifyUser())
                {
                    SetLastEntererUsernameInConfig(txtbUsername.Text); //set last entererd Username in config
                    ShowVerwaltung(currentUser);
                    this.Hide();
                }
                else
                {
                    lblHinweis.Visible = true;
                    lblHinweis.Text = Ressources.strings.login_failed;
                    lblHinweis.ForeColor = Color.Red;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void lnkNewUser_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {//form for creating a new user
            fNewUser neuBenutzer = new fNewUser();
            neuBenutzer.Login = this;
            neuBenutzer.Location = this.Location;
            neuBenutzer.Show();
            this.Hide();
        }
        //close program
        void fLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                Util.Exit();
            }
            catch (Exception ex)
            {
                Util.ShowError(ex);
            }

        }

        #endregion
    }
}
