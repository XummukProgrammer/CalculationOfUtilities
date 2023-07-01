namespace CalculationOfUtilities.ConsoleUI
{
    public class ElectricityServiceDialog : ServiceDialog
    {
        public Counter.MeteringDeviceSpan MeteringDeviceSpanNight { private set; get; }

        public ElectricityServiceDialog(Core.Context context, string name) : base(context, name)
        {
        }

        protected override void OnGetAccountingDeviceInfo()
        {
            if (_context == null)
            {
                return;
            }

            MeteringDeviceSpan = MakeMeteringDeviceSpan(_context.TranslationsManager.GetTranslationText("DAY_TIME"));
            MeteringDeviceSpanNight = MakeMeteringDeviceSpan(_context.TranslationsManager.GetTranslationText("NIGHT_TIME"));
        }

        private Counter.MeteringDeviceSpan MakeMeteringDeviceSpan(string name)
        {
            if (_context == null)
            {
                return null;
            }

            System.Console.Write(_context.TranslationsManager.GetTranslationText("ELECTRICITY_ENTER_CURRENT_INDICATIONS"), name);
            float currentIndications = float.Parse(System.Console.ReadLine());

            System.Console.Write(_context.TranslationsManager.GetTranslationText("ELECTRICITY_ENTER_PREV_INDICATIONS"), name);
            float prevIndications = float.Parse(System.Console.ReadLine());

            return new Counter.MeteringDeviceSpan(currentIndications, prevIndications);
        }
    }
}
