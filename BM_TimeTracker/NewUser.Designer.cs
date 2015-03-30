namespace BM_TimeTracker
{
    partial class fNewUser
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
            this.txtbBenutzerName = new System.Windows.Forms.TextBox();
            this.lbUsername = new System.Windows.Forms.Label();
            this.pnlBack = new System.Windows.Forms.Panel();
            this.lblHinweis = new System.Windows.Forms.Label();
            this.btnSpeichern = new System.Windows.Forms.Button();
            this.txtbPasswort2 = new System.Windows.Forms.TextBox();
            this.lbPasswort2 = new System.Windows.Forms.Label();
            this.txtbPasswort1 = new System.Windows.Forms.TextBox();
            this.lbPasswort = new System.Windows.Forms.Label();
            this.pnlBack.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtbBenutzerName
            // 
            this.txtbBenutzerName.Location = new System.Drawing.Point(9, 24);
            this.txtbBenutzerName.Name = "txtbBenutzerName";
            this.txtbBenutzerName.Size = new System.Drawing.Size(200, 20);
            this.txtbBenutzerName.TabIndex = 0;
            // 
            // lbUsername
            // 
            this.lbUsername.AutoSize = true;
            this.lbUsername.Location = new System.Drawing.Point(6, 8);
            this.lbUsername.Name = "lbUsername";
            this.lbUsername.Size = new System.Drawing.Size(75, 13);
            this.lbUsername.TabIndex = 1;
            this.lbUsername.Text = "Benutzername";
            // 
            // pnlBack
            // 
            this.pnlBack.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlBack.Controls.Add(this.lblHinweis);
            this.pnlBack.Controls.Add(this.btnSpeichern);
            this.pnlBack.Controls.Add(this.txtbPasswort2);
            this.pnlBack.Controls.Add(this.lbPasswort2);
            this.pnlBack.Controls.Add(this.txtbPasswort1);
            this.pnlBack.Controls.Add(this.lbPasswort);
            this.pnlBack.Controls.Add(this.txtbBenutzerName);
            this.pnlBack.Controls.Add(this.lbUsername);
            this.pnlBack.Location = new System.Drawing.Point(12, 12);
            this.pnlBack.Name = "pnlBack";
            this.pnlBack.Size = new System.Drawing.Size(219, 202);
            this.pnlBack.TabIndex = 2;
            // 
            // lblHinweis
            // 
            this.lblHinweis.AutoSize = true;
            this.lblHinweis.Location = new System.Drawing.Point(6, 127);
            this.lblHinweis.Name = "lblHinweis";
            this.lblHinweis.Size = new System.Drawing.Size(35, 13);
            this.lblHinweis.TabIndex = 7;
            this.lblHinweis.Text = "label1";
            // 
            // btnSpeichern
            // 
            this.btnSpeichern.Location = new System.Drawing.Point(132, 162);
            this.btnSpeichern.Name = "btnSpeichern";
            this.btnSpeichern.Size = new System.Drawing.Size(75, 23);
            this.btnSpeichern.TabIndex = 6;
            this.btnSpeichern.Text = "Speichern";
            this.btnSpeichern.UseVisualStyleBackColor = true;
            this.btnSpeichern.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtbPasswort2
            // 
            this.txtbPasswort2.Location = new System.Drawing.Point(9, 104);
            this.txtbPasswort2.Name = "txtbPasswort2";
            this.txtbPasswort2.PasswordChar = '*';
            this.txtbPasswort2.Size = new System.Drawing.Size(198, 20);
            this.txtbPasswort2.TabIndex = 5;
            // 
            // lbPasswort2
            // 
            this.lbPasswort2.AutoSize = true;
            this.lbPasswort2.Location = new System.Drawing.Point(6, 87);
            this.lbPasswort2.Name = "lbPasswort2";
            this.lbPasswort2.Size = new System.Drawing.Size(130, 13);
            this.lbPasswort2.TabIndex = 4;
            this.lbPasswort2.Text = "Passwort erneut eingeben";
            // 
            // txtbPasswort1
            // 
            this.txtbPasswort1.Location = new System.Drawing.Point(9, 64);
            this.txtbPasswort1.Name = "txtbPasswort1";
            this.txtbPasswort1.PasswordChar = '*';
            this.txtbPasswort1.Size = new System.Drawing.Size(199, 20);
            this.txtbPasswort1.TabIndex = 3;
            // 
            // lbPasswort
            // 
            this.lbPasswort.AutoSize = true;
            this.lbPasswort.Location = new System.Drawing.Point(6, 47);
            this.lbPasswort.Name = "lbPasswort";
            this.lbPasswort.Size = new System.Drawing.Size(50, 13);
            this.lbPasswort.TabIndex = 2;
            this.lbPasswort.Text = "Passwort";
            // 
            // NeuBenutzer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(239, 222);
            this.Controls.Add(this.pnlBack);
            this.MinimumSize = new System.Drawing.Size(255, 260);
            this.Name = "NeuBenutzer";
            this.Text = "TimeTracker: Neuer Benutzer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NeuBenutzer_FormClosing);
            this.pnlBack.ResumeLayout(false);
            this.pnlBack.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtbBenutzerName;
        private System.Windows.Forms.Label lbUsername;
        private System.Windows.Forms.Panel pnlBack;
        private System.Windows.Forms.Label lbPasswort2;
        private System.Windows.Forms.TextBox txtbPasswort1;
        private System.Windows.Forms.Label lbPasswort;
        private System.Windows.Forms.Label lblHinweis;
        private System.Windows.Forms.Button btnSpeichern;
        private System.Windows.Forms.TextBox txtbPasswort2;
    }
}