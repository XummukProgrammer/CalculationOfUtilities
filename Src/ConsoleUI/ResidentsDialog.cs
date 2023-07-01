namespace CalculationOfUtilities.ConsoleUI
{
    public class ResidentsDialog
    {
        public uint Residents { private set; get; }

        private Core.Context _context;

        public ResidentsDialog(Core.Context context)
        {
            _context = context;
        }

        public void Exec()
        {
            if (_context == null)
            {
                return;
            }

            System.Console.Write(_context.TranslationsManager.GetTranslationText("ENTER_RESIDENTS"));
            Residents = uint.Parse(System.Console.ReadLine());
            System.Console.Clear();
        }
    }
}
