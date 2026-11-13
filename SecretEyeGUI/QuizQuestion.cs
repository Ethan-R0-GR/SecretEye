namespace SecretEyeGUI
{
    // One quiz question with its options and the correct answer.
    public class QuizQuestion
    {
        public string QuestionText { get; set; } = "";
        public List<string> Options { get; set; } = new List<string>();
        public int CorrectOptionIndex { get; set; }   // 0 = first option
        public string Explanation { get; set; } = "";
    }
}
