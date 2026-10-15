namespace SecretEyeGUI
{
    partial class ChatbotForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            tlpRoot = new TableLayoutPanel();

            lblTitle = new Label();
            rtbBanner = new RichTextBox();
            rtbChatHistory = new RichTextBox();
            pnlInput = new Panel();

            txtUserInput = new TextBox();
            btnSend = new Button();
            lblStatus = new Label();
            tlpRoot.SuspendLayout();
            pnlInput.SuspendLayout();
            SuspendLayout();
 
            tlpRoot.BackColor = Color.FromArgb(13, 17, 23);
            tlpRoot.ColumnCount = 1;
            tlpRoot.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpRoot.Controls.Add(lblTitle, 0, 0);
            tlpRoot.Controls.Add(rtbBanner, 0, 1);
            tlpRoot.Controls.Add(rtbChatHistory, 0, 2);
            tlpRoot.Controls.Add(pnlInput, 0, 3);
            tlpRoot.Controls.Add(lblStatus, 0, 4);
            tlpRoot.Dock = DockStyle.Fill;
            tlpRoot.Location = new Point(0, 0);
            tlpRoot.Name = "tlpRoot";
            tlpRoot.Padding = new Padding(12);
            tlpRoot.RowCount = 5;
            tlpRoot.RowStyles.Add(new RowStyle(SizeType.Absolute, 48F));
            tlpRoot.RowStyles.Add(new RowStyle(SizeType.Absolute, 180F));
            tlpRoot.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpRoot.RowStyles.Add(new RowStyle(SizeType.Absolute, 48F));
            tlpRoot.RowStyles.Add(new RowStyle(SizeType.Absolute, 26F));
            tlpRoot.TabIndex = 0;
   
            // lblTitle
          
            lblTitle.Dock = DockStyle.Fill;
            lblTitle.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(56, 189, 208);
            lblTitle.Name = "lblTitle";
            lblTitle.Text = "SecretEye  -  Cybersecurity Awareness Chatbot";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
          
            // rtbBanner  (ASCII art needs to be added here later)
           
            rtbBanner.BackColor = Color.FromArgb(13, 17, 23);
            rtbBanner.BorderStyle = BorderStyle.None;
            rtbBanner.Dock = DockStyle.Fill;
            rtbBanner.Font = new Font("Consolas", 9F);
            rtbBanner.ForeColor = Color.FromArgb(63, 185, 80);
            rtbBanner.Name = "rtbBanner";
            rtbBanner.ReadOnly = true;
            rtbBanner.TabStop = false;
    
            // rtbChatHistory  the chat area
            
            rtbChatHistory.BackColor = Color.FromArgb(22, 27, 34);
            rtbChatHistory.BorderStyle = BorderStyle.None;
            rtbChatHistory.Dock = DockStyle.Fill;
            rtbChatHistory.Font = new Font("Segoe UI", 10.5F);
            rtbChatHistory.ForeColor = Color.FromArgb(230, 237, 243);
            rtbChatHistory.Name = "rtbChatHistory";
            rtbChatHistory.ReadOnly = true;
            rtbChatHistory.TabStop = false;
            
            // pnlInput  (holds the textbox and Send button)
            
            pnlInput.BackColor = Color.FromArgb(13, 17, 23);
            pnlInput.Controls.Add(txtUserInput);
            pnlInput.Controls.Add(btnSend);
            pnlInput.Dock = DockStyle.Fill;
            pnlInput.Name = "pnlInput";
            pnlInput.Padding = new Padding(0, 6, 0, 6);
            
            // txtUserInput
            
            txtUserInput.BackColor = Color.FromArgb(33, 38, 45);
            txtUserInput.BorderStyle = BorderStyle.FixedSingle;
            txtUserInput.Dock = DockStyle.Fill;
            txtUserInput.Font = new Font("Segoe UI", 11F);
            txtUserInput.ForeColor = Color.FromArgb(230, 237, 243);
            txtUserInput.Name = "txtUserInput";
            txtUserInput.KeyDown += txtUserInput_KeyDown;
            
            // btnSend
            
            btnSend.BackColor = Color.FromArgb(35, 134, 54);
            btnSend.Dock = DockStyle.Right;
            btnSend.FlatStyle = FlatStyle.Flat;
            btnSend.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSend.ForeColor = Color.White;
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(110, 36);
            btnSend.Text = "Send";
            btnSend.UseVisualStyleBackColor = false;
            btnSend.Click += btnSend_Click;
            
            // lblStatus
            
            lblStatus.Dock = DockStyle.Fill;
            lblStatus.Font = new Font("Segoe UI", 9F);
            lblStatus.ForeColor = Color.FromArgb(139, 148, 158);
            lblStatus.Name = "lblStatus";
            lblStatus.Text = "Ask me about passwords, phishing, scams, safe browsing, 2FA or privacy.";
            lblStatus.TextAlign = ContentAlignment.MiddleLeft;
            
            // ChatbotForm
            
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(13, 17, 23);
            ClientSize = new Size(784, 561);
            Controls.Add(tlpRoot);
            MinimumSize = new Size(640, 480);
            Name = "ChatbotForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cybersecurity Awareness Chatbot - SecretEye";
            tlpRoot.ResumeLayout(false);
            pnlInput.ResumeLayout(false);
            pnlInput.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tlpRoot;
        private Label lblTitle;
        private RichTextBox rtbBanner;
        private RichTextBox rtbChatHistory;
        private Panel pnlInput;
        private TextBox txtUserInput;
        private Button btnSend;
        private Label lblStatus;
    }
}
