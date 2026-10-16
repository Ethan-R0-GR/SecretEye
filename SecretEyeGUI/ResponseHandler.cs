namespace SecretEyeGUI
{
    // Recognises cybersecurity topics in the user's input and returns relevant guidance.
    
    // It uses a Dictionary<string, List<string>> (a generic collection) to map each topic to several possible answers, and a second dictionary of aliases
    public class ResponseHandler
    {
        // Topic keyword
        private readonly Dictionary<string, List<string>> _responses = new Dictionary<string, List<string>>
        {
            ["password"] = new List<string>
            {
                "Use long, unique passwords - at least 12 characters mixing letters, numbers and symbols.",
                "Never reuse the same password across sites. A password manager can remember them all for you.",
                "Avoid personal details like birthdays or names in passwords - they are easy for attackers to guess."
            },
            ["phishing"] = new List<string>
            {
                "Be careful of emails asking for personal information. Scammers often pretend to be trusted companies.",
                "Check the sender's address and hover over links before clicking - phishing links often look almost right.",
                "If a message tries to rush or scare you into acting now, slow down. That pressure is a classic phishing trick."
            },
            ["scam"] = new List<string>
            {
                "If an offer sounds too good to be true, it usually is. Verify it through an official channel first.",
                "Never send money or gift cards to someone you have not confirmed is who they say they are."
            },
            ["browsing"] = new List<string>
            {
                "Look for 'https' and the padlock in the address bar before entering any details on a website.",
                "Keep your browser and antivirus updated, and avoid downloading files from sites you do not trust."
            },
            ["2fa"] = new List<string>
            {
                "Two-factor authentication (2FA) adds a second step to logins, so a stolen password alone is not enough.",
                "Turn on 2FA for your email and banking first - those are the accounts attackers want most."
            },
            ["privacy"] = new List<string>
            {
                "Share as little personal information online as you can, and review the privacy settings on your accounts.",
                "Think before you post - once something is online it is very hard to fully remove."
            },
            ["malware"] = new List<string>
            {
                "Keep your operating system and antivirus up to date - most malware exploits known, unpatched holes.",
                "Do not open attachments or install software from sources you do not trust."
            },
            ["social engineering"] = new List<string>
            {
                "Social engineering tricks you into giving up information - always verify who you are really talking to.",
                "Be suspicious of urgent requests for passwords, codes or money, even from someone who seems familiar."
            }
        };

        // Alternative wording
        private readonly Dictionary<string, string> _aliases = new Dictionary<string, string>
        {
            ["passwords"] = "password",
            ["pass word"] = "password",
            ["phish"] = "phishing",
            ["scams"] = "scam",
            ["scammer"] = "scam",
            ["scammed"] = "scam",
            ["browser"] = "browsing",
            ["browse"] = "browsing",
            ["two factor"] = "2fa",
            ["two-factor"] = "2fa",
            ["2 factor"] = "2fa",
            ["mfa"] = "2fa",
            ["private"] = "privacy",
            ["virus"] = "malware",
            ["viruses"] = "malware",
            ["ransomware"] = "malware",
            ["spyware"] = "malware",
            ["social engineer"] = "social engineering"
        };

        // Returns a relevant reply for the user's input
        public string GetResponse(string userInput)
        {
            string input = userInput.ToLower();

            // General / conversational questions.
            if (input.Contains("how are you"))
                return "I am running securely, thank you! Ready to help you stay safe online.";

            if (input.Contains("your purpose") || input.Contains("what do you do") || input.Contains("who are you"))
                return "My purpose is to teach you about cybersecurity - passwords, phishing, safe browsing and more.";

            if (input.Contains("what can i ask") || input.Contains("what can you") || input.Contains("topics") || input.Contains("help"))
                return "You can ask me about: passwords, phishing, scams, safe browsing, 2FA, privacy, malware and social engineering.";

            if (input.Contains("thank"))
                return "You are welcome! Staying informed is the best defence.";

            // Try to recognise a cybersecurity topic.
            string? topic = DetectTopic(input);
            if (topic != null)
            {
                // For now we return the first answer; the next commit makes this random.
                return _responses[topic][0];
            }

            // Default response when nothing was recognised.
            return "I am not sure I understand that yet. Try asking about passwords, phishing, scams, "
                 + "safe browsing, 2FA, privacy, malware or social engineering.";
        }

        // Works out which topic the input is about: checks the alternative wordings first, then the main keywords. Returns null if no cybersecurity topic was found.
        public string? DetectTopic(string input)
        {
            input = input.ToLower();

            foreach (KeyValuePair<string, string> alias in _aliases)
            {
                if (input.Contains(alias.Key))
                    return alias.Value;
            }

            foreach (string keyword in _responses.Keys)
            {
                if (input.Contains(keyword))
                    return keyword;
            }

            return null;
        }
    }
}
