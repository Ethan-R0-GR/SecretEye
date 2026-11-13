namespace SecretEyeGUI
{
    // Runs the cybersecurity quiz: tracks the current question and the score.
    public class QuizManager
    {
        private readonly List<QuizQuestion> _questions;

        public int CurrentIndex { get; private set; }
        public int Score { get; private set; }
        public bool QuizStarted { get; private set; }

        public int TotalQuestions => _questions.Count;
        public QuizQuestion CurrentQuestion => _questions[CurrentIndex];

        public QuizManager()
        {

            _questions = BuildQuestions();

        }

        public void StartQuiz()
        {
            CurrentIndex = 0;
            Score = 0;
            QuizStarted = true;

        }

        // Checks the selected answer and updates the score.
        public QuizAnswerResult CheckAnswer(int selectedIndex)
        {
            bool correct = selectedIndex == CurrentQuestion.CorrectOptionIndex;
            if (correct)
                Score++;

            return new QuizAnswerResult
            {
                IsCorrect = correct,
                Feedback = (correct ? "Correct! " : "Not quite. ") + CurrentQuestion.Explanation
            };
        }

        // Moves to the next question. Returns false when the quiz is finished.
        public bool MoveNext()
        {
            if (CurrentIndex < _questions.Count - 1)
            {
                CurrentIndex++;
                return true;

            }

            QuizStarted = false;
            return false;
        }

        private List<QuizQuestion> BuildQuestions()
        {
            return new List<QuizQuestion>
            {

                new QuizQuestion
                {
                    QuestionText = "An email asks you to confirm your password. What should you do?",
                    Options = new List<string> { "Reply with your password", "Click the link and log in", "Report it as phishing", "Forward it to friends" },
                    CorrectOptionIndex = 2,
                    Explanation = "Legitimate companies never ask for your password by email."
                },
                new QuizQuestion
                {
                    QuestionText = "Which of these is the strongest password?",
                    Options = new List<string> { "password123", "JohnSmith1990", "qwerty", "7x!Kp2#mLq9" },
                    CorrectOptionIndex = 3,
                    Explanation = "Long, random mixes of letters, numbers and symbols are hardest to guess."
                },
                new QuizQuestion
                {
                    QuestionText = "True or False: Using the same password everywhere is fine as long as it is strong.",
                    Options = new List<string> { "True", "False" },
                    CorrectOptionIndex = 1,
                    Explanation = "If one site is breached, a reused password exposes all your accounts."
                },
                new QuizQuestion
                {
                    QuestionText = "What does two-factor authentication (2FA) add to a login?",
                    Options = new List<string> { "A second password box", "A second verification step", "A faster login", "A new username" },
                    CorrectOptionIndex = 1,
                    Explanation = "2FA adds a second step, so a stolen password alone is not enough."
                },
                new QuizQuestion
                {
                    QuestionText = "True or False: Public Wi-Fi is always safe for online banking.",
                    Options = new List<string> { "True", "False" },
                    CorrectOptionIndex = 1,
                    Explanation = "Public Wi-Fi can be snooped on; avoid sensitive logins or use a VPN."
                },
                new QuizQuestion
                {
                    QuestionText = "A pop-up says your PC has a virus and to call a number. This is most likely...",
                    Options = new List<string> { "A helpful alert", "A scam", "Your antivirus", "A system update" },
                    CorrectOptionIndex = 1,
                    Explanation = "Scare pop-ups with phone numbers are a classic tech-support scam."
                },
                new QuizQuestion
                {
                    QuestionText = "True or False: You should keep your software and antivirus updated.",
                    Options = new List<string> { "True", "False" },
                    CorrectOptionIndex = 0,
                    Explanation = "Updates patch the security holes that malware tries to exploit."
                },
                new QuizQuestion
                {
                    QuestionText = "Before entering details on a website, you should look for...",
                    Options = new List<string> { "A green background", "'https' and a padlock", "Lots of adverts", "A pop-up" },
                    CorrectOptionIndex = 1,
                    Explanation = "'https' and the padlock show the connection is encrypted."
                },
                new QuizQuestion
                {
                    QuestionText = "Social engineering mainly targets...",
                    Options = new List<string> { "Software bugs", "People's trust", "Wi-Fi routers", "Hard drives" },
                    CorrectOptionIndex = 1,
                    Explanation = "Social engineering tricks people rather than hacking machines."
                },
                new QuizQuestion
                {
                    QuestionText = "True or False: It is safe to open an unexpected attachment if the email looks official.",
                    Options = new List<string> { "True", "False" },
                    CorrectOptionIndex = 1,
                    Explanation = "Unexpected attachments can carry malware even when the email looks real."
                },
                new QuizQuestion
                {
                    QuestionText = "What is phishing?",
                    Options = new List<string> { "A type of firewall", "Fake messages that steal information", "A password manager", "A backup method" },
                    CorrectOptionIndex = 1,
                    Explanation = "Phishing uses fake messages to trick you into giving up information."
                },
                new QuizQuestion
                {
                    QuestionText = "True or False: A password manager helps you use strong, unique passwords.",
                    Options = new List<string> { "True", "False" },
                    CorrectOptionIndex = 0,
                    Explanation = "It creates and remembers strong passwords so you never reuse one."
                }

            };
        }
    }
}
