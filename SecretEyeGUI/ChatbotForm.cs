namespace SecretEyeGUI
{
    public partial class ChatbotForm : Form
    {
        private readonly VoiceGreeting _voice = new VoiceGreeting();

        private readonly ChatBot _chatBot = new ChatBot();

        private readonly TaskRepository _taskRepository = new TaskRepository();
        private readonly ActivityLogger _activityLogger = new ActivityLogger();

        private readonly QuizManager _quiz = new QuizManager();

        private readonly NlpProcessor _nlp = new NlpProcessor();

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

            LoadTasks();

            txtUserInput.Focus();
        }

        // Loads all tasks from the database into the grid.
        private void LoadTasks()
        {
            try
            {
                dgvTasks.DataSource = null;
                dgvTasks.DataSource = _taskRepository.GetAllTasks();

                // Hide the raw database ID column.
                if (dgvTasks.Columns["TaskId"] != null)
                    dgvTasks.Columns["TaskId"].Visible = false;
            }
            catch (Exception ex)
            {
                lblTaskStatus.Text = "Could not load tasks: " + ex.Message;
            }
        }

        // Returns the task the user has selected in the grid, or null.
        private CyberTask? GetSelectedTask()
        {
            if (dgvTasks.CurrentRow == null)
                return null;

            return dgvTasks.CurrentRow.DataBoundItem as CyberTask;
        }

        private void btnAddTask_Click(object? sender, EventArgs e)
        {
            string title = txtTaskTitle.Text.Trim();
            string description = txtTaskDescription.Text.Trim();

            if (title == "" || description == "")
            {
                lblTaskStatus.Text = "Please enter both a task title and description.";
                return;
            }

            CyberTask task = new CyberTask
            {
                Title = title,
                Description = description,
                ReminderDate = chkUseReminder.Checked ? dtpReminder.Value : null,
                IsCompleted = false
            };

            try
            {
                _taskRepository.AddTask(task);
                _activityLogger.Log("Task added: " + task.Title);

                lblTaskStatus.Text = "Task added.";
                txtTaskTitle.Clear();
                txtTaskDescription.Clear();
                chkUseReminder.Checked = false;

                LoadTasks();
            }
            catch (Exception ex)
            {
                lblTaskStatus.Text = "Could not add task: " + ex.Message;
            }
        }

        private void btnCompleteTask_Click(object? sender, EventArgs e)
        {
            CyberTask? task = GetSelectedTask();
            if (task == null)
            {
                lblTaskStatus.Text = "Please select a task first.";
                return;
            }

            try
            {
                _taskRepository.MarkTaskCompleted(task.TaskId);
                _activityLogger.Log("Task completed: " + task.Title);
                lblTaskStatus.Text = "Task marked as completed.";
                LoadTasks();
            }
            catch (Exception ex)
            {
                lblTaskStatus.Text = "Could not complete task: " + ex.Message;
            }
        }

        private void btnDeleteTask_Click(object? sender, EventArgs e)
        {
            CyberTask? task = GetSelectedTask();
            if (task == null)
            {
                lblTaskStatus.Text = "Please select a task first.";
                return;
            }

            DialogResult answer = MessageBox.Show("Delete this task?\n" + task.Title,
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (answer != DialogResult.Yes)
                return;

            try
            {
                _taskRepository.DeleteTask(task.TaskId);
                _activityLogger.Log("Task deleted: " + task.Title);
                lblTaskStatus.Text = "Task deleted.";
                LoadTasks();
            }
            catch (Exception ex)
            {
                lblTaskStatus.Text = "Could not delete task: " + ex.Message;
            }
        }

        private void btnRefreshTasks_Click(object? sender, EventArgs e)
        {
            LoadTasks();
            lblTaskStatus.Text = "Task list refreshed.";
        }

        private void btnStartQuiz_Click(object? sender, EventArgs e)
        {
            _quiz.StartQuiz();
            _activityLogger.Log("Quiz started");

            ShowQuestion();
            btnSubmitAnswer.Enabled = true;
            btnNextQuestion.Enabled = false;
        }

        private void btnSubmitAnswer_Click(object? sender, EventArgs e)
        {
            int selected = GetSelectedOption();
            if (selected == -1)
            {
                lblQuizFeedback.Text = "Please select an answer.";
                return;
            }

            QuizAnswerResult result = _quiz.CheckAnswer(selected);
            lblQuizFeedback.Text = result.Feedback;
            lblQuizScore.Text = "Score: " + _quiz.Score;

            btnSubmitAnswer.Enabled = false;
            btnNextQuestion.Enabled = true;
        }

        private void btnNextQuestion_Click(object? sender, EventArgs e)
        {
            if (_quiz.MoveNext())
            {
                ShowQuestion();
                btnSubmitAnswer.Enabled = true;
                btnNextQuestion.Enabled = false;
            }
            else
            {
                // Quiz finished.
                lblQuestionNumber.Text = "Quiz complete!";
                lblQuestion.Text = "You scored " + _quiz.Score + " out of " + _quiz.TotalQuestions + ".";
                lblQuizFeedback.Text = _quiz.Score >= _quiz.TotalQuestions / 2
                    ? "Great job! You're becoming a cybersecurity pro."
                    : "Keep learning to stay safe online.";

                foreach (RadioButton radio in new[] { rdoA, rdoB, rdoC, rdoD })
                    radio.Visible = false;

                btnSubmitAnswer.Enabled = false;
                btnNextQuestion.Enabled = false;
                _activityLogger.Log("Quiz finished - score " + _quiz.Score + "/" + _quiz.TotalQuestions);
            }
        }

        // Shows the current question and sets up the answer options.
        private void ShowQuestion()
        {
            QuizQuestion question = _quiz.CurrentQuestion;

            lblQuestionNumber.Text = "Question " + (_quiz.CurrentIndex + 1) + " of " + _quiz.TotalQuestions;
            lblQuestion.Text = question.QuestionText;
            lblQuizScore.Text = "Score: " + _quiz.Score;
            lblQuizFeedback.Text = "";

            RadioButton[] radios = { rdoA, rdoB, rdoC, rdoD };
            for (int i = 0; i < radios.Length; i++)
            {
                radios[i].Checked = false;

                if (i < question.Options.Count)
                {
                    radios[i].Text = question.Options[i];
                    radios[i].Visible = true;
                }
                else
                {
                    radios[i].Visible = false;
                }
            }
        }

        // Returns the index of the selected option, or -1 if none is chosen.
        private int GetSelectedOption()
        {
            if (rdoA.Checked) return 0;
            if (rdoB.Checked) return 1;
            if (rdoC.Checked) return 2;
            if (rdoD.Checked) return 3;
            return -1;
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

            // NLP: if the message is a command (task / quiz / activity), handle it here.
            NlpIntent intent = _nlp.Detect(message);
            if (intent != NlpIntent.None)
            {
                HandleNlpIntent(intent);

                txtUserInput.Clear();
                txtUserInput.Focus();

                return;
            }

            // Otherwise ask the response handler for a reply.
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

        // Acts on a recognised command by opening the right tab.
        private void HandleNlpIntent(NlpIntent intent)
        {
            switch (intent)
            {
                case NlpIntent.AddTask:
                    AppendLine("Bot", "Opening the Tasks tab so you can add or manage a task.");
                    tabMain.SelectedTab = tabTasks;
                    _activityLogger.Log("NLP command: open tasks");
                    break;

                case NlpIntent.StartQuiz:
                    AppendLine("Bot", "Opening the quiz - click Start Quiz when you're ready.");
                    tabMain.SelectedTab = tabQuiz;
                    _activityLogger.Log("NLP command: open quiz");
                    break;


                case NlpIntent.ShowActivity:
                    AppendLine("Bot", "Here's your activity log.");
                    tabMain.SelectedTab = tabActivity;
                    _activityLogger.Log("NLP command: open activity");
                    break;
            }
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
