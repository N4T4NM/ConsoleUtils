using System;

namespace ConsoleUtils.Menu
{
    public class MenuColorScheme
    {
        public ConsoleColor Foreground { get; set; }
        public ConsoleColor Background { get; set; }

        public static MenuColorScheme Dark => new MenuColorScheme()
        {
            Background = ConsoleColor.DarkBlue,
            Foreground = ConsoleColor.White
        };

        public static MenuColorScheme BlackAndWhite => new MenuColorScheme()
        {
            Background = ConsoleColor.Black,
            Foreground = ConsoleColor.White
        };

        public static MenuColorScheme BlackAndWhiteInverted => new MenuColorScheme()
        {
            Background = ConsoleColor.White,
            Foreground = ConsoleColor.Black
        };
    }
}
