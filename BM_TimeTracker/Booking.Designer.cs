namespace BM_TimeTracker
{
    partial class fBooking
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
            //handler
            this.FormClosing += Booking_FormClosing;

            this.txtbAufgabeName = new System.Windows.Forms.TextBox();
            this.lbAufgabeName = new System.Windows.Forms.Label();
            this.cbxIntern = new System.Windows.Forms.CheckBox();
            this.dtpDatum = new System.Windows.Forms.DateTimePicker();
            this.txtbZeit = new System.Windows.Forms.TextBox();
            this.lbZeit = new System.Windows.Forms.Label();
            this.btnBuchen = new System.Windows.Forms.Button();
            this.btnBerechnen = new System.Windows.Forms.Button();
            this.pnlBack = new System.Windows.Forms.Panel();
            this.lblHinweis = new System.Windows.Forms.Label();
            this.pnlBack.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtbAufgabeName
            // 
            this.txtbAufgabeName.Location = new System.Drawing.Point(67, 14);
            this.txtbAufgabeName.Name = "txtbAufgabeName";
            this.txtbAufgabeName.Size = new System.Drawing.Size(203, 20);
            this.txtbAufgabeName.TabIndex = 0;
            // 
            // lbAufgabeName
            // 
            this.lbAufgabeName.AutoSize = true;
            this.lbAufgabeName.Location = new System.Drawing.Point(14, 17);
            this.lbAufgabeName.Name = "lbAufgabeName";
            this.lbAufgabeName.Size = new System.Drawing.Size(47, 13);
            this.lbAufgabeName.TabIndex = 1;
            this.lbAufgabeName.Text = "Aufgabe";
            // 
            // cbxIntern
            // 
            this.cbxIntern.AutoSize = true;
            this.cbxIntern.Location = new System.Drawing.Point(17, 40);
            this.cbxIntern.Name = "cbxIntern";
            this.cbxIntern.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbxIntern.Size = new System.Drawing.Size(129, 17);
            this.cbxIntern.TabIndex = 1;
            this.cbxIntern.Text = "Intern Brune Mettcker";
            this.cbxIntern.UseVisualStyleBackColor = true;
            // 
            // dtpDatum
            // 
            this.dtpDatum.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDatum.Location = new System.Drawing.Point(17, 95);
            this.dtpDatum.Name = "dtpDatum";
            this.dtpDatum.Size = new System.Drawing.Size(126, 20);
            this.dtpDatum.TabIndex = 4;
            // 
            // txtbZeit
            // 
            this.txtbZeit.Location = new System.Drawing.Point(89, 63);
            this.txtbZeit.Name = "txtbZeit";
            this.txtbZeit.Size = new System.Drawing.Size(100, 20);
            this.txtbZeit.TabIndex = 2;
            // 
            // lbZeit
            // 
            this.lbZeit.AutoSize = true;
            this.lbZeit.Location = new System.Drawing.Point(17, 66);
            this.lbZeit.Name = "lbZeit";
            this.lbZeit.Size = new System.Drawing.Size(66, 13);
            this.lbZeit.TabIndex = 5;
            this.lbZeit.Text = "Zeit Minuten";
            // 
            // btnBuchen
            // 
            this.btnBuchen.Location = new System.Drawing.Point(17, 121);
            this.btnBuchen.Name = "btnBuchen";
            this.btnBuchen.Size = new System.Drawing.Size(126, 23);
            this.btnBuchen.TabIndex = 5;
            this.btnBuchen.Text = "Arbeitszeit buchen";
            this.btnBuchen.UseVisualStyleBackColor = true;
            this.btnBuchen.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnBerechnen
            // 
            this.btnBerechnen.Location = new System.Drawing.Point(195, 60);
            this.btnBerechnen.Name = "btnBerechnen";
            this.btnBerechnen.Size = new System.Drawing.Size(75, 23);
            this.btnBerechnen.TabIndex = 3;
            this.btnBerechnen.Text = "Berechnen";
            this.btnBerechnen.UseVisualStyleBackColor = true;
            this.btnBerechnen.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // pnlBack
            // 
            this.pnlBack.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlBack.Controls.Add(this.lblHinweis);
            this.pnlBack.Controls.Add(this.btnBerechnen);
            this.pnlBack.Controls.Add(this.txtbAufgabeName);
            this.pnlBack.Controls.Add(this.btnBuchen);
            this.pnlBack.Controls.Add(this.lbAufgabeName);
            this.pnlBack.Controls.Add(this.lbZeit);
            this.pnlBack.Controls.Add(this.cbxIntern);
            this.pnlBack.Controls.Add(this.txtbZeit);
            this.pnlBack.Controls.Add(this.dtpDatum);
            this.pnlBack.Location = new System.Drawing.Point(12, 12);
            this.pnlBack.Name = "pnlBack";
            this.pnlBack.Size = new System.Drawing.Size(290, 188);
            this.pnlBack.TabIndex = 8;
            // 
            // lblHinweis
            // 
            this.lblHinweis.AutoSize = true;
            this.lblHinweis.Location = new System.Drawing.Point(17, 151);
            this.lblHinweis.Name = "lblHinweis";
            this.lblHinweis.Size = new System.Drawing.Size(35, 13);
            this.lblHinweis.TabIndex = 6;
            this.lblHinweis.Text = "label1";
            // 
            // fBuchung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 211);
            this.Controls.Add(this.pnlBack);
            this.MinimumSize = new System.Drawing.Size(330, 249);
            this.Name = "fBuchung";
            this.Text = "TimeTracker: Buchung";
            this.pnlBack.ResumeLayout(false);
            this.pnlBack.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtbAufgabeName;
        private System.Windows.Forms.Label lbAufgabeName;
        private System.Windows.Forms.CheckBox cbxIntern;
        private System.Windows.Forms.DateTimePicker dtpDatum;
        private System.Windows.Forms.TextBox txtbZeit;
        private System.Windows.Forms.Label lbZeit;
        private System.Windows.Forms.Button btnBuchen;
        private System.Windows.Forms.Button btnBerechnen;
        private System.Windows.Forms.Panel pnlBack;
        private System.Windows.Forms.Label lblHinweis;
    }
}