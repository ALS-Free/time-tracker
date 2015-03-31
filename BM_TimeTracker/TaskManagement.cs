using System;
using System.Collections.Generic;
using System.ComponentModel;

using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Timers;
using System.Data;
using System.Data.SqlClient;

using BM_TimeTracker.Classes;

namespace BM_TimeTracker
{


    public partial class fTaskManagement : Form
    {//hauptformular der aufgabenverwaltung
        #region attributes

        fBooking _Buchung;
        fChangePassword _Userdaten;
        fLogin _login;

        private User currentUser;
        public User CurrentUser
        {
            get { return currentUser; }
            set { currentUser = value; }
        }
        public DateTime DtpDay
        {
            set { dtpDay.Value = value; }
        }
        #endregion attribute

        //constructor
        public fTaskManagement()
        {
            try
            {
                InitializeComponent();
                SetLocalization();

                //Start the timer
                _timer.Start();

                ResizeDataGrid();

                //handler
                this.FormClosing += TaskManagement_FormClosing;
                dtgV1.CellContentClick += new DataGridViewCellEventHandler(dtgV1_CellContentClick);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void ClearBackgrounds()
        {
            for (int i = 0; i < dtgV1.Rows.Count; i++)
            {
                dtgV1[0, i].Style.BackColor = Color.White;
            }

            for (int i = 0; i < aufgabeStartenToolStripMenuItem.DropDownItems.Count; i++)
            {
                aufgabeStartenToolStripMenuItem.DropDownItems[i].BackColor = Color.White;
            }

            for (int i = 0; i < aufgabeBuchenToolStripMenuItem.DropDownItems.Count; i++)
            {
                aufgabeBuchenToolStripMenuItem.DropDownItems[i].BackColor = Color.White;
            }
        }

        public void MarkActive()
        {
            Task active = currentUser.GetActiveTask();

            if (active != null)
            {
                //In from
                bool found = false;
                for (int i = 0; i < dtgV1.Rows.Count && !found; i++)
                {
                    Task selected = GetTaskFromRow(dtgV1.Rows[i]);
                    if (selected.ID == active.ID)
                    {
                        found = true;
                        dtgV1[0, i].Style.BackColor = Util.GetGreen();
                        dtgV1[4, i].Value = Ressources.strings.manange_pauseTaskButton;
                    }
                }

                //In Tray
                found = false;
                for (int i = 0; i < aufgabeStartenToolStripMenuItem.DropDownItems.Count && !found; i++)
                {
                    if (aufgabeStartenToolStripMenuItem.DropDownItems[i].Tag != null)
                    {
                        Task selected = (Task)aufgabeStartenToolStripMenuItem.DropDownItems[i].Tag;
                        if (selected.ID == active.ID)
                        {
                            found = true;
                            aufgabeStartenToolStripMenuItem.DropDownItems[i].BackColor = Util.GetGreen();
                            aufgabeBuchenToolStripMenuItem.DropDownItems[i - 1].BackColor = Util.GetGreen();
                        }
                    }
                }
            }
        }
        public void MarkFinished()
        {
            for (int i = 0; i < dtgV1.Rows.Count; i++)
            {
                Task aufgabe = (Task)dtgV1[0, i].Tag;
                if (aufgabe.Finished)
                    dtgV1[0, i].Style.BackColor = Util.GetRed();
            }
        }
        public void MarkTasks()
        {
            ClearBackgrounds();
            MarkActive();
            MarkFinished();
        }

        public void ResetNotifications()
        {//die hinweismeldungen werden ausgeschaltet
            lblHinweis.Visible = false;
        }

        private void ShowAdminForm()
        {
            fAdmin a1 = new fAdmin();
            a1.Verwaltung = this;
            a1.Show();
            a1.BringToFront();
            a1.LoadCritItemListToList();

        }
        private void ShowUserDatenForm()
        {
            if (_Userdaten != null)
            {
                _Userdaten.Close();
            }

            _Userdaten = new fChangePassword();
            _Userdaten.Verwaltung = this;
            _Userdaten.Show();
            _Userdaten.BringToFront();
        }

        private void ShowTaskAlreadyFinishedError()
        {
            lblHinweis.Visible = true;
            lblHinweis.Text = Ressources.strings.manage_alreadyfinished;
            lblHinweis.ForeColor = Color.Red;
        }

        public void LoadUserLoggedInAs()
        {
            lbUsername.Text = Ressources.strings.manage_username + "\n" + CurrentUser.Name;
            btnAdmin.Visible = currentUser.Admin;
        }

        //jump to critiTimestamp
        public void LoadCrit()
        {
            ClearCrit();
            List<CritItem> items = currentUser.GetCritical();
            foreach (CritItem item in items)
            {
                lbxKritisch.Items.Add(item);
            }
        }
        public void ClearCrit()
        {
            lbxKritisch.ClearSelected();
            lbxKritisch.Items.Clear();
        }

        public void FillDataGrid()
        {
            ClearDataGrid();

            DateTime start = dtpDay.Value.Date;
            DateTime ende = start.AddDays(1);

            List<Task> aufgaben = (cbxAktive.Checked) ? currentUser.GetTasksByStartEndActive(start, ende) : currentUser.GetTasksByStartEnd(start, ende);
            foreach (Task aufgabe in aufgaben)
            {
                AddTaskToDataGrid(aufgabe);
            }

            MarkTasks();
            LoadCrit();
            LoadTray();

            dtgV1.ClearSelection();
        }
        private void ClearDataGrid()
        {
            dtgV1.Rows.Clear();
            dtgV1.ClearSelection();
        }
        private void UnselectDatagrid()
        {
            dtgV1.ClearSelection();
        }
        //resize datagrid
        private void ResizeDataGrid()
        {//die Spalte in der der aufgabenname steht wird auf die restbreite nach abzeug der anderen Spalten, gestreckt
            int intWidth = dtgV1.Size.Width;

            dtgV1.Columns[1].Width = 50;
            dtgV1.Columns[2].Width = 75;
            dtgV1.Columns[3].Width = 100;
            dtgV1.Columns[4].Width = 100;
            dtgV1.Columns[5].Width = 100;
            dtgV1.Columns[6].Width = 100;

            dtgV1.Columns[0].Width = intWidth - (dtgV1.Columns[1].Width +
                 dtgV1.Columns[2].Width + dtgV1.Columns[3].Width + dtgV1.Columns[4].Width + dtgV1.Columns[5].Width + dtgV1.Columns[6].Width + 50);

        }

        //tray
        private void LoadTray()
        {//lade die items des trays

            List<Task> aufgabenAktiv = currentUser.GetTasksByStartEndActive(DateTime.Now.Date, DateTime.Now.AddDays(1));

            ClearTray();
            AddTaskCreateToTray();
            foreach (Task aufgabe in aufgabenAktiv)
            {
                AddTaskToTray(aufgabe, aufgabeStartenToolStripMenuItem, ts_TaskStart_Click);
                AddTaskToTray(aufgabe, aufgabeBuchenToolStripMenuItem, ts_TaskBooking_Click);
            }
            MarkTasks();
            LoadClock();
        }
        private void AddTaskCreateToTray()
        {
            ToolStripMenuItem placeholder = new ToolStripMenuItem();
            placeholder.Text = Ressources.strings.tray_newtask;
            placeholder.Click += ts_TaskCreate_Click;
            this.aufgabeStartenToolStripMenuItem.DropDownItems.Add(placeholder);
        }
        private void AddTaskToTray(Task aufgabe, ToolStripMenuItem parent, EventHandler clickEvent)
        {
            ToolStripMenuItem item = new ToolStripMenuItem();
            item.Tag = aufgabe;
            item.Text = aufgabe.Name;
            item.Click += clickEvent;
            item.AutoToolTip = true;
            item.ToolTipText = "Minuten: " + aufgabe.Time.ToString();
            parent.DropDownItems.Add(item);

        }
        private void ClearTray()
        {
            this.aufgabeStartenToolStripMenuItem.DropDownItems.Clear();
            this.aufgabeBuchenToolStripMenuItem.DropDownItems.Clear();
        }
        //load clock of the notify icon
        private void LoadClock()
        {
            if (currentUser.GetActiveTask() == null)
                _notIco.Icon = Properties.Resources.Uhrrot;
            else
                _notIco.Icon = Properties.Resources.Uhrblau;
        }

        private void AddTaskToDataGrid(Task aufgabe)
        {
            DataGridViewRow row = new DataGridViewRow();

            DataGridViewCell name = new DataGridViewTextBoxCell();
            name.Value = aufgabe.Name;
            name.Tag = aufgabe;

            DataGridViewCell intern = new DataGridViewCheckBoxCell();
            intern.Value = aufgabe.Intern;

            DataGridViewCell zeit = new DataGridViewTextBoxCell();
            zeit.Value = aufgabe.Time;

            DataGridViewCell datum = new DataGridViewTextBoxCell();
            datum.Value = aufgabe.Date;
            datum.Style.Format = "dd.MM.yyyy";


            DataGridViewCell startPause;
            if (!aufgabe.Finished)
            {
                startPause = new DataGridViewButtonCell();
                startPause.Value = Ressources.strings.manage_startTaskButton;
            }
            else
            {
                startPause = new DataGridViewTextBoxCell();
            }

            DataGridViewCell edit = new DataGridViewButtonCell();
            edit.Value = Ressources.strings.manage_edit;

            DataGridViewCell delete = new DataGridViewButtonCell();
            delete.Value = Ressources.strings.manage_delete;

            row.Cells.Add(name);
            row.Cells.Add(intern);
            row.Cells.Add(zeit);
            row.Cells.Add(datum);
            row.Cells.Add(startPause);
            row.Cells.Add(edit);
            row.Cells.Add(delete);

            dtgV1.Rows.Add(row);
        }
        private Task GetTaskFromRow(DataGridViewRow row)
        {
            Task retAufgabe = row.Cells[0].Tag as Task;
            return retAufgabe;
        }

        private void ShowLoginForm()
        {
            _login = new fLogin();
            _login.Show();
            _login.BringToFront();
        }
        private void ShowBuchungForm(bool abschluss, Task aufgabe)
        {
            if (_Buchung != null)
            {
                _Buchung.Close();
            }

            _Buchung = new fBooking();
            _Buchung.Aufgabe = aufgabe;
            _Buchung.BlAbschluss = abschluss;
            _Buchung.Verwaltung = this;

            _Buchung.Show();
            _Buchung.BringToFront();

            _Buchung.LoadTask();
            _Buchung.LoadFinishedOrEdit();
        }

        private void SetLocalization()
        {//localisation wird mit der Ressources.string.datei geladen

            btnLogout.Text = Ressources.strings.manage_logout;
            btnStart.Text = Ressources.strings.manage_start;
            btnPause.Text = Ressources.strings.manage_pause;
            btnStop.Text = Ressources.strings.manage_bookit;
            btnUser.Text = Ressources.strings.manage_changepassword;
            btnAdmin.Text = Ressources.strings.manage_admin;

            dtgV1.Columns[0].HeaderText = Ressources.strings.manage_task;
            dtgV1.Columns[1].HeaderText = Ressources.strings.manage_intern;
            dtgV1.Columns[2].HeaderText = Ressources.strings.manage_timeminutes;
            dtgV1.Columns[3].HeaderText = Ressources.strings.manage_date;
            dtgV1.Columns[4].HeaderText = Ressources.strings.manage_startTask;
            dtgV1.Columns[5].HeaderText = Ressources.strings.manage_edit;
            dtgV1.Columns[6].HeaderText = Ressources.strings.manage_delete;

            cbxAktive.Text = Ressources.strings.manage_onlyactive;
            lbKritisch.Text = Ressources.strings.manage_criticaldays;
            this.Text = Ressources.strings.manage_title;


            aufgabePausierenToolStripMenuItem.Text = Ressources.strings.tray_pause;
            aufgabeBuchenToolStripMenuItem.Text = Ressources.strings.tray_bookit;
            aufgabeStartenToolStripMenuItem.Text = Ressources.strings.tray_start;
            aufgabebeendenToolStripMenuItem.Text = Ressources.strings.tray_exit;

        }

        #region events
        //logout
        private void btnLogout_Click(object sender, EventArgs e)
        {//der aktuell eingeloggte user wird ausgeloggt und gelangt zum login-bildschirm
            try
            {
                this.Hide();
                ShowLoginForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        //admin
        private void btnAdmin_Click(object sender, EventArgs e)
        {//ruft das fenster für die aufgaben des TimeTracker admins auf
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
        //change password
        private void btnUser_Click(object sender, EventArgs e)
        {//ruft das fenster zum passwort ändern auf
            try
            {
                ShowUserDatenForm();
            }
            catch (Exception ex)
            {
                Util.ShowError(ex);
            }
        }
        //start/stop/pause
        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                ResetNotifications();
                if (dtgV1.SelectedCells.Count > 0)
                {
                    Task selected = (Task)dtgV1[0, dtgV1.SelectedCells[0].RowIndex].Tag;
                    if (selected.Finished)
                    {
                        ShowTaskAlreadyFinishedError();
                    }
                    else
                    {
                        Task runnig = currentUser.GetActiveTask();
                        if (runnig != null)
                            runnig.Stop();

                        selected.Start();
                    }
                }
                else
                {
                    Task runnig = currentUser.GetActiveTask();
                    if (runnig != null)
                        runnig.Stop();

                    Task aufgabe = new Task(currentUser, Ressources.strings.manage_inediting, true);
                    aufgabe.Date = dtpDay.Value;
                    aufgabe.SaveToDataBase();
                    aufgabe.Start();
                }

                ClearDataGrid();
                FillDataGrid();

            }
            catch (Exception ex)
            {
                Util.ShowError(ex);
            }
        }
        private void btnStop_Click(object sender, EventArgs e)
        {
            try
            {
                ResetNotifications();

                if (dtgV1.SelectedCells.Count > 0)
                {//das buchungsfenster wird mit der selecteten aufgabenID aufgerufen
                    Task selected = (Task)dtgV1[0, dtgV1.SelectedCells[0].RowIndex].Tag;
                    ShowBuchungForm(true, selected);
                }
            }
            catch (Exception ex)
            {
                Util.ShowError(ex);
            }
        }
        private void btnPause_Click(object sender, EventArgs e)
        {
            try
            {
                ResetNotifications();
                currentUser.StopCurrentTask();
                ClearDataGrid();
                FillDataGrid();

            }
            catch (Exception ex)
            {
                Util.ShowError(ex);
            }

        }
        //tray buttons with task
        private void ts_TaskCreate_Click(object sender, EventArgs e)
        {//click auf die schaltfläche "Neue Aufgabe" im tray für aufgabe starten
            //pausiert die aktuell laufende aufgabe
            currentUser.StopCurrentTask();

            Task newAufgabe = new Task(currentUser, Ressources.strings.manage_inediting, true);
            newAufgabe.SaveToDataBase();
            newAufgabe.Start();

            ShowBuchungForm(false, newAufgabe);

        }
        private void ts_TaskStart_Click(object sender, EventArgs e)
        {//click auf eine item innerhalb von aufgabe starten das nicht "Neue Aufgabe" ist
            ToolStripMenuItem tsSender = (ToolStripMenuItem)sender;

            //pausiert die aktuell laufende aufgabe
            currentUser.StopCurrentTask();

            Task selected = (Task)tsSender.Tag;
            selected.Start();

            FillDataGrid();
        }
        private void ts_TaskBooking_Click(object sender, EventArgs e)
        {
            //für die angeclickte aufgabe wird das buchungsfenster aufgerufen
            ToolStripMenuItem ts1 = (ToolStripMenuItem)sender;
            Task aufgabe = (Task)ts1.Tag;
            ShowBuchungForm(true, aufgabe);
        }

        //tray general buttons
        private void taskPauseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentUser.StopCurrentTask();
        }

        //Trayicon
        private void notifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {//aufrufen des kontextmenüs wenn mit der rechten maustaste auf das trayicon geclick wird
                _ctxtMenStrp.Show();
            }
            else if (e.Button == MouseButtons.Left)
            {//aufrufen des hauptfenster wenn mit der linken maustaste auf das trayicon geclickt wird
                _notIco.Visible = false;

                this.ShowInTaskbar = true;
                this.WindowState = FormWindowState.Normal;
            }
        }

        //keyboard shortcuts
        private void fVerwaltung_KeyDown(object sender, KeyEventArgs e)
        {//tasktenkmpinationen
            if (e.Control && e.KeyCode == Keys.S)
            {
                if (dtgV1.SelectedCells.Count == 0)
                {//keine zellen im datagrid wurden ausgewählt
                    //Start last STRG+S
                    Task active = currentUser.GetActiveTask();
                    if (active == null)
                    {
                        Task lastAufgabe = currentUser.GetLastTask();
                        if (lastAufgabe != null)
                        {
                            lastAufgabe.Start();
                            MarkTasks();
                        }
                    }
                }
                else
                {//start der ausgewählten aufgabe
                    btnStart_Click(btnStart, new EventArgs());
                }
            }
            else if (e.Control && e.KeyCode == Keys.P)
            {//STRG+P
                Task active = currentUser.GetActiveTask();
                if (active != null)
                {
                    active.Stop();
                    MarkTasks();
                }
            }
            else if (e.Control && e.KeyCode == Keys.B)
            {//stoppen buchung
                if (dtgV1.SelectedCells.Count > 0)
                {//die selecte aufgabe wird gebucht
                    btnStop_Click(btnStop, new EventArgs());
                }
            }
            else if (e.Control && e.KeyCode == Keys.T)
            {//erstellt eine bereits abgeschlossene aufgabe die nur noch bearbeitet werden muss
                Task finAufgabe = new Task(currentUser, Ressources.strings.manage_inediting, true);
                finAufgabe.Finished = true;
                finAufgabe.SaveToDataBase();

                //Aufrufen des Buchungsformulars für die abgeschlossene aufgabe
                ShowBuchungForm(true, finAufgabe);
            }
        }

        //unselect datagrid on index clicked = -1/on pnl back click
        private void dtgV1_MouseDown(object sender, MouseEventArgs e)
        {//unselect des datagrids wenn man keinen gültigen index angeclickt hat
            var hti = dtgV1.HitTest(e.X, e.Y);
            if (hti.ColumnIndex == -1 && hti.RowIndex == -1)
                dtgV1.ClearSelection();
        }
        private void pnlBack_Click(object sender, EventArgs e)
        {//unselect des datagrid wenn auf den hintergrund geclickt wird
            UnselectDatagrid();
        }
        private void Verwaltung_Click(object sender, EventArgs e)
        {//unselect des datagrid wenn auf den hintergrund geclickt wird
            UnselectDatagrid();
        }

        //jump to selected day
        private void dtpDay_ValueChanged(object sender, EventArgs e)
        {//neuladen des datagrid wenn der datetimepicker sich ändert
            FillDataGrid();
        }

        private void lbxKritisch_MouseDoubleClick(object sender, MouseEventArgs e)
        {//beim doppleklcik auf den entsprechenden Eintrag in der kritsich anzeige wird zu diesem tag gesprungen
            try
            {
                int intIndex = lbxKritisch.IndexFromPoint(e.Location);

                if (intIndex != -1)
                {
                    CritItem k1 = (CritItem)lbxKritisch.Items[intIndex];
                    dtpDay.Value = k1.Date;
                    dtpDay_ValueChanged(dtpDay, new EventArgs());
                }
            }
            catch (Exception ex)
            {
                Util.ShowError(ex);
            }
        }

        private void Verwaltung_Resize(object sender, EventArgs e)
        {
            try
            {
                if (FormWindowState.Minimized == this.WindowState)
                {//zeige das icon im tray falls das fenster minimiert wird
                    LoadTray();
                    _notIco.Visible = true;
                    this.ShowInTaskbar = false;
                }
                else
                {//ist das fenster nicht minimiert pass die größe des datagrids an
                    ResizeDataGrid();
                    _notIco.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Util.ShowError(ex);
            }
        }

        //timer events
        private void timer_Tick(object sender, EventArgs e)
        {/* Ein Timer  der jede minute das die aktelle aufgabe aktalisiert, sowie die kritschen tage*/
            try
            {
                Task active = currentUser.GetActiveTask();
                if (active != null)
                {
                    bool found = false;
                    for (int i = 0; i < dtgV1.Rows.Count && !found; i++)
                    {
                        Task gridAufgaebe = (Task)dtgV1[0, i].Tag;
                        if (gridAufgaebe.ID == active.ID)
                        {
                            found = true;
                            int taskTime = active.CalcTimeFromEvents();
                            dtgV1[2, i].Value = taskTime;
                            gridAufgaebe.Time = taskTime;
                        }
                    }
                    LoadCrit();
                }

            }
            catch (Exception ex)
            {
                Util.ShowError(ex);
            }
        }

        //filter: only active
        private void cbxAktive_CheckedChanged(object sender, EventArgs e)
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

        //close program
        private void TaskManagement_FormClosing(object sender, FormClosingEventArgs e)
        {
            Util.Exit();
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Util.Exit();
        }

        //delete/edit aufgabe
        void dtgV1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex != -1 && e.RowIndex != -1)
                {
                    Task clickedAufgabe = dtgV1[0, e.RowIndex].Tag as Task;
                    switch (e.ColumnIndex)
                    {
                        case 4:
                            {//pause
                                if (!clickedAufgabe.Finished)
                                {
                                    Task active = currentUser.GetActiveTask();
                                    if (active == null || active.ID != clickedAufgabe.ID)
                                    {
                                        currentUser.StopCurrentTask();
                                        clickedAufgabe.Start();
                                    }
                                    else
                                    {
                                        currentUser.StopCurrentTask();
                                    }
                                    FillDataGrid();
                                }
                                else
                                {
                                    ShowTaskAlreadyFinishedError();
                                }
                            } break;
                        case 5:
                            {//edit
                                ShowBuchungForm(clickedAufgabe.Finished, clickedAufgabe);
                            } break;

                        case 6:
                            {//delete
                                clickedAufgabe.Delete();
                                FillDataGrid();
                            } break;
                    }
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
