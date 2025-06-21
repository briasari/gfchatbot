namespace gfchatbot
{
    partial class ChatScreen
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
            this.txtInput = new System.Windows.Forms.TextBox();
            this.pnlChat = new System.Windows.Forms.Panel();
            this.btnSendPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(40, 886);
            this.txtInput.Multiline = true;
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(473, 55);
            this.txtInput.TabIndex = 1;
            // 
            // pnlChat
            // 
            this.pnlChat.BackColor = System.Drawing.SystemColors.MenuBar;
            this.pnlChat.Location = new System.Drawing.Point(40, 36);
            this.pnlChat.Name = "pnlChat";
            this.pnlChat.Size = new System.Drawing.Size(549, 835);
            this.pnlChat.TabIndex = 3;
            // 
            // btnSendPanel
            // 
            this.btnSendPanel.BackColor = System.Drawing.Color.Transparent;
            this.btnSendPanel.BackgroundImage = global::gfchatbot.Properties.Resources.sendImage;
            this.btnSendPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSendPanel.Location = new System.Drawing.Point(531, 886);
            this.btnSendPanel.Name = "btnSendPanel";
            this.btnSendPanel.Size = new System.Drawing.Size(58, 55);
            this.btnSendPanel.TabIndex = 2;
            this.btnSendPanel.Click += new System.EventHandler(this.btnSendPanel_Click);
            // 
            // ChatScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.Controls.Add(this.pnlChat);
            this.Controls.Add(this.btnSendPanel);
            this.Controls.Add(this.txtInput);
            this.Name = "ChatScreen";
            this.Size = new System.Drawing.Size(616, 966);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Panel btnSendPanel;
        private System.Windows.Forms.Panel pnlChat;
    }
}
