namespace SecretEyeGUI
{
    public partial class ChatbotForm : Form
    {
        public ChatbotForm()
        {
            InitializeComponent();
        }

        // Runs when the user clicks the Send button.
        private void btnSend_Click(object sender, EventArgs e)
        {
            SendMessage();
        }

        // Lets the user press Enter to send instead of clicking Send.
        private void txtUserInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true; // stops the Windows "ding" sound
                SendMessage();
            }
        }

        // Reads the input box, shows the message, and (for now) a placeholder reply.
        // The real chatbot logic is added in the next commit.
        private void SendMessage()
        {
            string message = txtUserInput.Text.Trim();

            if (string.IsNullOrWhiteSpace(message))
            {
                MessageBox.Show("Please type a message first.", "SecretEye");
                return;
            }

            AppendLine("You", message);
            AppendLine("Bot", "add messages here later");

            txtUserInput.Clear();
            txtUserInput.Focus();
        }

        // Adds one line to the chat history, with a coloured speaker label.
        private void AppendLine(string speaker, string text)
        {
            rtbChatHistory.SelectionColor = speaker == "You"
                ? Color.FromArgb(56, 189, 208)   // cyan for the user
                : Color.FromArgb(63, 185, 80);    // green for the bot
            rtbChatHistory.AppendText(speaker + " > ");

            rtbChatHistory.SelectionColor = Color.FromArgb(230, 237, 243); // normal text
            rtbChatHistory.AppendText(text + Environment.NewLine);

            rtbChatHistory.ScrollToCaret();
        }
    }
}
