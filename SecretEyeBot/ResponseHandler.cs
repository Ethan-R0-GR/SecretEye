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
            ["password"] = new[]
            {
                "Use long, unique passwords - at least 12 characters mixing letters, numbers and symbols.",
                "Never reuse the same password across sites. A password manager can remember them all for you.",
                "Avoid personal details like birthdays or names in passwords - they are easy for attackers to guess."
            },
            ["phishing"] = new[]
            {
                "Be careful of emails asking for personal information. Scammers often pretend to be trusted companies.",
                "Check the sender's address and hover over links before clicking - phishing links often look almost right.",
                "If a message tries to rush or scare you into acting now, slow down. That pressure is a classic phishing trick."
            },
            ["scam"] = new[]
            {
                "If an offer sounds too good to be true, it usually is. Verify it through an official channel first.",
                "Never send money or gift cards to someone you have not confirmed is who they say they are."
            },
            ["browsing"] = new[]
            {
                "Look for 'https' and the padlock in the address bar before entering any details on a website.",
                "Keep your browser and antivirus updated, and avoid downloading files from sites you do not trust."
            },
            ["2fa"] = new[]
            {
                "Two-factor authentication (2FA) adds a second step to logins, so a stolen password alone is not enough.",
                "Turn on 2FA for your email and banking first - those are the accounts attackers want most."
            },
            ["privacy"] = new[]
            {
                "Share as little personal information online as you can, and review the privacy settings on your accounts.",
                "Think before you post - once something is online it is very hard to fully remove."
            }
        };

        // gives appropriate reply for the user's input.
        public string GetResponse(string userInput, UserProfile user)
        {
            // Work in lower case.
            string input = userInput.ToLower();

            // Questions
            if (input.Contains("how are you"))
                return "I am running securely, thank you! Ready to help you stay safe online.";

            if (input.Contains("your purpose") || input.Contains("what do you do") || input.Contains("who are you"))
                return "My purpose is to teach you about cybersecurity - things like passwords, phishing and safe browsing.";

            if (input.Contains("what can i ask") || input.Contains("what can you") || input.Contains("topics"))
                return "You can ask me about: passwords, phishing, scams, safe browsing, 2FA and privacy.";

            if (input.Contains("thank"))
                return "You are welcome" + NameSuffix(user) + "! Staying informed is the best defence.";

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
