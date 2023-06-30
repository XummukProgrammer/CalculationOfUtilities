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
                float rate = 0;
                return _counter.GetVolume() * rate;
            }
            return 0;
        }
    }
}
