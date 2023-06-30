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
                    float dayRate = 0;
                    float nightRate = 0;
                    return castedCounter.GetVolume() * dayRate + castedCounter.GetNightVolume() * nightRate;
                }
                else
                {
                    float rate = 0;
                    return _counter.GetVolume() * rate;
                }
            }
            return 0;
        }
    }
}
