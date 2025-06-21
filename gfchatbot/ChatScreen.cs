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
    public partial class ChatScreen : UserControl
    {
        public ChatScreen()
        {
            InitializeComponent();

            pnlChat.AutoScroll = true; //can scroll up to see messages

            //if no message sent yet
            if (GameData.CurrentSave.ChatHistory.Count == 0)
            {
                Random rnd = new Random();
                int i = rnd.Next(conflictScenarios.Count);
                GameData.CurrentSave.ChatHistory.Add(conflictScenarios[i]);
                GameData.SaveGame();
            }

            RefreshChatHistory();
        }

        private int verticalOffset = 10;

        int anger = GameData.CurrentSave.AngerLevel;
        int scenario = GameData.CurrentSave.ScenarioIndex;
        private void AddChatBubble(string message, bool isFromGF)
        {
            Label bubble = new Label();
            bubble.MaximumSize = new Size(300, 0);
            bubble.AutoSize = true;
            bubble.Text = message;
            bubble.Font = new Font("Segoe UI", 10);
            bubble.Padding = new Padding(10);
            bubble.BackColor = isFromGF ? Color.LightBlue : Color.LightGreen;
            bubble.ForeColor = Color.Black;
            bubble.MinimumSize = new Size(50, 30);

            Panel bubbleContainer = new Panel();
            bubbleContainer.Width = pnlChat.ClientSize.Width;  //set width first
            bubbleContainer.AutoSize = true;

            bubbleContainer.Controls.Add(bubble);

            //align bubbles: GF left, player right
            int xPosition = isFromGF ? 10 : bubbleContainer.Width - bubble.Width - 30;
            bubble.Location = new Point(xPosition, 0);

            bubbleContainer.Height = bubble.Height + 10;

            bubbleContainer.Location = new Point(0, verticalOffset);
            pnlChat.Controls.Add(bubbleContainer);

            verticalOffset += bubbleContainer.Height + 5;
        }


        private void RefreshChatHistory()
        {
            pnlChat.Controls.Clear();
            verticalOffset = 10;

            foreach (var line in GameData.CurrentSave.ChatHistory)
            {
                bool isFromGF = line.StartsWith("GF:");
                AddChatBubble(line, isFromGF);
            }

            ScrollToBottom();
        }

        private void ScrollToBottom()
        {
            pnlChat.VerticalScroll.Value = pnlChat.VerticalScroll.Maximum;
            pnlChat.PerformLayout();
        }

        private List<string> conflictScenarios = new List<string>
        {
            "GF: you forgot our anniversary. again.",
            "GF: are you seriously skipping dinner with my sister?? grow up.",
            "GF: why did i have to hear from sam that you called me clingy behind my back?"
        };

        private void SendMessage(string userMessage)
        {
            // Add player message to chat history
            GameData.CurrentSave.ChatHistory.Add("You: " + userMessage);
            AddChatBubble(userMessage, false);

            string botResponse = ConversationManager.ProcessMessage(userMessage);

            if (botResponse.StartsWith("[BLOCKED]"))
            {
                AddChatBubble(botResponse.Replace("[BLOCKED]", ""), true);
                MessageBox.Show("You’ve been blocked. Restart to try again.");
                GameData.DeleteSave(GameData.CurrentSave.PlayerName);

                // Prompt to restart
                var result = MessageBox.Show("Do you want to start a new game?", "Game Over", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    GameData.StartNewGame(GameData.CurrentSave.PlayerName);
                    Form1.ChangeScreen(this, new ChatScreen());
                }
                else
                {
                    Application.Exit();
                }
                return;
            }

            if (botResponse.StartsWith("[GOOD ENDING]"))
            {
                botResponse = botResponse.Replace("[GOOD ENDING]", "");
                GameData.CurrentSave.ChatHistory.Add("GF: " + botResponse);
                AddChatBubble(botResponse, true);

                GameData.SaveGame();
                MessageBox.Show("You reached a good ending! She forgave you.");

                // Prompt to restart
                var result = MessageBox.Show("Do you want to start a new game?", "Game Completed", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    GameData.StartNewGame(GameData.CurrentSave.PlayerName);
                    Form1.ChangeScreen(this, new ChatScreen());
                }
                else
                {
                    Application.Exit();
                }
                return;
            }

            GameData.CurrentSave.ChatHistory.Add("GF: " + botResponse);
            AddChatBubble(botResponse, true);

            GameData.SaveGame();

            ScrollToBottom();
        }



        private void btnSend_Click(object sender, EventArgs e)
        {
            string message = txtInput.Text.Trim();
            if (string.IsNullOrEmpty(message))
                return;

            //add player message to chat history
            GameData.CurrentSave.ChatHistory.Add("You: " + message);

            //save to XML
            GameData.SaveGame();

            //refresh chat display and clear input
            RefreshChatHistory();
            txtInput.Clear();
        }

        private void btnSendPanel_Click(object sender, EventArgs e)
        {
            string message = txtInput.Text.Trim();
            if (string.IsNullOrEmpty(message)) return;

            SendMessage(message);

            txtInput.Clear();
        }
    }
}
