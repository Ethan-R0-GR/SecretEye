namespace SecretEyeGUI
{
    // Recognises cybersecurity topics and returns relevant guidance. It also works with
    // a MemoryStore so the bot can remember the user's name and favourite topic, recall
    // them, and keep follow-up questions on the current topic.
    public class ResponseHandler
    {

        private readonly Random _random = new Random();

        // Detects the user's mood
        private readonly SentimentDetector _sentiment = new SentimentDetector();

        // Shared memory
        private readonly MemoryStore _memory;

        public ResponseHandler(MemoryStore memory)
        {
            _memory = memory;
        }

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

        // Alternative wordings
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

        public string GetResponse(string userInput)
        {
            string input = userInput.ToLower();

            // Work out the user's mood
            Sentiment mood = _sentiment.Detect(input);

            //  Remember the user's name
            string? name = ExtractName(userInput);
            if (name != null)
            {
                _memory.UserName = name;
                return $"Nice to meet you, {name}! I'll remember that.";
            }

            //  Recall the name
            if (input.Contains("what is my name") || input.Contains("what's my name") || input.Contains("who am i"))
            {
                return string.IsNullOrWhiteSpace(_memory.UserName)
                    ? "You haven't told me your name yet - you can say 'my name is ...'."
                    : $"Your name is {_memory.UserName}.";
            }

            //  Remember a favourite topic
            if (input.Contains("interested in") || input.Contains("i like") ||
                input.Contains("my favourite") || input.Contains("my favorite"))
            {
                string? interest = DetectTopic(input);
                if (interest != null)
                {
                    _memory.FavouriteTopic = interest;
                    _memory.CurrentTopic = interest;
                    return $"Great{NameSuffix()}! I'll remember you're interested in {interest}. " + RandomFrom(_responses[interest]);
                }
            }

            //  Recall the favourite topic 
            if (input.Contains("what am i interested") || input.Contains("my favourite topic") ||
                input.Contains("my favorite topic") || input.Contains("what do i like"))
            {
                return string.IsNullOrWhiteSpace(_memory.FavouriteTopic)
                    ? "You haven't told me a favourite topic yet - try 'I'm interested in privacy'."
                    : $"You're interested in {_memory.FavouriteTopic}. " + RandomFrom(_responses[_memory.FavouriteTopic]);
            }

            //  General / conversational questions 
            if (input.Contains("how are you"))
                return "I am running securely, thank you! Ready to help you stay safe online.";

            if (input.Contains("your purpose") || input.Contains("what do you do") || input.Contains("who are you"))
                return "My purpose is to teach you about cybersecurity - passwords, phishing, safe browsing and more.";

            if (input.Contains("what can i ask") || input.Contains("what can you") || input.Contains("topics") || input.Contains("help"))
                return "You can ask me about: passwords, phishing, scams, safe browsing, 2FA, privacy, malware and social engineering.";

            if (input.Contains("thank"))
                return $"You are welcome{NameSuffix()}! Staying informed is the best defence.";

            //  A cybersecurity topic 
            string? topic = DetectTopic(input);
            if (topic != null)
            {
                _memory.CurrentTopic = topic;
                string tip = RandomFrom(_responses[topic]);

                // Personalise the reply.
                if (topic == _memory.FavouriteTopic)
                    tip = $"Since you're interested in {topic}{NameSuffix()}: {tip}";

                return WithEmpathy(mood, tip);
            }

            //  Follow up on the current topic
            if (IsFollowUp(input))
            {
                if (!string.IsNullOrEmpty(_memory.CurrentTopic))
                    return WithEmpathy(mood, RandomFrom(_responses[_memory.CurrentTopic]));

                return "Sure - which topic would you like to explore? Try passwords, phishing, scams, "
                     + "safe browsing, 2FA, privacy, malware or social engineering.";
            }

            //  The user expressed a feeling but no topic
            if (mood != Sentiment.Neutral)
            {
                string help = string.IsNullOrEmpty(_memory.CurrentTopic)
                    ? "Tell me what's on your mind - passwords, phishing, scams, privacy and more - and I'll help."
                    : RandomFrom(_responses[_memory.CurrentTopic]);
                return WithEmpathy(mood, help);
            }

            //  Default response when nothing was recognised 
            return "I am not sure I understand that yet. Try asking about passwords, phishing, scams, "
                 + "safe browsing, 2FA, privacy, malware or social engineering.";
        }

        // Works out which topic the input is about
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

        // Picks one answer at random from a list of options.
        private string RandomFrom(List<string> options)
        {
            return options[_random.Next(options.Count)];
        }

        // Recognises follow up phrases.
        private bool IsFollowUp(string input)
        {
            string[] followUps =
            {
                "tell me more", "more detail", "explain more", "explain",
                "another tip", "another", "what else", "say more",
                "continue", "go on", "do not understand", "don't understand", "dont understand"
            };

            foreach (string phrase in followUps)
            {
                if (input.Contains(phrase))
                    return true;
            }
            return false;
        }

        // Captures a name
        private string? ExtractName(string original)
        {
            string lower = original.ToLower();

            string marker;
            if (lower.Contains("my name is")) marker = "my name is";
            else if (lower.Contains("call me")) marker = "call me";
            else return null;

            int start = lower.IndexOf(marker) + marker.Length;
            string rest = original.Substring(start).Trim();
            if (rest.Length == 0) return null;

            // Take the first word as the name and tidy its capitalisation.
            string name = rest.Split(new[] { ' ', ',', '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries)[0];
            if (name.Length == 0) return null;

            return char.ToUpper(name[0]) + name.Substring(1).ToLower();
        }

        private string NameSuffix()
        {
            return string.IsNullOrWhiteSpace(_memory.UserName) ? "" : ", " + _memory.UserName;
        }

        // Adds a short, mood appropriate sentence before the tip.
        private string WithEmpathy(Sentiment mood, string tip)
        {
            switch (mood)
            {
                case Sentiment.Worried:
                    return "It's completely understandable to feel worried - let's tackle it together. " + tip;
                case Sentiment.Frustrated:
                    return "I hear you, this can be frustrating. Let's keep it simple. " + tip;
                case Sentiment.Curious:
                    return "Love the curiosity - that's the best way to stay safe! " + tip;
                default:
                    return tip;
            }
        }
    }
}
