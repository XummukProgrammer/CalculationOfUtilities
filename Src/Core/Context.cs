namespace CalculationOfUtilities.Core
{
    public class Context
    {
        public Services.ServicesManager ServicesManager { private set; get; } = new Services.ServicesManager();
        public Settings.Settings Settings { private set; get; } = new Settings.Settings();
    }
}
