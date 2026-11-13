namespace SecretEyeGUI
{
    // One cybersecurity task stored in the database.
    public class CyberTask
    {
        public int TaskId { get; set; }
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public DateTime? ReminderDate { get; set; }   // null means no reminder
        public bool IsCompleted { get; set; }
    }
}
