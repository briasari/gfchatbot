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
    public partial class PasswordScreen : UserControl
    {
        public PasswordScreen()
        {
            InitializeComponent();

            foreach (Control c in this.Controls)
            {
                if (c is Panel && c.BackColor == Color.Transparent)
                {
                    c.Parent = phoneImage;
                    c.Location = phoneImage.PointToClient(c.PointToScreen(Point.Empty));
                }
            }

            foreach (Control c in this.Controls)
            {
                if (c is Label && c.BackColor == Color.Transparent)
                {
                    c.Parent = phoneImage;
                    c.Location = phoneImage.PointToClient(c.PointToScreen(Point.Empty));
                }
            }
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Button clicked!");

            string playerName = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(playerName))
            {
                MessageBox.Show("Please enter your password (name).");
                return;
            }

            if (GameData.SaveExists(playerName))
            {
                var result = MessageBox.Show(
                    $"A save already exists for '{playerName}'.\nLoad it? (Yes = Load, No = Delete & New, Cancel = Do Nothing)",
                    "Save Found",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        GameData.LoadGame(playerName);
                        Form1.ChangeScreen(this, new ChatScreen());
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed to load save: " + ex.Message);
                    }
                }
                else if (result == DialogResult.No)
                {
                    GameData.DeleteSave(playerName);
                    GameData.StartNewGame(playerName);
                    Form1.ChangeScreen(this, new ChatScreen());
                }
                // Cancel does nothing
            }
            else
            {
                GameData.StartNewGame(playerName);
                Form1.ChangeScreen(this, new ChatScreen());
            }
        }
    }
}