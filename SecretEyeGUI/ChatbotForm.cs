namespace SecretEyeGUI
{
    public partial class ChatbotForm : Form
    {
        private readonly VoiceGreeting _voice = new VoiceGreeting();
        private readonly MemoryStore _memory = new MemoryStore();
        private readonly ResponseHandler _responder;

        public ChatbotForm()
        {
            InitializeComponent();

            // what the user tells the bot is remembered.
            _responder = new ResponseHandler(_memory);

            Load += ChatbotForm_Load;
        }

        // Runs once when the window opens: shows branding, greets the user, plays the voice.
        private void ChatbotForm_Load(object? sender, EventArgs e)
        {
            // Part 1 ASCII branding, shown in the banner area.
            rtbBanner.Text = AsciiArt.GetBanner();

            // Friendly on-screen welcome.
            AppendLine("Bot", "Hi! I'm SecretEye, your cybersecurity awareness assistant.");
            AppendLine("Bot", "Tell me your name, or ask about passwords, phishing, scams, safe browsing, 2FA, privacy, malware or social engineering. Type 'exit' to say goodbye.");

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

            // Allow the user to end the chat politely, then close the window.
            if (message.ToLower() == "exit")
            {
                AppendLine("Bot", "Goodbye! Stay safe online.");
                txtUserInput.Clear();

                // Lock input and close shortly after, so the goodbye is visible before the window disappears.
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
            string reply = _responder.GetResponse(message);
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
