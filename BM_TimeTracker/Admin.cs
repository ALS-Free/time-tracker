using System;
using System.Collections.Generic;
using System.ComponentModel;

using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Data;
using System.Data.SqlClient;

using System.IO;
using System.Configuration;
using Excel = Microsoft.Office.Interop.Excel;

using BM_TimeTracker.Classes;

namespace BM_TimeTracker
{
    public partial class fAdmin : Form
    {//mainforms for admin users
        #region attributes

        fTaskManagement _Verwaltung;
        fAdminChangeUser _UserVerwaltung;
        fAdminSettings _adminEinstellungen;

        public fTaskManagement Verwaltung
        {
            set { _Verwaltung = value; }
            get { return _Verwaltung; }
        }

        #endregion

        //contructor
        public fAdmin()
        {
            try
            {
                InitializeComponent();
                SetLocalization();
                LoadUsers();
                ResizeDataGrid();

            }
            catch (Exception ex)
            {
                Util.ShowError(ex);
            }
        }
        private void FillDataGrid()
        {

            if (cBoxUser.SelectedItem != null)
            {
                ClearDataGrid();
                User user = (User)cBoxUser.SelectedItem;

                List<Task> aufgaben = user.GetTasksByStartEnd(dtpStart.Value, dtpEnde.Value);
                foreach (Task aufgabe in aufgaben)
                {
                    AddTaskToDataGrid(aufgabe);
                }
                MarkActiveTaskInDataGrid();

            }
        }
        private void ClearDataGrid()
        {
            dtgV1.Rows.Clear();
            dtgV1.ClearSelection();
        }
        private void ResizeDataGrid()
        {
            int intWidth = dtgV1.Size.Width;
            //col widths
            dtgV1.Columns[1].Width = 50;
            dtgV1.Columns[2].Width = 120;
            dtgV1.Columns[3].Width = 120;
            dtgV1.Columns[0].Width = intWidth - (dtgV1.Columns[1].Width + dtgV1.Columns[2].Width + dtgV1.Columns[3].Width + 50);
        }
        private void AddTaskToDataGrid(Task aufgabe)
        {
            DataGridViewRow row = new DataGridViewRow();
            DataGridViewTextBoxCell cellName = new DataGridViewTextBoxCell();
            cellName.Value = aufgabe.Name;
            cellName.Tag = aufgabe;

            DataGridViewCheckBoxCell cellIntern = new DataGridViewCheckBoxCell();
            cellIntern.Value = aufgabe.Intern;

            DataGridViewTextBoxCell cellMinutes = new DataGridViewTextBoxCell();
            cellMinutes.Value = aufgabe.Time;

            DataGridViewTextBoxCell cellDate = new DataGridViewTextBoxCell();
            cellDate.Value = aufgabe.Date;
            cellDate.Style.Format = "dd.MM.yyyy";

            row.Cells.Add(cellName);
            row.Cells.Add(cellIntern);
            row.Cells.Add(cellMinutes);
            row.Cells.Add(cellDate);

            dtgV1.Rows.Add(row);
        }
        private void MarkActiveTaskInDataGrid()
        {
            User user = (User)cBoxUser.SelectedItem;
            Task active = user.GetActiveTask();
            if (active != null)
            {
                bool found = false;
                for (int i = 0; i < dtgV1.Rows.Count && !found; i++)
                {
                    Task aufgabe = (Task)dtgV1[0, i].Tag;
                    if (aufgabe == active)
                    {
                        found = true;
                        dtgV1[0, i].Style.BackColor = Util.GetGreen();
                    }
                }
            }
        }

        public void LoadUsers()
        {
            List<User> allUsers = User.GetAllUsersFromDataBase();
            foreach (User user in allUsers)
                cBoxUser.Items.Add(user);
            cBoxUser.SelectedIndex = 0;
        }

        public void LoadCritItemListToList()
        {
            ClearCritList();
            List<CritItem> allcrit = CritItem.GetAllFromDataBase();
            foreach (CritItem item in allcrit)
            {
                lbxKritisch.Items.Add(item);
            }
        }
        private void ClearCritList()
        {
            lbxKritisch.ClearSelected();
            lbxKritisch.Items.Clear();
        }

        private void SetLocalization()
        {
            btnVerwaltung.Text = Ressources.strings.admin_backtomanage;
            lbStart.Text = Ressources.strings.admin_start;
            lbEnde.Text = Ressources.strings.admin_end;
            btnLoadUserData.Text = Ressources.strings.admin_loaddata;

            dtgV1.Columns[0].HeaderText = Ressources.strings.admin_task;
            dtgV1.Columns[1].HeaderText = Ressources.strings.admin_intern;
            dtgV1.Columns[2].HeaderText = Ressources.strings.admin_timeinminutes;
            dtgV1.Columns[3].HeaderText = Ressources.strings.admin_date;

            btnUserVerwaltung.Text = Ressources.strings.admin_usermanage;
            btnSaveExcel.Text = Ressources.strings.admin_export;
            lblKritisch.Text = Ressources.strings.admin_criticaldays;
            btnEinstellungen.Text = Ressources.strings.admin_settings;

            this.Name = Ressources.strings.admin_title;
        }

        private void ShowAdminSettingsForm()
        {
            if (_adminEinstellungen != null)
                _adminEinstellungen.Close();

            _adminEinstellungen = new fAdminSettings();
            _adminEinstellungen.fAdmin = this;
            _adminEinstellungen.Show();
            _adminEinstellungen.BringToFront();
        }

        //save datagrid to excel
        private void ToExcel(DataGridView dGV, string filename)
        {
            object missingValue = System.Reflection.Missing.Value;

            Excel.Application app = new Excel.Application();
            Excel.Workbook workbook = app.Workbooks.Add(missingValue);
            Excel.Worksheet sheet = (Excel.Worksheet)workbook.Worksheets.get_Item(1);

            for (int i = 0; i < dGV.Columns.Count; i++)
            {
                string header = dGV.Columns[i].HeaderText;
                sheet.Cells[1, i + 1] = header;
            }

            for (int i = 0; i < dGV.Rows.Count; i++)
            {
                for (int j = 0; j < dGV.Columns.Count; j++)
                {
                    string strData = dGV[j, i].Value.ToString();
                    sheet.Cells[i + 2, j + 1] = strData;
                }
            }

            workbook.SaveAs(filename, Excel.XlFileFormat.xlWorkbookNormal,
                missingValue, missingValue, missingValue, missingValue, Excel.XlSaveAsAccessMode.xlExclusive,
                missingValue, missingValue, missingValue, missingValue, missingValue);
            workbook.Close(true, missingValue, missingValue);
            app.Quit();

            ReleaseCOMObject(sheet);
            ReleaseCOMObject(workbook);
            ReleaseCOMObject(app);

            //System.Diagnostics.Process.Start("explorer.exe", filename);
        }
        private void ReleaseCOMObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                Util.ShowError(ex);
            }
            finally
            {
                GC.Collect();
            }
        }

        #region events
        //buttons
        private void btnLoadUserData_Click(object sender, EventArgs e)
        {
            try
            {
                FillDataGrid();
            }
            catch (Exception ex)
            {
                Util.ShowError(ex);
            }
        }
        private void btnSaveExcel_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Excel Documents (*.xls)|*.xls";
                sfd.FileName = cBoxUser.SelectedItem.ToString() + ".xls";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    ToExcel(dtgV1, sfd.FileName);
                }
            }
            catch (Exception ex)
            {
                Util.ShowError(ex);
            }

        }
        private void btnAdminChangeUser_Click(object sender, EventArgs e)
        {
            try
            {
                if (_UserVerwaltung != null)
                    _UserVerwaltung.Close();

                _UserVerwaltung = new fAdminChangeUser();
                _UserVerwaltung.Admin = this;
                _UserVerwaltung.Show();
                _UserVerwaltung.BringToFront();
            }
            catch (Exception ex)
            {
                Util.ShowError(ex);
            }
        }
        private void btnTaskManagement_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                _Verwaltung.Show();
                _Verwaltung.BringToFront();
            }
            catch (Exception ex)
            {
                Util.ShowError(ex);
            }

        }
        private void lbxCrit_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                int intIndex = lbxKritisch.IndexFromPoint(e.Location);

                if (intIndex != -1)
                {
                    CritItem k1 = (CritItem)lbxKritisch.Items[intIndex];

                    DateTime dtStart = new DateTime(k1.Date.Year, k1.Date.Month, k1.Date.Day, 0, 0, 0);
                    DateTime dtEnde = new DateTime(k1.Date.Year, k1.Date.Month, k1.Date.Day, 23, 59, 55);

                    dtpStart.Value = dtStart;
                    dtpEnde.Value = dtEnde;

                    int intCounter = 0;
                    bool blHit = false;

                    while (intCounter < cBoxUser.Items.Count && blHit == false)
                    {
                        User us = (User)cBoxUser.Items[intCounter];

                        if (us.ID == k1.UserID)
                        {
                            blHit = true;
                            cBoxUser.SelectedItem = us;
                        }

                        intCounter++;
                    }

                    FillDataGrid();
                }
            }
            catch (Exception ex)
            {
                Util.ShowError(ex);
            }
        }
        //global Settings for all Users
        void btnSettings_Click(object sender, EventArgs e)
        {
            ShowAdminSettingsForm();
        }
        //resizing
        private void Admin_Resize(object sender, EventArgs e)
        {
            ResizeDataGrid();
        }
        //close program
        void Admin_FormClosing(object sender, FormClosingEventArgs e)
        {
            Util.Exit();
        }
        #endregion



    }
}
