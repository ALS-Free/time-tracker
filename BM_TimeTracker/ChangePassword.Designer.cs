namespace BM_TimeTracker
{
    partial class fChangePassword
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
            this.btnSpeichern = new System.Windows.Forms.Button();
            this.txtbPasswort = new System.Windows.Forms.TextBox();
            this.lblPasswort = new System.Windows.Forms.Label();
            this.txtbPasswort2 = new System.Windows.Forms.TextBox();
            this.lblPasswort2 = new System.Windows.Forms.Label();
            this.txtbOldPasswort = new System.Windows.Forms.TextBox();
            this.lblAltesPasswort = new System.Windows.Forms.Label();
            this.lblHinweis = new System.Windows.Forms.Label();
            this.pnlBack = new System.Windows.Forms.Panel();
            this.pnlBack.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSpeichern
            // 
            this.btnSpeichern.Location = new System.Drawing.Point(150, 171);
            this.btnSpeichern.Name = "btnSpeichern";
            this.btnSpeichern.Size = new System.Drawing.Size(75, 23);
            this.btnSpeichern.TabIndex = 3;
            this.btnSpeichern.Text = "Speichern";
            this.btnSpeichern.UseVisualStyleBackColor = true;
            this.btnSpeichern.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtbPasswort
            // 
            this.txtbPasswort.Location = new System.Drawing.Point(13, 94);
            this.txtbPasswort.Name = "txtbPasswort";
            this.txtbPasswort.PasswordChar = '*';
            this.txtbPasswort.Size = new System.Drawing.Size(212, 20);
            this.txtbPasswort.TabIndex = 1;
            // 
            // lblPasswort
            // 
            this.lblPasswort.AutoSize = true;
            this.lblPasswort.Location = new System.Drawing.Point(10, 78);
            this.lblPasswort.Name = "lblPasswort";
            this.lblPasswort.Size = new System.Drawing.Size(84, 13);
            this.lblPasswort.TabIndex = 2;
            this.lblPasswort.Text = "Neues Passwort";
            // 
            // txtbPasswort2
            // 
            this.txtbPasswort2.Location = new System.Drawing.Point(13, 145);
            this.txtbPasswort2.Name = "txtbPasswort2";
            this.txtbPasswort2.PasswordChar = '*';
            this.txtbPasswort2.Size = new System.Drawing.Size(209, 20);
            this.txtbPasswort2.TabIndex = 2;
            // 
            // lblPasswort2
            // 
            this.lblPasswort2.AutoSize = true;
            this.lblPasswort2.Location = new System.Drawing.Point(10, 129);
            this.lblPasswort2.Name = "lblPasswort2";
            this.lblPasswort2.Size = new System.Drawing.Size(130, 13);
            this.lblPasswort2.TabIndex = 4;
            this.lblPasswort2.Text = "Passwort erneut eingeben";
            // 
            // txtbOldPasswort
            // 
            this.txtbOldPasswort.Location = new System.Drawing.Point(13, 46);
            this.txtbOldPasswort.Name = "txtbOldPasswort";
            this.txtbOldPasswort.PasswordChar = '*';
            this.txtbOldPasswort.Size = new System.Drawing.Size(212, 20);
            this.txtbOldPasswort.TabIndex = 0;
            // 
            // lblAltesPasswort
            // 
            this.lblAltesPasswort.AutoSize = true;
            this.lblAltesPasswort.Location = new System.Drawing.Point(10, 30);
            this.lblAltesPasswort.Name = "lblAltesPasswort";
            this.lblAltesPasswort.Size = new System.Drawing.Size(76, 13);
            this.lblAltesPasswort.TabIndex = 6;
            this.lblAltesPasswort.Text = "Altes Passwort";
            // 
            // lblHinweis
            // 
            this.lblHinweis.AutoSize = true;
            this.lblHinweis.Location = new System.Drawing.Point(10, 171);
            this.lblHinweis.Name = "lblHinweis";
            this.lblHinweis.Size = new System.Drawing.Size(35, 13);
            this.lblHinweis.TabIndex = 7;
            this.lblHinweis.Text = "label1";
            // 
            // pnlBack
            // 
            this.pnlBack.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlBack.Controls.Add(this.txtbOldPasswort);
            this.pnlBack.Controls.Add(this.lblHinweis);
            this.pnlBack.Controls.Add(this.btnSpeichern);
            this.pnlBack.Controls.Add(this.lblAltesPasswort);
            this.pnlBack.Controls.Add(this.txtbPasswort);
            this.pnlBack.Controls.Add(this.lblPasswort);
            this.pnlBack.Controls.Add(this.lblPasswort2);
            this.pnlBack.Controls.Add(this.txtbPasswort2);
            this.pnlBack.Location = new System.Drawing.Point(12, 12);
            this.pnlBack.Name = "pnlBack";
            this.pnlBack.Size = new System.Drawing.Size(244, 215);
            this.pnlBack.TabIndex = 8;
            // 
            // fUserdaten
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(268, 241);
            this.Controls.Add(this.pnlBack);
            this.MinimumSize = new System.Drawing.Size(284, 279);
            this.Name = "fUserdaten";
            this.Text = "TimeTracker: Passwort ändern";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fChangePassword_FormClosing);
            this.pnlBack.ResumeLayout(false);
            this.pnlBack.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSpeichern;
        private System.Windows.Forms.TextBox txtbPasswort;
        private System.Windows.Forms.Label lblPasswort;
        private System.Windows.Forms.TextBox txtbPasswort2;
        private System.Windows.Forms.Label lblPasswort2;
        private System.Windows.Forms.TextBox txtbOldPasswort;
        private System.Windows.Forms.Label lblAltesPasswort;
        private System.Windows.Forms.Label lblHinweis;
        private System.Windows.Forms.Panel pnlBack;
    }
}