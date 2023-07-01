namespace CalculationOfUtilities.ConsoleUI
{
    public class ElectricityServiceDialog : ServiceDialog
    {
        public Counter.MeteringDeviceSpan MeteringDeviceSpanNight { private set; get; }

        public ElectricityServiceDialog(string name) : base(name)
        {
        }

        protected override void OnGetAccountingDeviceInfo()
        {
            MeteringDeviceSpan = MakeMeteringDeviceSpan("Day");
            MeteringDeviceSpanNight = MakeMeteringDeviceSpan("Night");
        }

        private Counter.MeteringDeviceSpan MakeMeteringDeviceSpan(string name)
        {
            System.Console.Write($"Enter the current indications ({name}): ");
            float currentIndications = float.Parse(System.Console.ReadLine());

            System.Console.Write($"Enter the previous indications ({name}): ");
            float prevIndications = float.Parse(System.Console.ReadLine());

            return new Counter.MeteringDeviceSpan(currentIndications, prevIndications);
        }
    }
}
