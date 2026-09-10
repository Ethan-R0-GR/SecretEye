namespace SecretEyeBot
{
    internal class Program
    {
        // only job is to create the chatbot and start it, conversation logic lives in the other classes 
        static void Main(string[] args)
        {
            Chatbot bot = new Chatbot();

            bot.Start();
        }
    }
}
