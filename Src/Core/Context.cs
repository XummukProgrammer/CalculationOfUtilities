namespace CalculationOfUtilities.Core
{
    public class Context
    {
        public Services.ServicesManager ServicesManager { private set; get; } = new Services.ServicesManager();
        public States.StatesManager StatesManager { private set; get; } = new States.StatesManager();

        public Settings.Settings Settings { private set; get; } = new Settings.Settings();
        public bool IsExit { set; get; }
    }
}
