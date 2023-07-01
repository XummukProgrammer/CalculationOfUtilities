namespace CalculationOfUtilities.Core
{
    public class Context
    {
        public Services.ServicesManager ServicesManager { private set; get; } = new Services.ServicesManager();
        public States.StatesManager StatesManager { private set; get; } = new States.StatesManager();
        public Translations.TranslationsManager TranslationsManager { private set; get; } = new Translations.TranslationsManager();
        public Database.Database Database { private set; get; } = new Database.Database();

        public Settings.Settings Settings { private set; get; } = new Settings.Settings();
        
        public bool IsExit { set; get; }
        
        public uint Residents { set; get; }
    }
}
