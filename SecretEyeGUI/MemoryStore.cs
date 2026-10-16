namespace SecretEyeGUI
{
    // Remembers details the user shares during the conversation
    public class MemoryStore
    {
        public string UserName { get; set; } = ""; 
        public string FavouriteTopic { get; set; } = "";
        public string CurrentTopic { get; set; } = ""; 
    }
}
