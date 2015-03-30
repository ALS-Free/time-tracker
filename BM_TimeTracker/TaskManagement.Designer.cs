namespace BM_TimeTracker
{
    partial class fTaskManagement
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.dtgV1 = new System.Windows.Forms.DataGridView();
            this.btnPause = new System.Windows.Forms.Button();
            this.lblHinweis = new System.Windows.Forms.Label();
            this._timer = new System.Windows.Forms.Timer(this.components);
            this.btnAdmin = new System.Windows.Forms.Button();
            this.btnUser = new System.Windows.Forms.Button();
            this.cbxAktive = new System.Windows.Forms.CheckBox();
            this.pnlBack = new System.Windows.Forms.Panel();
            this.lbUsername = new System.Windows.Forms.Label();
            this.dtpDay = new System.Windows.Forms.DateTimePicker();
            this.lbKritisch = new System.Windows.Forms.Label();
            this.lbxKritisch = new System.Windows.Forms.ListBox();
            this.btnLogout = new System.Windows.Forms.Button();
            this._notIco = new System.Windows.Forms.NotifyIcon(this.components);
            this._ctxtMenStrp = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.aufgabePausierenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aufgabeStartenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aufgabeBuchenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aufgabebeendenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ColAufgabe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColIntern = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColZeit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDatum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStart = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColBearbeiten = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColLöschen = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dtgV1)).BeginInit();
            this.pnlBack.SuspendLayout();
            this._ctxtMenStrp.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnStart.Location = new System.Drawing.Point(23, 60);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(99, 25);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(22, 126);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(130, 23);
            this.btnStop.TabIndex = 2;
            this.btnStop.Text = "Abschluss/Buchung";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // dtgV1
            // 
            this.dtgV1.AllowUserToAddRows = false;
            this.dtgV1.AllowUserToDeleteRows = false;
            this.dtgV1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgV1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgV1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColAufgabe,
            this.ColIntern,
            this.ColZeit,
            this.colDatum,
            this.colStart,
            this.ColBearbeiten,
            this.ColLöschen});
            this.dtgV1.Location = new System.Drawing.Point(22, 187);
            this.dtgV1.MultiSelect = false;
            this.dtgV1.Name = "dtgV1";
            this.dtgV1.ReadOnly = true;
            this.dtgV1.Size = new System.Drawing.Size(795, 258);
            this.dtgV1.TabIndex = 500;
            //this.dtgV1.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dtgV1_ColumnHeaderMouseClick);
            this.dtgV1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dtgV1_MouseDown);
            // 
            // btnPause
            // 
            this.btnPause.Location = new System.Drawing.Point(24, 91);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(99, 25);
            this.btnPause.TabIndex = 1;
            this.btnPause.Text = "Pause";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // lblHinweis
            // 
            this.lblHinweis.AutoSize = true;
            this.lblHinweis.Location = new System.Drawing.Point(128, 66);
            this.lblHinweis.Name = "lblHinweis";
            this.lblHinweis.Size = new System.Drawing.Size(35, 13);
            this.lblHinweis.TabIndex = 4;
            this.lblHinweis.Text = "label1";
            this.lblHinweis.Visible = false;
            // 
            // _timer
            // 
            this._timer.Interval = 10000;
            this._timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // btnAdmin
            // 
            this.btnAdmin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdmin.Location = new System.Drawing.Point(641, 12);
            this.btnAdmin.Name = "btnAdmin";
            this.btnAdmin.Size = new System.Drawing.Size(176, 23);
            this.btnAdmin.TabIndex = 5;
            this.btnAdmin.Text = "Adminbereich";
            this.btnAdmin.UseVisualStyleBackColor = true;
            this.btnAdmin.Click += new System.EventHandler(this.btnAdmin_Click);
            // 
            // btnUser
            // 
            this.btnUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnUser.Location = new System.Drawing.Point(22, 451);
            this.btnUser.Name = "btnUser";
            this.btnUser.Size = new System.Drawing.Size(130, 23);
            this.btnUser.TabIndex = 4;
            this.btnUser.Text = "Passwort ändern";
            this.btnUser.UseVisualStyleBackColor = true;
            this.btnUser.Click += new System.EventHandler(this.btnUser_Click);
            // 
            // cbxAktive
            // 
            this.cbxAktive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxAktive.AutoSize = true;
            this.cbxAktive.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbxAktive.Location = new System.Drawing.Point(706, 144);
            this.cbxAktive.Name = "cbxAktive";
            this.cbxAktive.Size = new System.Drawing.Size(111, 17);
            this.cbxAktive.TabIndex = 7;
            this.cbxAktive.Text = "Nur aktive Zeigen";
            this.cbxAktive.UseVisualStyleBackColor = true;
            this.cbxAktive.CheckedChanged += new System.EventHandler(this.cbxAktive_CheckedChanged);
            // 
            // pnlBack
            // 
            this.pnlBack.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlBack.Controls.Add(this.lbUsername);
            this.pnlBack.Controls.Add(this.dtpDay);
            this.pnlBack.Controls.Add(this.lbKritisch);
            this.pnlBack.Controls.Add(this.lbxKritisch);
            this.pnlBack.Controls.Add(this.btnLogout);
            this.pnlBack.Controls.Add(this.btnStart);
            this.pnlBack.Controls.Add(this.cbxAktive);
            this.pnlBack.Controls.Add(this.btnStop);
            this.pnlBack.Controls.Add(this.btnUser);
            this.pnlBack.Controls.Add(this.dtgV1);
            this.pnlBack.Controls.Add(this.btnAdmin);
            this.pnlBack.Controls.Add(this.btnPause);
            this.pnlBack.Controls.Add(this.lblHinweis);
            this.pnlBack.Location = new System.Drawing.Point(12, 12);
            this.pnlBack.Name = "pnlBack";
            this.pnlBack.Size = new System.Drawing.Size(833, 477);
            this.pnlBack.TabIndex = 8;
            this.pnlBack.Click += new System.EventHandler(this.pnlBack_Click);
            // 
            // lbUsername
            // 
            this.lbUsername.AutoSize = true;
            this.lbUsername.Location = new System.Drawing.Point(117, 12);
            this.lbUsername.Name = "lbUsername";
            this.lbUsername.Size = new System.Drawing.Size(55, 13);
            this.lbUsername.TabIndex = 504;
            this.lbUsername.Text = "Username";
            // 
            // dtpDay
            // 
            this.dtpDay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpDay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDay.Location = new System.Drawing.Point(706, 118);
            this.dtpDay.Name = "dtpDay";
            this.dtpDay.Size = new System.Drawing.Size(110, 20);
            this.dtpDay.TabIndex = 503;
            this.dtpDay.ValueChanged += new System.EventHandler(this.dtpDay_ValueChanged);
            // 
            // lbKritisch
            // 
            this.lbKritisch.AutoSize = true;
            this.lbKritisch.Location = new System.Drawing.Point(325, 12);
            this.lbKritisch.Name = "lbKritisch";
            this.lbKritisch.Size = new System.Drawing.Size(75, 13);
            this.lbKritisch.TabIndex = 502;
            this.lbKritisch.Text = "Kritische Tage";
            // 
            // lbxKritisch
            // 
            this.lbxKritisch.FormattingEnabled = true;
            this.lbxKritisch.Location = new System.Drawing.Point(328, 34);
            this.lbxKritisch.Name = "lbxKritisch";
            this.lbxKritisch.Size = new System.Drawing.Size(215, 134);
            this.lbxKritisch.TabIndex = 501;
            this.lbxKritisch.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbxKritisch_MouseDoubleClick);
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(24, 10);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(79, 25);
            this.btnLogout.TabIndex = 6;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // _notIco
            // 
            this._notIco.ContextMenuStrip = this._ctxtMenStrp;
            this._notIco.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseClick);
            // 
            // _ctxtMenStrp
            // 
            this._ctxtMenStrp.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aufgabePausierenToolStripMenuItem,
            this.aufgabeStartenToolStripMenuItem,
            this.aufgabeBuchenToolStripMenuItem,
            this.aufgabebeendenToolStripMenuItem});
            this._ctxtMenStrp.Name = "_ctxtMenStrp";
            this._ctxtMenStrp.Size = new System.Drawing.Size(174, 92);
            // 
            // aufgabePausierenToolStripMenuItem
            // 
            this.aufgabePausierenToolStripMenuItem.Name = "aufgabePausierenToolStripMenuItem";
            this.aufgabePausierenToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.aufgabePausierenToolStripMenuItem.Text = "Aufgabe Pausieren";
            this.aufgabePausierenToolStripMenuItem.Click += new System.EventHandler(this.taskPauseToolStripMenuItem_Click);
            // 
            // aufgabeStartenToolStripMenuItem
            // 
            this.aufgabeStartenToolStripMenuItem.Name = "aufgabeStartenToolStripMenuItem";
            this.aufgabeStartenToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.aufgabeStartenToolStripMenuItem.Text = "Aufgabe Starten";
            // 
            // aufgabeBuchenToolStripMenuItem
            // 
            this.aufgabeBuchenToolStripMenuItem.Name = "aufgabeBuchenToolStripMenuItem";
            this.aufgabeBuchenToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.aufgabeBuchenToolStripMenuItem.Text = "Aufgabe Buchen";
            // 
            // aufgabebeendenToolStripMenuItem
            // 
            this.aufgabebeendenToolStripMenuItem.Name = "aufgabebeendenToolStripMenuItem";
            this.aufgabebeendenToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.aufgabebeendenToolStripMenuItem.Text = "Beenden";
            this.aufgabebeendenToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // ColAufgabe
            // 
            this.ColAufgabe.HeaderText = "Aufgabe";
            this.ColAufgabe.Name = "ColAufgabe";
            this.ColAufgabe.ReadOnly = true;
            this.ColAufgabe.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColIntern
            // 
            this.ColIntern.HeaderText = "Intern";
            this.ColIntern.Name = "ColIntern";
            this.ColIntern.ReadOnly = true;
            this.ColIntern.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // ColZeit
            // 
            this.ColZeit.HeaderText = "Zeit in Minuten";
            this.ColZeit.Name = "ColZeit";
            this.ColZeit.ReadOnly = true;
            this.ColZeit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colDatum
            // 
            this.colDatum.HeaderText = "Datum";
            this.colDatum.MaxInputLength = 10;
            this.colDatum.Name = "colDatum";
            this.colDatum.ReadOnly = true;
            this.colDatum.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colStart
            // 
            this.colStart.HeaderText = "Aufgabe Starten";
            this.colStart.Name = "colStart";
            this.colStart.ReadOnly = true;
            // 
            // ColBearbeiten
            // 
            this.ColBearbeiten.HeaderText = "Bearbeiten";
            this.ColBearbeiten.Name = "ColBearbeiten";
            this.ColBearbeiten.ReadOnly = true;
            // 
            // ColLöschen
            // 
            this.ColLöschen.HeaderText = "Löschen";
            this.ColLöschen.Name = "ColLöschen";
            this.ColLöschen.ReadOnly = true;
            // 
            // fVerwaltung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 502);
            this.Controls.Add(this.pnlBack);
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(873, 540);
            this.Name = "fVerwaltung";
            this.Text = "TimeTracker: Aufgaben Manager";
            this.Click += new System.EventHandler(this.Verwaltung_Click);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fVerwaltung_KeyDown);
            this.Resize += new System.EventHandler(this.Verwaltung_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dtgV1)).EndInit();
            this.pnlBack.ResumeLayout(false);
            this.pnlBack.PerformLayout();
            this._ctxtMenStrp.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.DataGridView dtgV1;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Label lblHinweis;
        private System.Windows.Forms.Timer _timer;
        private System.Windows.Forms.Button btnAdmin;
        private System.Windows.Forms.Button btnUser;
        private System.Windows.Forms.CheckBox cbxAktive;
        private System.Windows.Forms.Panel pnlBack;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Label lbKritisch;
        private System.Windows.Forms.ListBox lbxKritisch;
        private System.Windows.Forms.NotifyIcon _notIco;
        private System.Windows.Forms.ContextMenuStrip _ctxtMenStrp;
        private System.Windows.Forms.ToolStripMenuItem aufgabeStartenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aufgabeBuchenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aufgabePausierenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aufgabebeendenToolStripMenuItem;
        private System.Windows.Forms.DateTimePicker dtpDay;
        private System.Windows.Forms.Label lbUsername;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColAufgabe;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColIntern;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColZeit;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDatum;
        private System.Windows.Forms.DataGridViewButtonColumn colStart;
        private System.Windows.Forms.DataGridViewButtonColumn ColBearbeiten;
        private System.Windows.Forms.DataGridViewButtonColumn ColLöschen;
    }
}