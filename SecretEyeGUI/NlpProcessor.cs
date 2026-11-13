namespace SecretEyeGUI
{
    // The commands the chat can recognise.
    public enum NlpIntent
    {
        None,
        AddTask,
        StartQuiz,
        ShowActivity
    }

    // Simple NLP: works out what the user wants from their wording, even when phrased differently.
    public class NlpProcessor
    {
        public NlpIntent Detect(string input)
        {
            input = input.ToLower();

            if (input.Contains("task") || input.Contains("remind"))
                return NlpIntent.AddTask;

            if (input.Contains("quiz") || input.Contains("test me") || input.Contains("game"))
                return NlpIntent.StartQuiz;

            if (input.Contains("activity") || input.Contains("what have you done") || input.Contains("show log"))
                return NlpIntent.ShowActivity;

            return NlpIntent.None;
        }
    }
}
