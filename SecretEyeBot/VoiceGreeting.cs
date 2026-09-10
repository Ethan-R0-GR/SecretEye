using System.Media;

namespace SecretEyeBot
{
    // used for locating and playing the recorded WAV voice greeting
    public class VoiceGreeting
    {
        // greeting is copied into an "Audio" folder next to the program when it builds 
        private readonly string _audioPath =
            Path.Combine(AppContext.BaseDirectory, "Audio", "greeting.wav");

        // plays the WAV greeting, prints a short note instead of crashing if it's not there
        public void PlayGreeting()
        {
            try
            {
                //Console.Write(_audioPath);
                //Console.Write(File.Exists(_audioPath));
                if (!File.Exists(_audioPath))
                {
                    Console.WriteLine("(Voice greeting file not found - skipping the audio for now.)");
                    Console.WriteLine();
                    return;
                }

                // PlaySync waits until the greeting has finished before the program continues
                using SoundPlayer player = new SoundPlayer(_audioPath);
                player.PlaySync();
            }
            catch (Exception ex)
            {
                // SoundPlayer only works on Windows and only with valid WAV files
                Console.WriteLine("(Could not play the voice greeting: " + ex.Message + ")");
                Console.WriteLine();
            }
        }
    }
}
