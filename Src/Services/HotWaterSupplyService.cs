namespace CalculationOfUtilities.Services
{
    public class HotWaterSupplyService : IService
    {
        private Counter.ICounter _counter;

        public HotWaterSupplyService(Counter.ICounter counter)
        {
            _counter = counter;
        }

        public float GetPrice(Core.Context context)
        {
            return 0;
        }
    }
}
