namespace CalculationOfUtilities.Services
{
    public class ElectricityService : IService
    {
        private Counter.ICounter _counter;


        public ElectricityService(Counter.ICounter counter)
        {
            _counter = counter;
        }

        public float GetPrice(Core.Context context)
        {
            if (_counter != null)
            {
                if (_counter is Counter.ElectricityMeteringDeviceCounter castedCounter)
                {
                    float dayRate = context.Settings.Rates.GetDayElectricity();
                    float nightRate = context.Settings.Rates.GetNightElectricity();
                    return castedCounter.GetVolume() * dayRate + castedCounter.GetNightVolume() * nightRate;
                }
                else
                {
                    return _counter.GetVolume() * context.Settings.Rates.GetElectricity();
                }
            }
            return 0;
        }
    }
}
