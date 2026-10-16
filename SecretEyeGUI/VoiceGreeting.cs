using System.Media; // SoundPlayer lives here (included with the Windows Desktop framework).

namespace SecretEyeGUI
{
    // Locates and plays the recorded WAV voice greeting, reused from Part 1.
    public class VoiceGreeting
    {
        // The greeting is copied into an "Audio" folder next to the program when it builds
        // (see the .csproj). AppContext.BaseDirectory is that output folder.
        private readonly string _audioPath =
            Path.Combine(AppContext.BaseDirectory, "Audio", "greeting.wav");

        // Plays the greeting. Fails silently (never crashes) if the file is missing or invalid.
        public void PlayGreeting()
        {
            try
            {
                if (!File.Exists(_audioPath))
                {
                    return;
                }

                // PlaySync plays the whole clip. We call this on a background thread
                // (see ChatbotForm) so the window is not frozen while it plays.
                using SoundPlayer player = new SoundPlayer(_audioPath);
                player.PlaySync();
            }
            catch
            {
                // Audio is optional - a bad or missing file must never stop the chatbot.
            }
        }
    }
}
