namespace gfchatbot
{
    partial class MenuScreen
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
            this.phoneImage = new System.Windows.Forms.PictureBox();
            this.panelNotification = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.phoneImage)).BeginInit();
            this.panelNotification.SuspendLayout();
            this.SuspendLayout();
            // 
            // phoneImage
            // 
            this.phoneImage.BackColor = System.Drawing.Color.Transparent;
            this.phoneImage.BackgroundImage = global::gfchatbot.Properties.Resources.phoneOffImage;
            this.phoneImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.phoneImage.Location = new System.Drawing.Point(-45, -37);
            this.phoneImage.Name = "phoneImage";
            this.phoneImage.Size = new System.Drawing.Size(709, 1045);
            this.phoneImage.TabIndex = 0;
            this.phoneImage.TabStop = false;
            this.phoneImage.Click += new System.EventHandler(this.phoneImage_Click);
            // 
            // panelNotification
            // 
            this.panelNotification.BackColor = System.Drawing.Color.Transparent;
            this.panelNotification.BackgroundImage = global::gfchatbot.Properties.Resources.notificationBox1Image;
            this.panelNotification.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panelNotification.Controls.Add(this.label2);
            this.panelNotification.Controls.Add(this.label1);
            this.panelNotification.Location = new System.Drawing.Point(169, 477);
            this.panelNotification.Name = "panelNotification";
            this.panelNotification.Size = new System.Drawing.Size(260, 130);
            this.panelNotification.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(216, 28);
            this.label2.TabIndex = 1;
            this.label2.Text = "new message from gf";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "imessage";
            // 
            // MenuScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::gfchatbot.Properties.Resources.Untitled_design;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.panelNotification);
            this.Controls.Add(this.phoneImage);
            this.DoubleBuffered = true;
            this.Name = "MenuScreen";
            this.Size = new System.Drawing.Size(616, 966);
            ((System.ComponentModel.ISupportInitialize)(this.phoneImage)).EndInit();
            this.panelNotification.ResumeLayout(false);
            this.panelNotification.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox phoneImage;
        private System.Windows.Forms.Panel panelNotification;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}
