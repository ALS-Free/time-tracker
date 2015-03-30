using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Configuration;

using BM_TimeTracker.Classes;

namespace BM_TimeTracker
{
    public partial class fAdminChangeUser : Form
    {//der Admin kann hier die Daten eines Users übeschreiben (z.B. passwoörter zurücksetzen usw.)
        #region attributes
        fAdmin _admin;

        public fAdmin Admin
        {
            set { _admin = value; }
        }
        #endregion attributes

        //constructor
        public fAdminChangeUser()
        {
            try
            {
                InitializeComponent();
                SetLocalization();
                ResetNotificationLabels();
                LoadUser();
            }
            catch (Exception ex)
            {
                Util.ShowError(ex);
            }
        }

        private void ClearUserDropDown()
        {
            cboxUser.Items.Clear();
        }
        private void AddNewUserDropDownItem()
        {
            User usgen = new User(0, Ressources.strings.usermanage_newuser);
            cboxUser.Items.Add(usgen);
            cboxUser.SelectedItem = usgen;
        }
        private void AddUserListToDropDown(int selectedUserId)
        {
            List<User> allUsers = User.GetAllUsersFromDataBase();
            foreach (User user in allUsers)
            {
                cboxUser.Items.Add(user);
                if (user.ID == selectedUserId)
                {
                    cboxUser.SelectedItem = user;
                }
            }
        }

        private bool CheckInputs()
        {
            ResetNotificationLabels();

            bool check = true;
            string strUsername = txtbUsername.Text;
            if (strUsername.Length == 0)
            {
                check = false;
                SetErrorLabel(Ressources.strings.usermanage_usernametooshort, false);
            }
            else if (strUsername == "admin" && cbxAdmin.Checked == false)
            {
                check = false;
                SetErrorLabel(Ressources.strings.usermanage_cannotOverrideAdmin, true);
            }

            string strPassword = txtbpassword.Text;
            if (strPassword.Length == 0 && check)
            {
                check = false;
                SetErrorLabel(Ressources.strings.usermanage_passwordtooshort, true);
            }

            return check;
        }
        private void SetErrorLabel(string message, bool appendMessage)
        {
            lblHinweis.Visible = true;
            lblHinweis.ForeColor = Color.Red;

            if (appendMessage)
                lblHinweis.Text += message;
            else
                lblHinweis.Text = message;
        }


        private bool UserToCreate(User user)
        {
            return user.ID == 0;
        }
        private User GetCurrentUser()
        {
            return (User)cboxUser.SelectedItem;
        }
        private void LoadUser(int userID = 0)
        {
            ClearUserDropDown();
            AddNewUserDropDownItem();
            AddUserListToDropDown(userID);
        }
        private void CreateNewUser(string username, string password)
        {
            User newUser = new User(username, password);

            if (newUser.ExistsInDataBase)
            {
                lblHinweis.ForeColor = Color.Red;
                lblHinweis.Text = Ressources.strings.usermanage_useralreadyexists;
            }
            else
            {
                if (cbxAdmin.Checked)
                    newUser.CreateAdminInDataBaseGetID();
                else
                    newUser.CreateUserInDataBaseGetID();

                lblHinweis.ForeColor = Color.Black;
                lblHinweis.Text = Ressources.strings.usermanage_savesuccess;

                LoadUser(newUser.ID);
            }
        }
        private void OverwriteUser(User user, string newPassword)
        {
            user.UpdateAdminPasswordInDataBase(newPassword, cbxAdmin.Checked);

            txtbpassword.Text = "";

            lblHinweis.Visible = true;
            lblHinweis.ForeColor = Color.Black;
            lblHinweis.Text = Ressources.strings.usermanage_savesuccess;
        }

        private bool IsDeletingSelf(User userToDelete)
        {
            return userToDelete.ID == _admin.Verwaltung.CurrentUser.ID;
        }
        private bool IsLastUser()
        {
            return cboxUser.Items.Count == 2;
        }

        private void ShowAdminForm()
        {
            _admin.Show();
            _admin.BringToFront();
            _admin.LoadUsers();
        }

        private void ResetForm()
        {
            txtbUsername.Text = "";
            txtbpassword.Text = "";
            txtbUsername.Enabled = true;
            cboxUser.SelectedIndex = 0;
        }
        private void ResetNotificationLabels()
        {
            lblHinweis.Visible = false;
            lblHinweis.Text = "";
        }

        private void SetLocalization()
        {
            lbUsername.Text = Ressources.strings.usermanage_username;
            lbPassword.Text = Ressources.strings.usermanage_password;
            btnSpeichern.Text = Ressources.strings.usermanage_save;
            btnDelete.Text = Ressources.strings.usermanage_delete;
            this.Text = Ressources.strings.usermanage_title;
            cboxUser.Text = Ressources.strings.usermanage_adminCheckBox;

        }

        #region events

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                //get user
                User curUser = GetCurrentUser();
                if (curUser.ID != 0)
                {
                    DialogResult dResult = MessageBox.Show(Ressources.strings.usermanage_doyouwanttodeleteuser, Ressources.strings.usermanage_confirmdelete, MessageBoxButtons.YesNo);
                    if (dResult == DialogResult.Yes)
                    {
                        if (!IsLastUser())
                        {
                            if (!IsDeletingSelf(curUser))
                            {
                                curUser.DeleteInDataBase();
                                LoadUser();
                            }
                            else
                            {
                                SetErrorLabel(Ressources.strings.usermanage_cannotDeleteSelf, false);
                            }
                        }
                        else
                        {
                            SetErrorLabel(Ressources.strings.usermanage_cannotDeleteLastUser, false);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Util.ShowError(ex);
            }

        }
        //Button
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                User selectedUser = GetCurrentUser();

                if (CheckInputs())
                {
                    if (UserToCreate(selectedUser))
                    {
                        string username = txtbUsername.Text;
                        string password = txtbpassword.Text;

                        CreateNewUser(username, password);
                    }
                    else
                    {
                        OverwriteUser(selectedUser, txtbpassword.Text);
                    }
                }
            }
            catch (Exception ex)
            {
                Util.ShowError(ex);
            }
        }
        //checkbox(filter)select/unselect
        private void cboxUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                User currentUser = GetCurrentUser();
                if (currentUser.ID == 0)
                {
                    txtbUsername.Enabled = true;
                    txtbUsername.Text = "";
                    btnDelete.Visible = false;
                    cbxAdmin.Checked = false;
                }
                else
                {
                    txtbUsername.Enabled = false;
                    txtbUsername.Text = currentUser.Name;
                    btnDelete.Visible = true;
                    cbxAdmin.Checked = currentUser.Admin;
                }
            }
            catch (Exception ex)
            {
                Util.ShowError(ex);
            }
        }
        //Close the program
        void AdminChangeUser_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                ShowAdminForm();
                this.Hide();
            }
            catch (Exception ex)
            {
                Util.ShowError(ex);
            }
        }
        #endregion

   



    }
}
