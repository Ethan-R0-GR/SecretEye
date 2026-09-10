namespace SecretEyeBot
{
    /// How the chatbot replies to the user's input. Falls back to a friendly default when it does not understand.

    public class ResponseHandler
    {
        // Used to pick a random answer for some variation
        private readonly Random _random = new Random();

        // using Dictionary to make part 2 easier later
        private readonly Dictionary<string, string[]> _responses = new Dictionary<string, string[]>
        {
            ["test"] = new[]
            {
                "Hello",
            },

        };

        // gives appropriate reply for the user's input.
        public string GetResponse(string userInput, UserProfile user)
        {
            // Work in lower case.
            string input = userInput.ToLower();

           
            // keywords to checked against the dictionary above
            foreach (KeyValuePair<string, string[]> topic in _responses)
            {
                if (input.Contains(topic.Key))
                {
                    string[] options = topic.Value;
                    return options[_random.Next(options.Length)]; // pick one answer at random
                }
            }

            // default response when nothing matched
            return "I am not sure I understand that yet. Try asking about passwords, phishing, scams, safe browsing, 2FA or privacy.";
        }

        // Adds users name if we know it
        private string NameSuffix(UserProfile user)
        {
            return string.IsNullOrWhiteSpace(user.Name) ? "" : ", " + user.Name;
        }
    }
}
