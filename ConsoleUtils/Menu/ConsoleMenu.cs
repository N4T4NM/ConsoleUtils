using ConsoleUtils.Management;
using ConsoleUtils.Menu.Options;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleUtils.Menu
{
    public class ConsoleMenu
    {
        public string Title { get; set; }

        public readonly List<MenuOption> Options;
        ConsoleMenuSettings _settings;
        public ConsoleMenu(string title, ConsoleMenuSettings settings = null, params MenuOption[] options)
        {
            Options = options.ToList();
            Title = title;
            _settings = settings == null ? new ConsoleMenuSettings() : settings;
        }
        int CalculateSpacing()
        {
            int space = Title.Length;
            foreach (MenuOption option in Options)
                if (option.Size > space)
                    space = option.Size;

            space -= Title.Length;
            return space / 2;
        }
        void ShowTitle()
        {
            var defaultBack = Console.BackgroundColor;
            var defaultFore = Console.ForegroundColor;

            Console.BackgroundColor = _settings.TitleBarColorScheme.Background;
            Console.ForegroundColor = _settings.TitleBarColorScheme.Foreground;

            string spacing = new string(' ', CalculateSpacing());
            Console.WriteLine($"{spacing}{Title}{spacing}");

            Console.BackgroundColor = defaultBack;
            Console.ForegroundColor = defaultFore;
        }
        void DrawItems(int selected)
        {
            var defaultBack = Console.BackgroundColor;
            var defaultFore = Console.ForegroundColor;

            for (int i = 0; i < Options.Count; i++)
            {
                MenuOption option = Options[i];
                if (i == selected)
                    option.Draw(_settings.SelectedColorScheme);
                else option.Draw(_settings.OptionColorScheme);
            }

            Console.BackgroundColor = defaultBack;
            Console.ForegroundColor = defaultFore;
        }

        public int Show()
        {
            int selected = 0;
            Console.CursorVisible = false;

            while (true)
            {
                ShowTitle();
                DrawItems(selected);

                ConsoleKey key = Console.ReadKey().Key;
                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        selected--;
                        if (selected < 0)
                            selected = Options.Count - 1;
                        break;
                    case ConsoleKey.DownArrow:
                        selected++;
                        if (selected >= Options.Count)
                            selected = 0;
                        break;
                    case ConsoleKey.Enter:
                        if (!Options[selected].Action(this))
                        {
                            ConsoleClear.ClearLine(Options.Count + 2);
                            Console.CursorVisible = true;
                            return selected;
                        }
                        break;
                }

                ConsoleClear.ClearLine(Options.Count + 2);
            }
        }
    }
}
