namespace BM_TimeTracker
{
    partial class fAdmin
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
            this.lbStart = new System.Windows.Forms.Label();
            this.lbEnde = new System.Windows.Forms.Label();
            this.cBoxUser = new System.Windows.Forms.ComboBox();
            this.btnLoadUserData = new System.Windows.Forms.Button();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.btnSaveExcel = new System.Windows.Forms.Button();
            this.dtpEnde = new System.Windows.Forms.DateTimePicker();
            this.btnUserVerwaltung = new System.Windows.Forms.Button();
            this.dtgV1 = new System.Windows.Forms.DataGridView();
            this.colAufgabe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIntern = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colZeit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDatum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnVerwaltung = new System.Windows.Forms.Button();
            this.pnlBack = new System.Windows.Forms.Panel();
            this.lblKritisch = new System.Windows.Forms.Label();
            this.lbxKritisch = new System.Windows.Forms.ListBox();
            this._ctxtMenuKritisch = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnEinstellungen = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgV1)).BeginInit();
            this.pnlBack.SuspendLayout();
            this.SuspendLayout();


            //handler
            this.FormClosing += Admin_FormClosing;
            btnEinstellungen.Click += btnSettings_Click;

            // 
            // lbStart
            // 
            this.lbStart.AutoSize = true;
            this.lbStart.Location = new System.Drawing.Point(3, 74);
            this.lbStart.Name = "lbStart";
            this.lbStart.Size = new System.Drawing.Size(29, 13);
            this.lbStart.TabIndex = 4;
            this.lbStart.Text = "Start";
            // 
            // lbEnde
            // 
            this.lbEnde.AutoSize = true;
            this.lbEnde.Location = new System.Drawing.Point(3, 123);
            this.lbEnde.Name = "lbEnde";
            this.lbEnde.Size = new System.Drawing.Size(32, 13);
            this.lbEnde.TabIndex = 5;
            this.lbEnde.Text = "Ende";
            // 
            // cBoxUser
            // 
            this.cBoxUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxUser.FormattingEnabled = true;
            this.cBoxUser.Location = new System.Drawing.Point(3, 50);
            this.cBoxUser.Name = "cBoxUser";
            this.cBoxUser.Size = new System.Drawing.Size(200, 21);
            this.cBoxUser.TabIndex = 3;
            // 
            // btnLoadUserData
            // 
            this.btnLoadUserData.Location = new System.Drawing.Point(3, 169);
            this.btnLoadUserData.Name = "btnLoadUserData";
            this.btnLoadUserData.Size = new System.Drawing.Size(75, 23);
            this.btnLoadUserData.TabIndex = 6;
            this.btnLoadUserData.Text = "Lade Daten";
            this.btnLoadUserData.UseVisualStyleBackColor = true;
            this.btnLoadUserData.Click += new System.EventHandler(this.btnLoadUserData_Click);
            // 
            // dtpStart
            // 
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStart.Location = new System.Drawing.Point(3, 90);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(97, 20);
            this.dtpStart.TabIndex = 2;
            // 
            // btnSaveExcel
            // 
            this.btnSaveExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveExcel.Location = new System.Drawing.Point(569, 514);
            this.btnSaveExcel.Name = "btnSaveExcel";
            this.btnSaveExcel.Size = new System.Drawing.Size(227, 23);
            this.btnSaveExcel.TabIndex = 7;
            this.btnSaveExcel.Text = "Exportieren";
            this.btnSaveExcel.UseVisualStyleBackColor = true;
            this.btnSaveExcel.Click += new System.EventHandler(this.btnSaveExcel_Click);
            // 
            // dtpEnde
            // 
            this.dtpEnde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEnde.Location = new System.Drawing.Point(3, 142);
            this.dtpEnde.Name = "dtpEnde";
            this.dtpEnde.Size = new System.Drawing.Size(97, 20);
            this.dtpEnde.TabIndex = 1;
            // 
            // btnUserVerwaltung
            // 
            this.btnUserVerwaltung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUserVerwaltung.Location = new System.Drawing.Point(615, 3);
            this.btnUserVerwaltung.Name = "btnUserVerwaltung";
            this.btnUserVerwaltung.Size = new System.Drawing.Size(181, 23);
            this.btnUserVerwaltung.TabIndex = 8;
            this.btnUserVerwaltung.Text = "Userverwaltung";
            this.btnUserVerwaltung.UseVisualStyleBackColor = true;
            this.btnUserVerwaltung.Click += new System.EventHandler(this.btnAdminChangeUser_Click);
            // 
            // dtgV1
            // 
            this.dtgV1.AllowUserToAddRows = false;
            this.dtgV1.AllowUserToDeleteRows = false;
            this.dtgV1.AllowUserToOrderColumns = true;
            this.dtgV1.AllowUserToResizeRows = false;
            this.dtgV1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgV1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgV1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colAufgabe,
            this.colIntern,
            this.colZeit,
            this.colDatum});
            this.dtgV1.Location = new System.Drawing.Point(3, 210);
            this.dtgV1.Name = "dtgV1";
            this.dtgV1.ReadOnly = true;
            this.dtgV1.Size = new System.Drawing.Size(793, 298);
            this.dtgV1.TabIndex = 0;
            // 
            // colAufgabe
            // 
            this.colAufgabe.HeaderText = "Aufgabe";
            this.colAufgabe.Name = "colAufgabe";
            this.colAufgabe.ReadOnly = true;
            // 
            // colIntern
            // 
            this.colIntern.HeaderText = "Intern";
            this.colIntern.Name = "colIntern";
            this.colIntern.ReadOnly = true;
            this.colIntern.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colIntern.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // colZeit
            // 
            this.colZeit.HeaderText = "Zeit in Minuten";
            this.colZeit.Name = "colZeit";
            this.colZeit.ReadOnly = true;
            // 
            // colDatum
            // 
            this.colDatum.HeaderText = "Datum";
            this.colDatum.Name = "colDatum";
            this.colDatum.ReadOnly = true;
            // 
            // btnVerwaltung
            // 
            this.btnVerwaltung.Location = new System.Drawing.Point(3, 3);
            this.btnVerwaltung.Name = "btnVerwaltung";
            this.btnVerwaltung.Size = new System.Drawing.Size(130, 23);
            this.btnVerwaltung.TabIndex = 9;
            this.btnVerwaltung.Text = "Zurück zur Verwaltung";
            this.btnVerwaltung.UseVisualStyleBackColor = true;
            this.btnVerwaltung.Click += new System.EventHandler(this.btnTaskManagement_Click);
            // 
            // pnlBack
            // 
            this.pnlBack.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlBack.Controls.Add(this.btnEinstellungen);
            this.pnlBack.Controls.Add(this.lblKritisch);
            this.pnlBack.Controls.Add(this.lbxKritisch);
            this.pnlBack.Controls.Add(this.btnVerwaltung);
            this.pnlBack.Controls.Add(this.dtgV1);
            this.pnlBack.Controls.Add(this.btnUserVerwaltung);
            this.pnlBack.Controls.Add(this.dtpEnde);
            this.pnlBack.Controls.Add(this.btnSaveExcel);
            this.pnlBack.Controls.Add(this.dtpStart);
            this.pnlBack.Controls.Add(this.btnLoadUserData);
            this.pnlBack.Controls.Add(this.cBoxUser);
            this.pnlBack.Controls.Add(this.lbEnde);
            this.pnlBack.Controls.Add(this.lbStart);
            this.pnlBack.Location = new System.Drawing.Point(12, 12);
            this.pnlBack.Name = "pnlBack";
            this.pnlBack.Size = new System.Drawing.Size(799, 540);
            this.pnlBack.TabIndex = 10;
            // 
            // lblKritisch
            // 
            this.lblKritisch.AutoSize = true;
            this.lblKritisch.Location = new System.Drawing.Point(284, 31);
            this.lblKritisch.Name = "lblKritisch";
            this.lblKritisch.Size = new System.Drawing.Size(80, 13);
            this.lblKritisch.TabIndex = 11;
            this.lblKritisch.Text = "Kritische Zeiten";
            // 
            // lbxKritisch
            // 
            this.lbxKritisch.ContextMenuStrip = this._ctxtMenuKritisch;
            this.lbxKritisch.FormattingEnabled = true;
            this.lbxKritisch.Location = new System.Drawing.Point(284, 50);
            this.lbxKritisch.Name = "lbxKritisch";
            this.lbxKritisch.Size = new System.Drawing.Size(270, 147);
            this.lbxKritisch.TabIndex = 10;
            this.lbxKritisch.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbxCrit_MouseDoubleClick);
            // 
            // _ctxtMenuKritisch
            // 
            this._ctxtMenuKritisch.Name = "_ctxtMenuKritisch";
            this._ctxtMenuKritisch.Size = new System.Drawing.Size(61, 4);
            // 
            // btnEinstellungen
            // 
            this.btnEinstellungen.Location = new System.Drawing.Point(615, 33);
            this.btnEinstellungen.Name = "btnEinstellungen";
            this.btnEinstellungen.Size = new System.Drawing.Size(181, 23);
            this.btnEinstellungen.TabIndex = 12;
            this.btnEinstellungen.Text = "Einstellungen";
            this.btnEinstellungen.UseVisualStyleBackColor = true;
            // 
            // fAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(823, 564);
            this.Controls.Add(this.pnlBack);
            this.MinimumSize = new System.Drawing.Size(839, 602);
            this.Name = "fAdmin";
            this.Text = "TimerTracker: Adminbereich";
            this.Resize += new System.EventHandler(this.Admin_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dtgV1)).EndInit();
            this.pnlBack.ResumeLayout(false);
            this.pnlBack.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbStart;
        private System.Windows.Forms.Label lbEnde;
        private System.Windows.Forms.ComboBox cBoxUser;
        private System.Windows.Forms.Button btnLoadUserData;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.Button btnSaveExcel;
        private System.Windows.Forms.DateTimePicker dtpEnde;
        private System.Windows.Forms.Button btnUserVerwaltung;
        private System.Windows.Forms.DataGridView dtgV1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAufgabe;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colIntern;
        private System.Windows.Forms.DataGridViewTextBoxColumn colZeit;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDatum;
        private System.Windows.Forms.Button btnVerwaltung;
        private System.Windows.Forms.Panel pnlBack;
        private System.Windows.Forms.Label lblKritisch;
        private System.Windows.Forms.ListBox lbxKritisch;
        private System.Windows.Forms.ContextMenuStrip _ctxtMenuKritisch;
        private System.Windows.Forms.Button btnEinstellungen;

    }
}