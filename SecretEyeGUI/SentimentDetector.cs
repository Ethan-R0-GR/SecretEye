namespace SecretEyeGUI
{
    // The simple moods the chatbot can detect.
    public enum Sentiment
    {
        Neutral,
        Worried,
        Curious,
        Frustrated
    }

    // Detects a simple sentiment from the user's wording
    public class SentimentDetector
    {
        // Mood words
        private readonly Dictionary<Sentiment, string[]> _moodWords = new Dictionary<Sentiment, string[]>
        {
            [Sentiment.Worried] = new[] { "worried", "worry", "scared", "afraid", "nervous", "anxious", "concerned" },
            [Sentiment.Frustrated] = new[] { "frustrated", "annoyed", "angry", "fed up", "stuck", "confused" },
            [Sentiment.Curious] = new[] { "curious", "wondering", "keen", "want to learn", "how does", "how do" }
        };

        // Returns the first mood whose words appear in the input
        public Sentiment Detect(string input)
        {
            input = input.ToLower();

            foreach (KeyValuePair<Sentiment, string[]> mood in _moodWords)
            {
                foreach (string word in mood.Value)
                {
                    if (input.Contains(word))
                        return mood.Key;
                }
            }

            return Sentiment.Neutral;
        }
    }
}
