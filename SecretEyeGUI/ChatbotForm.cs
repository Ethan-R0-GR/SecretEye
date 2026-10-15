namespace SecretEyeGUI
{
    public partial class ChatbotForm : Form
    {
        // Each helper class has one job (the same idea as in Part 1).
        private readonly VoiceGreeting _voice = new VoiceGreeting();
        private readonly ResponseHandler _responder = new ResponseHandler();
        private readonly UserProfile _user = new UserProfile();

        public ChatbotForm()
        {
            InitializeComponent();
            Load += ChatbotForm_Load;
        }

        // Runs when the user clicks the Send button.
        private void ChatbotForm_Load(object? sender, EventArgs e)
        {
            // Part 1 ASCII branding, shown in the banner area.
            rtbBanner.Text = AsciiArt.GetBanner();

            // Friendly on-screen welcome.
            AppendLine("Bot", "Hi! I'm SecretEye, your cybersecurity awareness assistant.");
            AppendLine("Bot", "Ask me about passwords, phishing, scams, safe browsing, 2FA or privacy. Type 'exit' to say goodbye.");

            // Play the recorded voice greeting on a background thread so the window
            // appears immediately instead of freezing while the audio plays.
            Task.Run(() => _voice.PlayGreeting());

            txtUserInput.Focus();
        }

        private void btnSend_Click(object? sender, EventArgs e) => SendMessage();

        // Lets the user press Enter to send instead of clicking Send.
        private void txtUserInput_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true; // stops the Windows "ding" sound
                SendMessage();
            }
        }

        // Reads the input box, shows the message, and displays the chatbot's reply.
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

            // Allow the user to end the chat politely.
            if (message.ToLower() == "exit")
            {
                AppendLine("Bot", "Goodbye! Stay safe online.");
                txtUserInput.Clear();
                return;
            }

            // Ask the response handler (the Part 1 logic) for a reply.
            string reply = _responder.GetResponse(message, _user);
            AppendLine("Bot", reply);

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
