using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
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
    public partial class fNewUser : Form
    {//Formular zur Erstellung von neuen Benutzern
        #region attributes
        fLogin _login;
        public fLogin Login
        {
            set { _login = value; }
        }
        #endregion

        //constructor
        public fNewUser()
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
            //lblHinweis
            lblHinweis.Visible = false;
            lblHinweis.ForeColor = Color.Red;
        }
        private bool CheckInputs()
        {
            if (txtbBenutzerName.Text.Length == 0)
            {
                lblHinweis.Visible = true;
                lblHinweis.Text = Ressources.strings.newuser_pleaseenterusername;
                return false;
            }

            if (txtbPasswort1.TextLength == 0 || txtbPasswort2.TextLength == 0)
            {
                lblHinweis.Visible = true;
                lblHinweis.Text = Ressources.strings.newuser_pleaseenterpassword;
                return false;
            }

            if (txtbPasswort1.Text != txtbPasswort2.Text)
            {
                lblHinweis.Visible = true;
                lblHinweis.Text = Ressources.strings.newuser_passwordmustmatch;
                return false;
            }
            return true;

        }

        //Localization
        private void SetLocalization()
        {
            lbUsername.Text = Ressources.strings.newuser_username;
            lbPasswort.Text = Ressources.strings.newuser_password;
            lbPasswort2.Text = Ressources.strings.newuser_reenterpassword;
            btnSpeichern.Text = Ressources.strings.newuser_save;
            this.Text = Ressources.strings.newuser_title;
        }

        #region events
        //Events
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckInputs())
                {
                    User user = new User(txtbBenutzerName.Text, txtbPasswort1.Text);
                    if (!user.ExistsInDataBase)
                    {
                        user.CreateUserInDataBaseGetID();
                        this.Close();
                    }
                    else
                    {
                        lblHinweis.Visible = true;
                        lblHinweis.Text = Ressources.strings.newuser_useralreadytaken;

                    }
                }
            }
            catch (Exception ex)
            {
                Util.ShowError(ex);
            }
        }
        private void NeuBenutzer_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                _login.Show();
            }
            catch (Exception ex)
            {
                Util.ShowError(ex);
            }
        }

        #endregion

    }


}
