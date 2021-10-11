using System;

namespace ConsoleUtils.Menu.Options
{
    public class MenuRadioButton : MenuOption
    {
        public MenuRadioButton(string text, bool check=false) : base(text) {  Checked = check; }
        public override int Size => base.Size + 4;
        public bool Checked { get; set; }

        public override void Draw(MenuColorScheme scheme)
        {
            base.SetColorScheme(scheme);
            if (Checked)
                Console.Write("(■) ");
            else Console.Write("( ) ");

            Console.WriteLine(Text);
        }

        public override bool Action(ConsoleMenu source)
        {
            foreach (MenuOption option in source.Options)
                if (option is MenuRadioButton && !(option is MenuCheckbox))
                    (option as MenuRadioButton).Checked = false;

            Checked = true;
            return true;
        }
    }
}
