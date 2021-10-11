using System;

namespace ConsoleUtils.Menu.Options
{
    public class MenuCheckbox : MenuRadioButton
    {
        public MenuCheckbox(string text, bool check=false) : base(text, check) { }
        public override void Draw(MenuColorScheme scheme)
        {
            base.SetColorScheme(scheme);
            if (Checked)
                Console.Write("[X] ");
            else Console.Write("[ ] ");

            Console.WriteLine(Text);
        }

        public override bool Action(ConsoleMenu source)
        {
            Checked = !Checked;
            return true;
        }
    }
}
