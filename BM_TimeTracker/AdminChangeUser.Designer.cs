namespace BM_TimeTracker
{
    partial class fAdminChangeUser
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
            this.cboxUser = new System.Windows.Forms.ComboBox();
            this.txtbUsername = new System.Windows.Forms.TextBox();
            this.lbUsername = new System.Windows.Forms.Label();
            this.txtbpassword = new System.Windows.Forms.TextBox();
            this.lbPassword = new System.Windows.Forms.Label();
            this.btnSpeichern = new System.Windows.Forms.Button();
            this.lblHinweis = new System.Windows.Forms.Label();
            this.pnlBack = new System.Windows.Forms.Panel();
            this.cbxAdmin = new System.Windows.Forms.CheckBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.pnlBack.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboxUser
            // 
            this.cboxUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxUser.FormattingEnabled = true;
            this.cboxUser.Location = new System.Drawing.Point(22, 17);
            this.cboxUser.Name = "cboxUser";
            this.cboxUser.Size = new System.Drawing.Size(223, 21);
            this.cboxUser.TabIndex = 0;
            this.cboxUser.SelectedIndexChanged += new System.EventHandler(this.cboxUser_SelectedIndexChanged);
            // 
            // txtbUsername
            // 
            this.txtbUsername.Location = new System.Drawing.Point(22, 64);
            this.txtbUsername.Name = "txtbUsername";
            this.txtbUsername.Size = new System.Drawing.Size(223, 20);
            this.txtbUsername.TabIndex = 1;
            // 
            // lbUsername
            // 
            this.lbUsername.AutoSize = true;
            this.lbUsername.Location = new System.Drawing.Point(19, 48);
            this.lbUsername.Name = "lbUsername";
            this.lbUsername.Size = new System.Drawing.Size(55, 13);
            this.lbUsername.TabIndex = 2;
            this.lbUsername.Text = "Username";
            // 
            // txtbpassword
            // 
            this.txtbpassword.Location = new System.Drawing.Point(22, 119);
            this.txtbpassword.Name = "txtbpassword";
            this.txtbpassword.PasswordChar = '*';
            this.txtbpassword.Size = new System.Drawing.Size(223, 20);
            this.txtbpassword.TabIndex = 3;
            // 
            // lbPassword
            // 
            this.lbPassword.AutoSize = true;
            this.lbPassword.Location = new System.Drawing.Point(19, 103);
            this.lbPassword.Name = "lbPassword";
            this.lbPassword.Size = new System.Drawing.Size(50, 13);
            this.lbPassword.TabIndex = 4;
            this.lbPassword.Text = "Passwort";
            // 
            // btnSpeichern
            // 
            this.btnSpeichern.Location = new System.Drawing.Point(170, 166);
            this.btnSpeichern.Name = "btnSpeichern";
            this.btnSpeichern.Size = new System.Drawing.Size(75, 23);
            this.btnSpeichern.TabIndex = 5;
            this.btnSpeichern.Text = "Speichern";
            this.btnSpeichern.UseVisualStyleBackColor = true;
            this.btnSpeichern.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblHinweis
            // 
            this.lblHinweis.AutoSize = true;
            this.lblHinweis.Location = new System.Drawing.Point(19, 176);
            this.lblHinweis.MaximumSize = new System.Drawing.Size(200, 0);
            this.lblHinweis.Name = "lblHinweis";
            this.lblHinweis.Size = new System.Drawing.Size(35, 13);
            this.lblHinweis.TabIndex = 6;
            this.lblHinweis.Text = "label1";
            // 
            // pnlBack
            // 
            this.pnlBack.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlBack.Controls.Add(this.cbxAdmin);
            this.pnlBack.Controls.Add(this.btnDelete);
            this.pnlBack.Controls.Add(this.cboxUser);
            this.pnlBack.Controls.Add(this.lblHinweis);
            this.pnlBack.Controls.Add(this.txtbUsername);
            this.pnlBack.Controls.Add(this.btnSpeichern);
            this.pnlBack.Controls.Add(this.lbUsername);
            this.pnlBack.Controls.Add(this.lbPassword);
            this.pnlBack.Controls.Add(this.txtbpassword);
            this.pnlBack.Location = new System.Drawing.Point(12, 8);
            this.pnlBack.Name = "pnlBack";
            this.pnlBack.Size = new System.Drawing.Size(258, 241);
            this.pnlBack.TabIndex = 7;
            // 
            // cbxAdmin
            // 
            this.cbxAdmin.AutoSize = true;
            this.cbxAdmin.Location = new System.Drawing.Point(22, 146);
            this.cbxAdmin.Name = "cbxAdmin";
            this.cbxAdmin.Size = new System.Drawing.Size(55, 17);
            this.cbxAdmin.TabIndex = 8;
            this.cbxAdmin.Text = "Admin";
            this.cbxAdmin.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(22, 213);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 7;
            this.btnDelete.Text = "Löschen";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Visible = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // fUserverwaltung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 261);
            this.Controls.Add(this.pnlBack);
            this.MinimumSize = new System.Drawing.Size(298, 264);
            this.Name = "fUserverwaltung";
            this.Text = "TimeTracker: BenutzerBearbeitung";
            this.pnlBack.ResumeLayout(false);
            this.pnlBack.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cboxUser;
        private System.Windows.Forms.TextBox txtbUsername;
        private System.Windows.Forms.Label lbUsername;
        private System.Windows.Forms.TextBox txtbpassword;
        private System.Windows.Forms.Label lbPassword;
        private System.Windows.Forms.Button btnSpeichern;
        private System.Windows.Forms.Label lblHinweis;
        private System.Windows.Forms.Panel pnlBack;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.CheckBox cbxAdmin;
    }
}