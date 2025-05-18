namespace ATM_Desktop
{
    partial class frmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            btnLogIn = new Button();
            label2 = new Label();
            txtUserName = new TextBox();
            txtPIN = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(176, 102);
            label1.Name = "label1";
            label1.Size = new Size(251, 41);
            label1.TabIndex = 0;
            label1.Text = "Account Number:";
            // 
            // btnLogIn
            // 
            btnLogIn.BackColor = SystemColors.ActiveCaption;
            btnLogIn.Location = new Point(539, 256);
            btnLogIn.Name = "btnLogIn";
            btnLogIn.Size = new Size(155, 60);
            btnLogIn.TabIndex = 1;
            btnLogIn.Text = "LOGIN";
            btnLogIn.UseVisualStyleBackColor = false;
            btnLogIn.Click += btnLogIn_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(183, 170);
            label2.Name = "label2";
            label2.Size = new Size(72, 41);
            label2.TabIndex = 2;
            label2.Text = "PIN:";
            // 
            // txtUserName
            // 
            txtUserName.Location = new Point(433, 102);
            txtUserName.Name = "txtUserName";
            txtUserName.Size = new Size(376, 47);
            txtUserName.TabIndex = 3;
            // 
            // txtPIN
            // 
            txtPIN.Location = new Point(433, 179);
            txtPIN.Name = "txtPIN";
            txtPIN.Size = new Size(376, 47);
            txtPIN.TabIndex = 4;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1119, 451);
            Controls.Add(txtPIN);
            Controls.Add(txtUserName);
            Controls.Add(label2);
            Controls.Add(btnLogIn);
            Controls.Add(label1);
            Name = "frmMain";
            Text = "ATM DESKTOP";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btnLogIn;
        private Label label2;
        private TextBox txtUserName;
        private TextBox txtPIN;
    }
}
