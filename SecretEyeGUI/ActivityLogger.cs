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

        // Returns the most recent actions, newest first (up to count).
        public List<string> GetRecent(int count)
        {

            List<string> recent = new List<string>();
            for (int i = _entries.Count - 1; i >= 0 && recent.Count < count; i--)
            {

                recent.Add(_entries[i]);
            }

            return recent;
        }
    }
}
