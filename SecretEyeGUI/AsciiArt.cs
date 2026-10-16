namespace SecretEyeGUI
{
    // Provides the cybersecurity ASCII branding shown in the GUI banner.
    // This is the same identity used in the Part 1 console app, translated into the GUI.
    public static class AsciiArt
    {
        public static string GetBanner()
        {
            return
@"=====================================================
         S E C R E T E Y E   C H A T B O T
         Cybersecurity Awareness Assistant
=====================================================
                ___________
             .-'           '-.
           .'    .-------.    '.
          /    .'         '.    \
         |    |      /\     |    |
         |    |     |  |    |    |
         |    |      \/     |    |
          \    '.         .'    /
           '.    '-------'    .'
             '-.___________.-'
                  STAY  ALERT";
        }
    }
}
