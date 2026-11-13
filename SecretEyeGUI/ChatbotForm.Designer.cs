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
            tabMain = new TabControl();
            tabChat = new TabPage();
            tabTasks = new TabPage();
            tabQuiz = new TabPage();
            tabActivity = new TabPage();
            tlpRoot = new TableLayoutPanel();
            lblTitle = new Label();
            rtbBanner = new RichTextBox();
            rtbChatHistory = new RichTextBox();
            pnlInput = new Panel();
            txtUserInput = new TextBox();
            btnSend = new Button();
            lblStatus = new Label();
            tlpTasks = new TableLayoutPanel();
            pnlTaskInput = new Panel();
            lblTitleCaption = new Label();
            txtTaskTitle = new TextBox();
            lblDescCaption = new Label();
            txtTaskDescription = new TextBox();
            chkUseReminder = new CheckBox();
            dtpReminder = new DateTimePicker();
            btnAddTask = new Button();
            dgvTasks = new DataGridView();
            pnlTaskButtons = new Panel();
            btnCompleteTask = new Button();
            btnDeleteTask = new Button();
            btnRefreshTasks = new Button();
            lblTaskStatus = new Label();
            lblQuizScore = new Label();
            lblQuestionNumber = new Label();
            lblQuestion = new Label();
            rdoA = new RadioButton();
            rdoB = new RadioButton();
            rdoC = new RadioButton();
            rdoD = new RadioButton();
            lblQuizFeedback = new Label();
            btnStartQuiz = new Button();
            btnSubmitAnswer = new Button();
            btnNextQuestion = new Button();
            tlpActivity = new TableLayoutPanel();
            lblActivityCaption = new Label();
            lstActivity = new ListBox();
            pnlActivityButtons = new Panel();
            btnRefreshActivity = new Button();
            btnShowMore = new Button();
            tabMain.SuspendLayout();
            tabChat.SuspendLayout();
            tabTasks.SuspendLayout();
            tabQuiz.SuspendLayout();
            tabActivity.SuspendLayout();
            tlpRoot.SuspendLayout();
            pnlInput.SuspendLayout();
            tlpTasks.SuspendLayout();
            pnlTaskInput.SuspendLayout();
            pnlTaskButtons.SuspendLayout();
            tlpActivity.SuspendLayout();
            pnlActivityButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTasks).BeginInit();
            SuspendLayout();
            //
            // tabMain  (one tab per feature)
            //
            tabMain.Controls.Add(tabChat);
            tabMain.Controls.Add(tabTasks);
            tabMain.Controls.Add(tabQuiz);
            tabMain.Controls.Add(tabActivity);
            tabMain.Dock = DockStyle.Fill;
            tabMain.Name = "tabMain";
            tabMain.SelectedIndexChanged += tabMain_SelectedIndexChanged;
            //
            // tabChat  (holds the existing chat)
            //
            tabChat.BackColor = Color.FromArgb(13, 17, 23);
            tabChat.Controls.Add(tlpRoot);
            tabChat.Name = "tabChat";
            tabChat.Text = "Chat";
            //
            // tabTasks
            //
            tabTasks.BackColor = Color.FromArgb(13, 17, 23);
            tabTasks.Controls.Add(tlpTasks);
            tabTasks.Name = "tabTasks";
            tabTasks.Text = "Tasks";
            //
            // tabQuiz
            //
            tabQuiz.BackColor = Color.FromArgb(13, 17, 23);
            tabQuiz.Controls.Add(lblQuizScore);
            tabQuiz.Controls.Add(lblQuestionNumber);
            tabQuiz.Controls.Add(lblQuestion);
            tabQuiz.Controls.Add(rdoA);
            tabQuiz.Controls.Add(rdoB);
            tabQuiz.Controls.Add(rdoC);
            tabQuiz.Controls.Add(rdoD);
            tabQuiz.Controls.Add(lblQuizFeedback);
            tabQuiz.Controls.Add(btnStartQuiz);
            tabQuiz.Controls.Add(btnSubmitAnswer);
            tabQuiz.Controls.Add(btnNextQuestion);
            tabQuiz.Name = "tabQuiz";
            tabQuiz.Text = "Quiz";
            //
            // tabActivity
            //
            tabActivity.BackColor = Color.FromArgb(13, 17, 23);
            tabActivity.Controls.Add(tlpActivity);
            tabActivity.Name = "tabActivity";
            tabActivity.Text = "Activity Log";
            //
            // tlpRoot
            //
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
            tlpRoot.RowStyles.Add(new RowStyle(SizeType.Absolute, 230F));
            tlpRoot.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpRoot.RowStyles.Add(new RowStyle(SizeType.Absolute, 48F));
            tlpRoot.RowStyles.Add(new RowStyle(SizeType.Absolute, 26F));
            tlpRoot.Size = new Size(784, 640);
            tlpRoot.TabIndex = 0;
            //
            // lblTitle
            //
            lblTitle.Dock = DockStyle.Fill;
            lblTitle.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(56, 189, 208);
            lblTitle.Location = new Point(15, 12);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(754, 48);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "SecretEye  -  Cybersecurity Awareness Chatbot";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            //
            // rtbBanner
            //
            rtbBanner.BackColor = Color.FromArgb(13, 17, 23);
            rtbBanner.BorderStyle = BorderStyle.None;
            rtbBanner.Dock = DockStyle.Fill;
            rtbBanner.Font = new Font("Consolas", 9F);
            rtbBanner.ForeColor = Color.FromArgb(63, 185, 80);
            rtbBanner.Location = new Point(15, 63);
            rtbBanner.Name = "rtbBanner";
            rtbBanner.ReadOnly = true;
            rtbBanner.Size = new Size(754, 224);
            rtbBanner.TabIndex = 1;
            rtbBanner.TabStop = false;
            rtbBanner.Text = "";
            //
            // rtbChatHistory
            //
            rtbChatHistory.BackColor = Color.FromArgb(22, 27, 34);
            rtbChatHistory.BorderStyle = BorderStyle.None;
            rtbChatHistory.Dock = DockStyle.Fill;
            rtbChatHistory.Font = new Font("Segoe UI", 10.5F);
            rtbChatHistory.ForeColor = Color.FromArgb(230, 237, 243);
            rtbChatHistory.Location = new Point(15, 293);
            rtbChatHistory.Name = "rtbChatHistory";
            rtbChatHistory.ReadOnly = true;
            rtbChatHistory.Size = new Size(754, 258);
            rtbChatHistory.TabIndex = 2;
            rtbChatHistory.TabStop = false;
            rtbChatHistory.Text = "";
            //
            // pnlInput
            //
            pnlInput.BackColor = Color.FromArgb(13, 17, 23);
            pnlInput.Controls.Add(txtUserInput);
            pnlInput.Controls.Add(btnSend);
            pnlInput.Dock = DockStyle.Fill;
            pnlInput.Location = new Point(15, 557);
            pnlInput.Name = "pnlInput";
            pnlInput.Padding = new Padding(0, 6, 0, 6);
            pnlInput.Size = new Size(754, 42);
            pnlInput.TabIndex = 3;
            //
            // txtUserInput
            //
            txtUserInput.BackColor = Color.FromArgb(33, 38, 45);
            txtUserInput.BorderStyle = BorderStyle.FixedSingle;
            txtUserInput.Dock = DockStyle.Fill;
            txtUserInput.Font = new Font("Segoe UI", 11F);
            txtUserInput.ForeColor = Color.FromArgb(230, 237, 243);
            txtUserInput.Location = new Point(0, 6);
            txtUserInput.Name = "txtUserInput";
            txtUserInput.Size = new Size(644, 27);
            txtUserInput.TabIndex = 0;
            txtUserInput.KeyDown += txtUserInput_KeyDown;
            //
            // btnSend
            //
            btnSend.BackColor = Color.FromArgb(35, 134, 54);
            btnSend.Dock = DockStyle.Right;
            btnSend.FlatStyle = FlatStyle.Flat;
            btnSend.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSend.ForeColor = Color.White;
            btnSend.Location = new Point(644, 6);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(110, 30);
            btnSend.TabIndex = 1;
            btnSend.Text = "Send";
            btnSend.UseVisualStyleBackColor = false;
            btnSend.Click += btnSend_Click;
            //
            // lblStatus
            //
            lblStatus.Dock = DockStyle.Fill;
            lblStatus.Font = new Font("Segoe UI", 9F);
            lblStatus.ForeColor = Color.FromArgb(139, 148, 158);
            lblStatus.Location = new Point(15, 602);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(754, 26);
            lblStatus.TabIndex = 4;
            lblStatus.Text = "Ask me about passwords, phishing, scams, safe browsing, 2FA or privacy.";
            lblStatus.TextAlign = ContentAlignment.MiddleLeft;
            //
            // tlpTasks  (Tasks tab layout: inputs / grid / buttons / status)
            //
            tlpTasks.ColumnCount = 1;
            tlpTasks.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpTasks.Controls.Add(pnlTaskInput, 0, 0);
            tlpTasks.Controls.Add(dgvTasks, 0, 1);
            tlpTasks.Controls.Add(pnlTaskButtons, 0, 2);
            tlpTasks.Controls.Add(lblTaskStatus, 0, 3);
            tlpTasks.Dock = DockStyle.Fill;
            tlpTasks.Name = "tlpTasks";
            tlpTasks.Padding = new Padding(10);
            tlpTasks.RowCount = 4;
            tlpTasks.RowStyles.Add(new RowStyle(SizeType.Absolute, 170F));
            tlpTasks.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpTasks.RowStyles.Add(new RowStyle(SizeType.Absolute, 48F));
            tlpTasks.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
            //
            // pnlTaskInput
            //
            pnlTaskInput.Controls.Add(lblTitleCaption);
            pnlTaskInput.Controls.Add(txtTaskTitle);
            pnlTaskInput.Controls.Add(lblDescCaption);
            pnlTaskInput.Controls.Add(txtTaskDescription);
            pnlTaskInput.Controls.Add(chkUseReminder);
            pnlTaskInput.Controls.Add(dtpReminder);
            pnlTaskInput.Controls.Add(btnAddTask);
            pnlTaskInput.Dock = DockStyle.Fill;
            pnlTaskInput.Name = "pnlTaskInput";
            //
            // lblTitleCaption
            //
            lblTitleCaption.AutoSize = true;
            lblTitleCaption.ForeColor = Color.FromArgb(230, 237, 243);
            lblTitleCaption.Location = new Point(3, 12);
            lblTitleCaption.Name = "lblTitleCaption";
            lblTitleCaption.Text = "Task title:";
            //
            // txtTaskTitle
            //
            txtTaskTitle.BackColor = Color.FromArgb(33, 38, 45);
            txtTaskTitle.BorderStyle = BorderStyle.FixedSingle;
            txtTaskTitle.ForeColor = Color.FromArgb(230, 237, 243);
            txtTaskTitle.Location = new Point(120, 9);
            txtTaskTitle.Name = "txtTaskTitle";
            txtTaskTitle.Size = new Size(480, 27);
            //
            // lblDescCaption
            //
            lblDescCaption.AutoSize = true;
            lblDescCaption.ForeColor = Color.FromArgb(230, 237, 243);
            lblDescCaption.Location = new Point(3, 48);
            lblDescCaption.Name = "lblDescCaption";
            lblDescCaption.Text = "Description:";
            //
            // txtTaskDescription
            //
            txtTaskDescription.BackColor = Color.FromArgb(33, 38, 45);
            txtTaskDescription.BorderStyle = BorderStyle.FixedSingle;
            txtTaskDescription.ForeColor = Color.FromArgb(230, 237, 243);
            txtTaskDescription.Location = new Point(120, 45);
            txtTaskDescription.Multiline = true;
            txtTaskDescription.Name = "txtTaskDescription";
            txtTaskDescription.Size = new Size(480, 55);
            //
            // chkUseReminder
            //
            chkUseReminder.AutoSize = true;
            chkUseReminder.ForeColor = Color.FromArgb(230, 237, 243);
            chkUseReminder.Location = new Point(3, 115);
            chkUseReminder.Name = "chkUseReminder";
            chkUseReminder.Text = "Set reminder";
            //
            // dtpReminder
            //
            dtpReminder.Format = DateTimePickerFormat.Short;
            dtpReminder.Location = new Point(120, 112);
            dtpReminder.Name = "dtpReminder";
            dtpReminder.Size = new Size(220, 27);
            //
            // btnAddTask
            //
            btnAddTask.BackColor = Color.FromArgb(35, 134, 54);
            btnAddTask.FlatStyle = FlatStyle.Flat;
            btnAddTask.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnAddTask.ForeColor = Color.White;
            btnAddTask.Location = new Point(360, 110);
            btnAddTask.Name = "btnAddTask";
            btnAddTask.Size = new Size(120, 32);
            btnAddTask.Text = "Add Task";
            btnAddTask.UseVisualStyleBackColor = false;
            btnAddTask.Click += btnAddTask_Click;
            //
            // dgvTasks
            //
            dgvTasks.AllowUserToAddRows = false;
            dgvTasks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTasks.BackgroundColor = Color.FromArgb(22, 27, 34);
            dgvTasks.BorderStyle = BorderStyle.None;
            dgvTasks.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(33, 38, 45);
            dgvTasks.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(230, 237, 243);
            dgvTasks.DefaultCellStyle.BackColor = Color.FromArgb(22, 27, 34);
            dgvTasks.DefaultCellStyle.ForeColor = Color.FromArgb(230, 237, 243);
            dgvTasks.DefaultCellStyle.SelectionBackColor = Color.FromArgb(35, 134, 54);
            dgvTasks.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvTasks.Dock = DockStyle.Fill;
            dgvTasks.EnableHeadersVisualStyles = false;
            dgvTasks.GridColor = Color.FromArgb(48, 54, 61);
            dgvTasks.Name = "dgvTasks";
            dgvTasks.ReadOnly = true;
            dgvTasks.RowHeadersVisible = false;
            dgvTasks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //
            // pnlTaskButtons
            //
            pnlTaskButtons.Controls.Add(btnCompleteTask);
            pnlTaskButtons.Controls.Add(btnDeleteTask);
            pnlTaskButtons.Controls.Add(btnRefreshTasks);
            pnlTaskButtons.Dock = DockStyle.Fill;
            pnlTaskButtons.Name = "pnlTaskButtons";
            //
            // btnCompleteTask
            //
            btnCompleteTask.BackColor = Color.FromArgb(35, 134, 54);
            btnCompleteTask.FlatStyle = FlatStyle.Flat;
            btnCompleteTask.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnCompleteTask.ForeColor = Color.White;
            btnCompleteTask.Location = new Point(0, 8);
            btnCompleteTask.Name = "btnCompleteTask";
            btnCompleteTask.Size = new Size(150, 32);
            btnCompleteTask.Text = "Mark Complete";
            btnCompleteTask.UseVisualStyleBackColor = false;
            btnCompleteTask.Click += btnCompleteTask_Click;
            //
            // btnDeleteTask
            //
            btnDeleteTask.BackColor = Color.FromArgb(35, 134, 54);
            btnDeleteTask.FlatStyle = FlatStyle.Flat;
            btnDeleteTask.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnDeleteTask.ForeColor = Color.White;
            btnDeleteTask.Location = new Point(160, 8);
            btnDeleteTask.Name = "btnDeleteTask";
            btnDeleteTask.Size = new Size(120, 32);
            btnDeleteTask.Text = "Delete";
            btnDeleteTask.UseVisualStyleBackColor = false;
            btnDeleteTask.Click += btnDeleteTask_Click;
            //
            // btnRefreshTasks
            //
            btnRefreshTasks.BackColor = Color.FromArgb(35, 134, 54);
            btnRefreshTasks.FlatStyle = FlatStyle.Flat;
            btnRefreshTasks.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnRefreshTasks.ForeColor = Color.White;
            btnRefreshTasks.Location = new Point(290, 8);
            btnRefreshTasks.Name = "btnRefreshTasks";
            btnRefreshTasks.Size = new Size(120, 32);
            btnRefreshTasks.Text = "Refresh";
            btnRefreshTasks.UseVisualStyleBackColor = false;
            btnRefreshTasks.Click += btnRefreshTasks_Click;
            //
            // lblTaskStatus
            //
            lblTaskStatus.Dock = DockStyle.Fill;
            lblTaskStatus.ForeColor = Color.FromArgb(139, 148, 158);
            lblTaskStatus.Name = "lblTaskStatus";
            lblTaskStatus.TextAlign = ContentAlignment.MiddleLeft;
            //
            // lblQuizScore
            //
            lblQuizScore.AutoSize = true;
            lblQuizScore.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblQuizScore.ForeColor = Color.FromArgb(230, 237, 243);
            lblQuizScore.Location = new Point(20, 15);
            lblQuizScore.Name = "lblQuizScore";
            lblQuizScore.Text = "Score: 0";
            //
            // lblQuestionNumber
            //
            lblQuestionNumber.AutoSize = true;
            lblQuestionNumber.ForeColor = Color.FromArgb(139, 148, 158);
            lblQuestionNumber.Location = new Point(20, 45);
            lblQuestionNumber.Name = "lblQuestionNumber";
            lblQuestionNumber.Text = "Press Start Quiz to begin.";
            //
            // lblQuestion
            //
            lblQuestion.ForeColor = Color.FromArgb(230, 237, 243);
            lblQuestion.Font = new Font("Segoe UI", 11F);
            lblQuestion.Location = new Point(20, 80);
            lblQuestion.Name = "lblQuestion";
            lblQuestion.Size = new Size(720, 55);
            lblQuestion.Text = "";
            //
            // rdoA
            //
            rdoA.AutoSize = true;
            rdoA.ForeColor = Color.FromArgb(230, 237, 243);
            rdoA.Location = new Point(40, 150);
            rdoA.Name = "rdoA";
            rdoA.Visible = false;
            //
            // rdoB
            //
            rdoB.AutoSize = true;
            rdoB.ForeColor = Color.FromArgb(230, 237, 243);
            rdoB.Location = new Point(40, 185);
            rdoB.Name = "rdoB";
            rdoB.Visible = false;
            //
            // rdoC
            //
            rdoC.AutoSize = true;
            rdoC.ForeColor = Color.FromArgb(230, 237, 243);
            rdoC.Location = new Point(40, 220);
            rdoC.Name = "rdoC";
            rdoC.Visible = false;
            //
            // rdoD
            //
            rdoD.AutoSize = true;
            rdoD.ForeColor = Color.FromArgb(230, 237, 243);
            rdoD.Location = new Point(40, 255);
            rdoD.Name = "rdoD";
            rdoD.Visible = false;
            //
            // lblQuizFeedback
            //
            lblQuizFeedback.ForeColor = Color.FromArgb(56, 189, 208);
            lblQuizFeedback.Location = new Point(20, 300);
            lblQuizFeedback.Name = "lblQuizFeedback";
            lblQuizFeedback.Size = new Size(720, 70);
            lblQuizFeedback.Text = "";
            //
            // btnStartQuiz
            //
            btnStartQuiz.BackColor = Color.FromArgb(35, 134, 54);
            btnStartQuiz.FlatStyle = FlatStyle.Flat;
            btnStartQuiz.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnStartQuiz.ForeColor = Color.White;
            btnStartQuiz.Location = new Point(20, 390);
            btnStartQuiz.Name = "btnStartQuiz";
            btnStartQuiz.Size = new Size(120, 34);
            btnStartQuiz.Text = "Start Quiz";
            btnStartQuiz.UseVisualStyleBackColor = false;
            btnStartQuiz.Click += btnStartQuiz_Click;
            //
            // btnSubmitAnswer
            //
            btnSubmitAnswer.BackColor = Color.FromArgb(35, 134, 54);
            btnSubmitAnswer.Enabled = false;
            btnSubmitAnswer.FlatStyle = FlatStyle.Flat;
            btnSubmitAnswer.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnSubmitAnswer.ForeColor = Color.White;
            btnSubmitAnswer.Location = new Point(150, 390);
            btnSubmitAnswer.Name = "btnSubmitAnswer";
            btnSubmitAnswer.Size = new Size(140, 34);
            btnSubmitAnswer.Text = "Submit Answer";
            btnSubmitAnswer.UseVisualStyleBackColor = false;
            btnSubmitAnswer.Click += btnSubmitAnswer_Click;
            //
            // btnNextQuestion
            //
            btnNextQuestion.BackColor = Color.FromArgb(35, 134, 54);
            btnNextQuestion.Enabled = false;
            btnNextQuestion.FlatStyle = FlatStyle.Flat;
            btnNextQuestion.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnNextQuestion.ForeColor = Color.White;
            btnNextQuestion.Location = new Point(300, 390);
            btnNextQuestion.Name = "btnNextQuestion";
            btnNextQuestion.Size = new Size(140, 34);
            btnNextQuestion.Text = "Next Question";
            btnNextQuestion.UseVisualStyleBackColor = false;
            btnNextQuestion.Click += btnNextQuestion_Click;
            //
            // tlpActivity  (Activity tab layout: caption / list / buttons)
            //
            tlpActivity.ColumnCount = 1;
            tlpActivity.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpActivity.Controls.Add(lblActivityCaption, 0, 0);
            tlpActivity.Controls.Add(lstActivity, 0, 1);
            tlpActivity.Controls.Add(pnlActivityButtons, 0, 2);
            tlpActivity.Dock = DockStyle.Fill;
            tlpActivity.Name = "tlpActivity";
            tlpActivity.Padding = new Padding(10);
            tlpActivity.RowCount = 3;
            tlpActivity.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tlpActivity.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpActivity.RowStyles.Add(new RowStyle(SizeType.Absolute, 48F));
            //
            // lblActivityCaption
            //
            lblActivityCaption.Dock = DockStyle.Fill;
            lblActivityCaption.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblActivityCaption.ForeColor = Color.FromArgb(230, 237, 243);
            lblActivityCaption.Name = "lblActivityCaption";
            lblActivityCaption.Text = "Recent activity (newest first)";
            lblActivityCaption.TextAlign = ContentAlignment.MiddleLeft;
            //
            // lstActivity
            //
            lstActivity.BackColor = Color.FromArgb(22, 27, 34);
            lstActivity.BorderStyle = BorderStyle.None;
            lstActivity.Dock = DockStyle.Fill;
            lstActivity.Font = new Font("Segoe UI", 10F);
            lstActivity.ForeColor = Color.FromArgb(230, 237, 243);
            lstActivity.ItemHeight = 20;
            lstActivity.Name = "lstActivity";
            //
            // pnlActivityButtons
            //
            pnlActivityButtons.Controls.Add(btnRefreshActivity);
            pnlActivityButtons.Controls.Add(btnShowMore);
            pnlActivityButtons.Dock = DockStyle.Fill;
            pnlActivityButtons.Name = "pnlActivityButtons";
            //
            // btnRefreshActivity
            //
            btnRefreshActivity.BackColor = Color.FromArgb(35, 134, 54);
            btnRefreshActivity.FlatStyle = FlatStyle.Flat;
            btnRefreshActivity.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnRefreshActivity.ForeColor = Color.White;
            btnRefreshActivity.Location = new Point(0, 8);
            btnRefreshActivity.Name = "btnRefreshActivity";
            btnRefreshActivity.Size = new Size(120, 32);
            btnRefreshActivity.Text = "Refresh";
            btnRefreshActivity.UseVisualStyleBackColor = false;
            btnRefreshActivity.Click += btnRefreshActivity_Click;
            //
            // btnShowMore
            //
            btnShowMore.BackColor = Color.FromArgb(35, 134, 54);
            btnShowMore.FlatStyle = FlatStyle.Flat;
            btnShowMore.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnShowMore.ForeColor = Color.White;
            btnShowMore.Location = new Point(130, 8);
            btnShowMore.Name = "btnShowMore";
            btnShowMore.Size = new Size(120, 32);
            btnShowMore.Text = "Show More";
            btnShowMore.UseVisualStyleBackColor = false;
            btnShowMore.Click += btnShowMore_Click;
            //
            // ChatbotForm
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(13, 17, 23);
            ClientSize = new Size(784, 640);
            Controls.Add(tabMain);
            MinimumSize = new Size(640, 520);
            Name = "ChatbotForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cybersecurity Awareness Chatbot - SecretEye";
            tabMain.ResumeLayout(false);
            tabChat.ResumeLayout(false);
            tabTasks.ResumeLayout(false);
            tabQuiz.ResumeLayout(false);
            tabQuiz.PerformLayout();
            tabActivity.ResumeLayout(false);
            tlpRoot.ResumeLayout(false);
            pnlInput.ResumeLayout(false);
            pnlInput.PerformLayout();
            tlpTasks.ResumeLayout(false);
            pnlTaskInput.ResumeLayout(false);
            pnlTaskInput.PerformLayout();
            pnlTaskButtons.ResumeLayout(false);
            tlpActivity.ResumeLayout(false);
            pnlActivityButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvTasks).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabMain;
        private TabPage tabChat;
        private TabPage tabTasks;
        private TabPage tabQuiz;
        private TabPage tabActivity;
        private TableLayoutPanel tlpRoot;
        private Label lblTitle;
        private RichTextBox rtbBanner;
        private RichTextBox rtbChatHistory;
        private Panel pnlInput;
        private TextBox txtUserInput;
        private Button btnSend;
        private Label lblStatus;
        private TableLayoutPanel tlpTasks;
        private Panel pnlTaskInput;
        private Label lblTitleCaption;
        private TextBox txtTaskTitle;
        private Label lblDescCaption;
        private TextBox txtTaskDescription;
        private CheckBox chkUseReminder;
        private DateTimePicker dtpReminder;
        private Button btnAddTask;
        private DataGridView dgvTasks;
        private Panel pnlTaskButtons;
        private Button btnCompleteTask;
        private Button btnDeleteTask;
        private Button btnRefreshTasks;
        private Label lblTaskStatus;
        private Label lblQuizScore;
        private Label lblQuestionNumber;
        private Label lblQuestion;
        private RadioButton rdoA;
        private RadioButton rdoB;
        private RadioButton rdoC;
        private RadioButton rdoD;
        private Label lblQuizFeedback;
        private Button btnStartQuiz;
        private Button btnSubmitAnswer;
        private Button btnNextQuestion;
        private TableLayoutPanel tlpActivity;
        private Label lblActivityCaption;
        private ListBox lstActivity;
        private Panel pnlActivityButtons;
        private Button btnRefreshActivity;
        private Button btnShowMore;
    }
}
