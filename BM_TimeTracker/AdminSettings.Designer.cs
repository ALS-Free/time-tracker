namespace BM_TimeTracker
{
    partial class fAdminSettings
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
            this.btnSave = new System.Windows.Forms.Button();
            this.txtbZeit = new System.Windows.Forms.TextBox();
            this.lbMindest = new System.Windows.Forms.Label();
            this.lbInvalidTime = new System.Windows.Forms.Label();
            this.pnlBackGround = new System.Windows.Forms.Panel();
            this.pnlBackGround.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(124, 41);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Speichern";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtbZeit
            // 
            this.txtbZeit.Location = new System.Drawing.Point(18, 44);
            this.txtbZeit.Name = "txtbZeit";
            this.txtbZeit.Size = new System.Drawing.Size(100, 20);
            this.txtbZeit.TabIndex = 1;
            // 
            // lbMindest
            // 
            this.lbMindest.AutoSize = true;
            this.lbMindest.Location = new System.Drawing.Point(19, 20);
            this.lbMindest.Name = "lbMindest";
            this.lbMindest.Size = new System.Drawing.Size(122, 13);
            this.lbMindest.TabIndex = 2;
            this.lbMindest.Text = "Erforderliche Mindestzeit";
            // 
            // lbInvalidTime
            // 
            this.lbInvalidTime.AutoSize = true;
            this.lbInvalidTime.ForeColor = System.Drawing.Color.Red;
            this.lbInvalidTime.Location = new System.Drawing.Point(22, 71);
            this.lbInvalidTime.Name = "lbInvalidTime";
            this.lbInvalidTime.Size = new System.Drawing.Size(132, 13);
            this.lbInvalidTime.TabIndex = 3;
            this.lbInvalidTime.Text = "Ungültige Zeit eingegeben";
            this.lbInvalidTime.Visible = false;
            // 
            // pnlBackGround
            // 
            this.pnlBackGround.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlBackGround.BackColor = System.Drawing.SystemColors.Control;
            this.pnlBackGround.Controls.Add(this.txtbZeit);
            this.pnlBackGround.Controls.Add(this.lbInvalidTime);
            this.pnlBackGround.Controls.Add(this.btnSave);
            this.pnlBackGround.Controls.Add(this.lbMindest);
            this.pnlBackGround.Location = new System.Drawing.Point(12, 12);
            this.pnlBackGround.Name = "pnlBackGround";
            this.pnlBackGround.Size = new System.Drawing.Size(219, 121);
            this.pnlBackGround.TabIndex = 4;
            // 
            // fAdmin_Einstellungen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(244, 146);
            this.Controls.Add(this.pnlBackGround);
            this.MinimumSize = new System.Drawing.Size(260, 184);
            this.Name = "fAdmin_Einstellungen";
            this.Text = "Admin_Einstellungen";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fAdminSettings_FormClosing);
            this.pnlBackGround.ResumeLayout(false);
            this.pnlBackGround.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtbZeit;
        private System.Windows.Forms.Label lbMindest;
        private System.Windows.Forms.Label lbInvalidTime;
        private System.Windows.Forms.Panel pnlBackGround;
    }
}