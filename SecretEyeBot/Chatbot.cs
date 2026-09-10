namespace SecretEyeBot
{
    // Controls the overall flow of the chatbot

    public class Chatbot
    {
        // The chatbot is made up of smaller helper classes
        private readonly VoiceGreeting _voice = new VoiceGreeting();
        private readonly AsciiArt _art = new AsciiArt();
        private readonly ResponseHandler _responder = new ResponseHandler();
        private readonly UserProfile _user = new UserProfile();

        public void Start()
        {
            _voice.PlayGreeting();   // Play the recorded voice greeting.
            _art.DisplayLogo();      // Show the ASCII logo / header.
            AskForName();            // Ask for and validate the user's name.
            ShowWelcome();           // Show a personalised text welcome.
            ConversationLoop();      // Chat until the user chooses to exit.
        }

        // ask users name for the welcome
        private void AskForName()
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Before we start, what is your name? ");
                Console.ResetColor();

                string input = Console.ReadLine() ?? "";

                if (!string.IsNullOrWhiteSpace(input))
                {
                    _user.Name = input.Trim();
                    return;
                }

                Console.WriteLine("I did not catch your name. Please type your name so I can personalise our chat.");
                Console.WriteLine();
            }
        }

        // personal welcome and lists of topics the user can ask about.
        private void ShowWelcome()
        {
            Console.WriteLine();
            _art.Divider();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Bot > Welcome, {_user.Name}!");
            Console.ResetColor();
            Console.WriteLine("      I am here to help you stay safer online.");
            Console.WriteLine();
            Console.WriteLine("      You can ask me about:");
            Console.WriteLine("        - Passwords");
            Console.WriteLine("        - Phishing");
            Console.WriteLine("        - Scams");
            Console.WriteLine("        - Safe browsing");
            Console.WriteLine("        - 2FA (two-factor authentication)");
            Console.WriteLine("        - Privacy");
            Console.WriteLine();
            Console.WriteLine("      Type 'exit' at any time to leave.");
            _art.Divider();
            Console.WriteLine();
        }

        // main loop. It reads a question, validates it, checks for exit.
        private void ConversationLoop()
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"{_user.Name} > ");
                Console.ResetColor();

                string input = Console.ReadLine() ?? "";

                // User pressed Enter without typing anything.
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Bot > Please type a question so I can help you.");
                    Console.WriteLine();
                    continue;
                }

                // Check whether the user wants to leave.
                if (input.Trim().ToLower() == "exit")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Bot > Goodbye, {_user.Name}. Stay safe online!");
                    Console.ResetColor();
                    return;
                }

                // Get a reply
                string response = _responder.GetResponse(input, _user);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Bot > {response}");
                Console.ResetColor();
                Console.WriteLine();
            }
        }
    }
}
