namespace gfchatbot
{
    partial class PasswordScreen
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblPrompt = new System.Windows.Forms.Label();
            this.btnHome = new System.Windows.Forms.Panel();
            this.phoneImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.phoneImage)).BeginInit();
            this.SuspendLayout();
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(136, 465);
            this.txtPassword.Multiline = true;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(362, 53);
            this.txtPassword.TabIndex = 0;
            // 
            // lblPrompt
            // 
            this.lblPrompt.BackColor = System.Drawing.Color.Transparent;
            this.lblPrompt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrompt.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.lblPrompt.Location = new System.Drawing.Point(132, 319);
            this.lblPrompt.Name = "lblPrompt";
            this.lblPrompt.Size = new System.Drawing.Size(366, 108);
            this.lblPrompt.TabIndex = 1;
            this.lblPrompt.Text = "enter passcode then press home button to confirm";
            this.lblPrompt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnHome
            // 
            this.btnHome.BackColor = System.Drawing.Color.Transparent;
            this.btnHome.Location = new System.Drawing.Point(275, 833);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(69, 65);
            this.btnHome.TabIndex = 2;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);

            // 
            // phoneImage
            // 
            this.phoneImage.BackColor = System.Drawing.Color.Transparent;
            this.phoneImage.BackgroundImage = global::gfchatbot.Properties.Resources.phoneOnImage;
            this.phoneImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.phoneImage.Location = new System.Drawing.Point(-46, -39);
            this.phoneImage.Name = "phoneImage";
            this.phoneImage.Size = new System.Drawing.Size(709, 1045);
            this.phoneImage.TabIndex = 3;
            this.phoneImage.TabStop = false;
            // 
            // PasswordScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GrayText;
            this.Controls.Add(this.btnHome);
            this.Controls.Add(this.lblPrompt);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.phoneImage);
            this.Name = "PasswordScreen";
            this.Size = new System.Drawing.Size(616, 966);
            ((System.ComponentModel.ISupportInitialize)(this.phoneImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblPrompt;
        private System.Windows.Forms.Panel btnHome;
        private System.Windows.Forms.PictureBox phoneImage;

    }
}
