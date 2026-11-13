namespace SecretEyeGUI
{
    // Keeps a simple list of actions the bot has taken.
    public class ActivityLogger
    {
        private readonly List<string> _entries = new List<string>();

        // Records one action with a timestamp.
        public void Log(string action)
        {
            _entries.Add(DateTime.Now.ToString("HH:mm") + " - " + action);
        }
    }
}
