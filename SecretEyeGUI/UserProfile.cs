namespace SecretEyeGUI
{
    // Stores basic information about the current user during the conversation.
    // Demonstrates an automatic property (a learning outcome carried over from Part 1).
    public class UserProfile
    {
        // Initialised to an empty string so it is never null (Nullable is enabled).
        public string Name { get; set; } = "";
    }
}
