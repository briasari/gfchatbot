using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gfchatbot
{
    public partial class MenuScreen : UserControl
    {
        private Timer delayTimer;
        public MenuScreen()
        {
            InitializeComponent(); panelNotification.Visible = false;

            delayTimer = new Timer();
            delayTimer.Interval = 2000; //delay is 2 seconds
            delayTimer.Tick += DelayTimer_Tick;
            delayTimer.Start();

            panelNotification.Click += PanelNotification_Click;

            foreach (Control c in this.Controls)
            {
                if (c is Panel && c.BackColor == Color.Transparent)
                {
                    c.Parent = phoneImage;
                    c.Location = phoneImage.PointToClient(c.PointToScreen(Point.Empty));
                }
            }

        }

        private void DelayTimer_Tick(object sender, EventArgs e)
        {
            delayTimer.Stop();
            phoneImage.BackgroundImage = Properties.Resources.phoneOnImage;
            panelNotification.Visible = true;
        }

        private void PanelNotification_Click(object sender, EventArgs e)
        {
            Form1.ChangeScreen(this, new PasswordScreen()); //password screen
        }

        private void phoneImage_Click(object sender, EventArgs e)
        {

        }
    }
}
