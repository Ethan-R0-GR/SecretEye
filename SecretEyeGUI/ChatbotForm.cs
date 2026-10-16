namespace SecretEyeGUI
{
    public partial class ChatbotForm : Form
    {
        private readonly VoiceGreeting _voice = new VoiceGreeting();

        private readonly ChatBot _chatBot = new ChatBot();

        public ChatbotForm()
        {
            InitializeComponent();


            _chatBot.OnResponse = DisplayBotResponse;

            Load += ChatbotForm_Load;
        }

        // Runs once when the window opens: shows branding, greets the user, plays the voice.
        private void ChatbotForm_Load(object? sender, EventArgs e)
        {
            rtbBanner.Text = AsciiArt.GetBanner();

            AppendLine("Bot", "Hi! I'm SecretEye, your cybersecurity awareness assistant.");
            AppendLine("Bot", "Tell me your name, or ask about passwords, phishing, scams, safe browsing, 2FA, privacy, malware or social engineering. Type 'exit' to say goodbye.");

            Task.Run(() => _voice.PlayGreeting());

            txtUserInput.Focus();
        }

        private void btnSend_Click(object? sender, EventArgs e) => SendMessage();

        private void txtUserInput_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true; // stops the Windows "ding" sound
                SendMessage();
            }
        }

        private void SendMessage()
        {
            string message = txtUserInput.Text.Trim();

            // Validation: empty input.
            if (string.IsNullOrWhiteSpace(message))
            {
                MessageBox.Show("Please type a message first.", "SecretEye");
                return;
            }

            AppendLine("You", message);

            // Allow the user to end the chat politely, then close the window.
            if (message.ToLower() == "exit")
            {
                AppendLine("Bot", "Goodbye! Stay safe online.");
                txtUserInput.Clear();
                txtUserInput.Enabled = false;
                btnSend.Enabled = false;

                System.Windows.Forms.Timer closeTimer = new System.Windows.Forms.Timer();
                closeTimer.Interval = 1200; // wait 1.2 seconds
                closeTimer.Tick += (s, ev) =>
                {
                    closeTimer.Stop();
                    Close();
                };
                closeTimer.Start();
                return;
            }

            // Ask the response handler for a reply.
            try
            {
                _chatBot.ProcessInput(message);
            }
            catch (Exception)
            {
                AppendLine("Bot", "Sorry, something went wrong handling that. Could you try rephrasing?");
            }

            txtUserInput.Clear();
            txtUserInput.Focus();
        }

        private void DisplayBotResponse(string message)
        {
            AppendLine("Bot", message);
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
