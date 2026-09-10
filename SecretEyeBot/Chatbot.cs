namespace SecretEyeBot
{
    // Controls the overall flow of the chatbot

    public class Chatbot
    {
        // The chatbot is made up of smaller helper classes
        private readonly ResponseHandler _responder = new ResponseHandler();
        private readonly UserProfile _user = new UserProfile();

        public void Start()
        {
            AskForName();            // Ask for and validate the user's name
            ShowWelcome();           // Show a personalised text welcome
            ConversationLoop();      // Chat until the user chooses to exit
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
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Bot > Welcome, {_user.Name}!");
;
        }

        // main loop. It reads a question, validates it, checks for exit.
        private void ConversationLoop()
        {
            while (true)
            {
      

                string input = Console.ReadLine() ?? "";

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
