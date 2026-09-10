namespace SecretEyeBot
{
    public class AsciiArt
    {
        // ASCII logo that appears when the chatbot starts
        public void DisplayLogo()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("         S E C R E T E Y E   C H A T B O T");
            Console.WriteLine("         Cybersecurity Awareness Assistant");

            Console.ResetColor();
            Console.WriteLine();
        }

        public void Divider()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("-----------------------------------------------------");
            Console.ResetColor();
        }
    }
}
