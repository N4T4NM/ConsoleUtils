namespace ConsoleUtils.Menu
{
    public class ConsoleMenuSettings
    {
        MenuColorScheme _tbcs = MenuColorScheme.Dark;
        MenuColorScheme _ocs = MenuColorScheme.BlackAndWhite;
        MenuColorScheme _scs = MenuColorScheme.BlackAndWhiteInverted;

        public MenuColorScheme TitleBarColorScheme { get => _tbcs; set => _tbcs = value; }
        public MenuColorScheme OptionColorScheme { get => _ocs; set => _ocs = value; }
        public MenuColorScheme SelectedColorScheme { get => _scs; set => _scs = value; }
    }
}
