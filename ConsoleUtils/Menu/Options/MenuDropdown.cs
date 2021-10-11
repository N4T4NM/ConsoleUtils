using ConsoleUtils.Management;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleUtils.Menu.Options
{
    public class MenuDropdown : MenuOption
    {
        public MenuDropdown(string text, params MenuOption[] options) : base(text)
        {
            DropdownOptions = options.ToList();
        }

        public readonly List<MenuOption> DropdownOptions;

        public override int Size => base.Size + 4;
        public override void Draw(MenuColorScheme scheme)
        {
            base.SetColorScheme(scheme);
            Console.WriteLine($"{Text} [v]");
        }

        public override bool Action(ConsoleMenu source)
        {
            ConsoleClear.ClearLine(source.Options.Count + 2);

            new ConsoleMenu($"{Text} Options", options: DropdownOptions.ToArray()).Show();

            Console.CursorVisible = false;
            Console.Write(new string('\n', DropdownOptions.Count));
            return true;
        }
    }
}
