namespace CalculationOfUtilities.Services
{
    public class ElectricityService : IService
    {
        private Core.Context _context;
        private Counter.ICounter _counter;


        public ElectricityService(Core.Context context, Counter.ICounter counter)
        {
            _context = context;
            _counter = counter;
        }

        public Counter.ICounter GetCounter()
        {
            return _counter;
        }

        public float GetPrice()
        {
            if (_context != null && _counter != null)
            {
                if (_counter is Counter.ElectricityMeteringDeviceCounter castedCounter)
                {
                    float dayRate = _context.Settings.Rates.GetDayElectricity();
                    float nightRate = _context.Settings.Rates.GetNightElectricity();
                    return castedCounter.GetVolume(this) * dayRate + castedCounter.GetNightVolume() * nightRate;
                }
                else
                {
                    return _counter.GetVolume(this) * _context.Settings.Rates.GetElectricity();
                }
            }
            return 0;
        }

        public float GetStandart()
        {
            if (_context != null)
            {
                return _context.Settings.Standarts.GetElectricity();
            }
            return 0;
        }
    }
}
