namespace CalculationOfUtilities.ConsoleUI
{
    public class ServiceDialog
    {
        public bool HasAccountingDevice { private set; get; }
        public Counter.MeteringDeviceSpan MeteringDeviceSpan { protected set; get; }

        protected Core.Context _context;
        private string _name;

        public ServiceDialog(Core.Context context, string name)
        {
            _context = context;
            _name = name;
        }

        public void Exec()
        {
            if (_context == null)
            {
                return;
            }

            System.Console.WriteLine(_context.TranslationsManager.GetTranslationText("SERVICE_TITLE"), _context.TranslationsManager.GetTranslationText(_name));
            System.Console.Write(_context.TranslationsManager.GetTranslationText("DO_YOU_HAVE_COUNTER"));
            HasAccountingDevice = System.Console.ReadLine()[0] == 'y';

            if (HasAccountingDevice)
            {
                OnGetAccountingDeviceInfo();
            }

            System.Console.Clear();
        }

        protected virtual void OnGetAccountingDeviceInfo()
        {
            if (_context == null)
            {
                return;
            }

            // TODO: Текущее значение не может быть меньше предыдущего

            System.Console.Write(_context.TranslationsManager.GetTranslationText("ENTER_CURRENT_INDICATIONS"));
            float currentIndications = float.Parse(System.Console.ReadLine());

            System.Console.Write(_context.TranslationsManager.GetTranslationText("ENTER_PREV_INDICATIONS"));
            float prevIndications = float.Parse(System.Console.ReadLine());

            MeteringDeviceSpan = new Counter.MeteringDeviceSpan(currentIndications, prevIndications);
        }
    }
}
