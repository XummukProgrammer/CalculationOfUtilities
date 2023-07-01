namespace CalculationOfUtilities.ConsoleUI
{
    public class ServiceDialog
    {
        public bool HasAccountingDevice { private set; get; }
        public Counter.MeteringDeviceSpan MeteringDeviceSpan { protected set; get; }

        private string _name;

        public ServiceDialog(string name)
        {
            _name = name;
        }

        public void Exec()
        {
            System.Console.WriteLine($"Service: {_name}");
            System.Console.Write("Do you have a service accounting device (y/n)?: ");
            HasAccountingDevice = System.Console.ReadLine()[0] == 'y';

            if (HasAccountingDevice)
            {
                OnGetAccountingDeviceInfo();
            }

            System.Console.Clear();
        }

        protected virtual void OnGetAccountingDeviceInfo()
        {
            System.Console.Write("Enter the current indications: ");
            float currentIndications = float.Parse(System.Console.ReadLine());

            System.Console.Write("Enter the previous indications: ");
            float prevIndications = float.Parse(System.Console.ReadLine());

            MeteringDeviceSpan = new Counter.MeteringDeviceSpan(currentIndications, prevIndications);
        }
    }
}
