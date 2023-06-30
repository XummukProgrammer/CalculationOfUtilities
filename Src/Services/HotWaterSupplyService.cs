namespace CalculationOfUtilities.Services
{
    public class HotWaterSupplyService : IService
    {
        private Core.Context _context;
        private Counter.ICounter _counter;

        public HotWaterSupplyService(Core.Context context, Counter.ICounter counter)
        {
            _context = context;
            _counter = counter;
        }

        public float GetPrice()
        {
            return 0;
        }

        public float GetStandart()
        {
            return 0;
        }
    }
}
