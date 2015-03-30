using System;
using System.Collections.Generic;
using System.ComponentModel;

using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Data.SqlClient;
using System.Data;
using System.Configuration;

using BM_TimeTracker.Classes;

namespace BM_TimeTracker
{
    public partial class fBooking : Form
    {//form when finishing/editing a task
        #region attributes

        Task currentAufgabe;
        fTaskManagement _Verwaltung;
        bool _blAbschluss;

        public Task Aufgabe
        {
            set { this.currentAufgabe = value; }
        }
        public fTaskManagement Verwaltung
        {
            set { _Verwaltung = value; }
        }
        public bool BlAbschluss
        {
            set { _blAbschluss = value; }
        }

        #endregion

        //Constructor
        public fBooking()
        {
            try
            {
                InitializeComponent();
                SetLocalization();
                //lblHinweis
                lblHinweis.Visible = false;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void ShowTaskManagement()
        {
            _Verwaltung.Show();
            _Verwaltung.DtpDay = dtpDatum.Value;
            _Verwaltung.BringToFront();
            _Verwaltung.FillDataGrid();
        }

        public void LoadTask()
        {//load data of a specific task
            //taskname
            string strAufgabeName = currentAufgabe.Name;
            txtbAufgabeName.Text = strAufgabeName;

            //is it an internal task?
            bool blIntern = currentAufgabe.Intern;
            cbxIntern.Checked = blIntern;

            //if entry for minutes in the database is NULL intminutes will be calculated
            int intMinutes = !currentAufgabe.Finished ? currentAufgabe.CalcTimeFromEvents() : currentAufgabe.Time;
            txtbZeit.Text = intMinutes.ToString();

            //Choose today if the date is NULL
            DateTime dtDatum = currentAufgabe.Date;
            dtpDatum.Value = dtDatum;
        }
        public void LoadFinishedOrEdit()
        {
            //lade buchungseinzelheiten
            if (_blAbschluss)
            {
                btnBerechnen.Visible = true;
                btnBuchen.Text = Ressources.strings.bookit_booktime;
                txtbZeit.Enabled = true;
            }
            else
            {
                btnBuchen.Text = Ressources.strings.bookit_savetime;
                btnBerechnen.Visible = false;
                txtbZeit.Enabled = false;
            }
        }

        private int RoundIt(int intInput)
        {
            if (intInput != 0)
            {
                int intRest = 15 - (intInput % 15);

                if (intRest != 15)
                    intInput += intRest;
            }
            else
            {
                return 15;
            }
            return intInput;
        }

        private void ResetNotificationLabels()
        {
            //reset hinweis
            lblHinweis.Visible = false;
            lblHinweis.Text = "";
            lblHinweis.ForeColor = Color.Red;
        }

        private bool CheckInputs()
        {
            bool blCheck = true;

            string strAufgabeName = txtbAufgabeName.Text;
            if (strAufgabeName.Length == 0)
            {
                blCheck = false;

                lblHinweis.Visible = true;
                lblHinweis.Text = Ressources.strings.bookit_entertaskname;
            }

            int intZeit;
            if (Int32.TryParse(txtbZeit.Text, out intZeit) == false)
            {
                blCheck = false;

                lblHinweis.Visible = true;
                lblHinweis.Text += Ressources.strings.bookit_invalidtime;
            }
            else
            {
                if (intZeit < 0)
                {
                    blCheck = false;

                    lblHinweis.Visible = true;
                    lblHinweis.Text += Ressources.strings.bookit_invalidtime;
                }
            }
            return blCheck;
        }

        private void SetLocalization()
        {
            lbAufgabeName.Text = Ressources.strings.bookit_task;
            cbxIntern.Text = Ressources.strings.bookit_intern;
            lbZeit.Text = Ressources.strings.bookit_timeminutes;
            btnBerechnen.Text = Ressources.strings.bookit_calculatetime;
            btnBuchen.Text = Ressources.strings.bookit_booktime;
            txtbAufgabeName.Text = Ressources.strings.bookit_editing;
            this.Text = Ressources.strings.bookit_title;
        }

        #region events
        //buttons
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                ResetNotificationLabels();
                if (CheckInputs())
                {

                    if (_blAbschluss)
                    {
                        currentAufgabe.Stop();
                    }

                    currentAufgabe.Finished = _blAbschluss;
                    currentAufgabe.Time = Convert.ToInt32(txtbZeit.Text);
                    currentAufgabe.Intern = cbxIntern.Checked;
                    currentAufgabe.Name = txtbAufgabeName.Text;
                    currentAufgabe.Date = dtpDatum.Value;
                    currentAufgabe.SaveToDataBase();

                    Close();
                }
            }
            catch (Exception ex)
            {
                Util.ShowError(ex);
            }
        }
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                //round it up when task will be finished
                int intMinutes = RoundIt(currentAufgabe.CalcTimeFromEvents());
                txtbZeit.Text = intMinutes.ToString();
            }
            catch (Exception ex)
            {
                Util.ShowError(ex);
            }
        }
        //close program
        private void Booking_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                this.Hide();
                ShowTaskManagement();
            }
            catch (Exception ex)
            {
                Util.ShowError(ex);
            }
        }

        #endregion

    }
}
