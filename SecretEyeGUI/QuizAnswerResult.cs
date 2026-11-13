namespace SecretEyeGUI
{
    // The result of checking one answer.
    public class QuizAnswerResult
    {
        public bool IsCorrect { get; set; }
        public string Feedback { get; set; } = "";
    }
}
