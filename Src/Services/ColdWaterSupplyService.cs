namespace CalculationOfUtilities.Services
{
    public class ColdWaterSupplyService : IService
    {
        private Counter.ICounter _counter;

        public ColdWaterSupplyService(Counter.ICounter counter)
        {
            _counter = counter;
        }

        public float GetPrice(Core.Context context)
        {
            if (_counter != null)
            {
                return _counter.GetVolume() * context.Settings.Rates.GetColdWaterSupply();
            }
            return 0;
        }
    }
}
