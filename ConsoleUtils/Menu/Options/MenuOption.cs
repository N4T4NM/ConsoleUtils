using System;

namespace ConsoleUtils.Menu.Options
{
    public class MenuOption
    {
        public MenuOption(string text) { Text = text; }

        public string Text { get; set; }
        public virtual int Size => Text.Length;

        protected virtual void SetColorScheme(MenuColorScheme scheme)
        {
            Console.ForegroundColor = scheme.Foreground;
            Console.BackgroundColor = scheme.Background;
        }
        public virtual void Draw(MenuColorScheme scheme)
        {
            SetColorScheme(scheme);
            Console.WriteLine(Text);
        }

        public virtual bool Action(ConsoleMenu source)
            => false;
    }
}
