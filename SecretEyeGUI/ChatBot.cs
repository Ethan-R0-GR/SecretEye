namespace SecretEyeGUI
{
    // Declares the shape of a method
    public delegate void BotResponseHandler(string message);

    // Coordinates the chatbot's logic.
    public class ChatBot
    {
        private readonly MemoryStore _memory = new MemoryStore();
        private readonly ResponseHandler _responder;

        // The GUI attaches its display method here.
        public BotResponseHandler? OnResponse;

        public ChatBot()
        {
            _responder = new ResponseHandler(_memory);
        }

        // Works out a reply for the user's message and sends it out via the delegate.
        public void ProcessInput(string userMessage)
        {
            string reply = _responder.GetResponse(userMessage);
            OnResponse?.Invoke(reply);
        }
    }
}
