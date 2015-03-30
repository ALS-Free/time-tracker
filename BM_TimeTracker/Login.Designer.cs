namespace BM_TimeTracker
{
    partial class fLogin
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fLogin));
            this.txtbUsername = new System.Windows.Forms.TextBox();
            this.lbUsername = new System.Windows.Forms.Label();
            this.txtbPassword = new System.Windows.Forms.TextBox();
            this.lbPassword = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.lblHinweis = new System.Windows.Forms.Label();
            this.pnlBack = new System.Windows.Forms.Panel();
            this.lnkNeuUser = new System.Windows.Forms.LinkLabel();
            this.lbTimeTracker = new System.Windows.Forms.Label();
            this.pnlBack.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtbUsername
            // 
            resources.ApplyResources(this.txtbUsername, "txtbUsername");
            this.txtbUsername.Name = "txtbUsername";
            // 
            // lbUsername
            // 
            resources.ApplyResources(this.lbUsername, "lbUsername");
            this.lbUsername.Name = "lbUsername";
            // 
            // txtbPassword
            // 
            resources.ApplyResources(this.txtbPassword, "txtbPassword");
            this.txtbPassword.Name = "txtbPassword";
            // 
            // lbPassword
            // 
            resources.ApplyResources(this.lbPassword, "lbPassword");
            this.lbPassword.Name = "lbPassword";
            // 
            // btnLogin
            // 
            resources.ApplyResources(this.btnLogin, "btnLogin");
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // lblHinweis
            // 
            resources.ApplyResources(this.lblHinweis, "lblHinweis");
            this.lblHinweis.Name = "lblHinweis";
            // 
            // pnlBack
            // 
            resources.ApplyResources(this.pnlBack, "pnlBack");
            this.pnlBack.Controls.Add(this.btnLogin);
            this.pnlBack.Controls.Add(this.lnkNeuUser);
            this.pnlBack.Controls.Add(this.lbTimeTracker);
            this.pnlBack.Controls.Add(this.txtbUsername);
            this.pnlBack.Controls.Add(this.lblHinweis);
            this.pnlBack.Controls.Add(this.lbUsername);
            this.pnlBack.Controls.Add(this.txtbPassword);
            this.pnlBack.Controls.Add(this.lbPassword);
            this.pnlBack.Name = "pnlBack";
            // 
            // lnkNeuUser
            // 
            resources.ApplyResources(this.lnkNeuUser, "lnkNeuUser");
            this.lnkNeuUser.Name = "lnkNeuUser";
            this.lnkNeuUser.TabStop = true;
            this.lnkNeuUser.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkNewUser_LinkClicked);
            // 
            // lbTimeTracker
            // 
            resources.ApplyResources(this.lbTimeTracker, "lbTimeTracker");
            this.lbTimeTracker.Name = "lbTimeTracker";
            // 
            // fLogin
            // 
            this.AcceptButton = this.btnLogin;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlBack);
            this.Name = "fLogin";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fLogin_FormClosing);
            this.pnlBack.ResumeLayout(false);
            this.pnlBack.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtbUsername;
        private System.Windows.Forms.Label lbUsername;
        private System.Windows.Forms.TextBox txtbPassword;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label lblHinweis;
        private System.Windows.Forms.Panel pnlBack;
        private System.Windows.Forms.Label lbTimeTracker;
        private System.Windows.Forms.LinkLabel lnkNeuUser;
        public System.Windows.Forms.Label lbPassword;
    }
}

