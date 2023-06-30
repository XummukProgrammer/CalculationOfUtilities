namespace CalculationOfUtilities.Services
{
    public class ColdWaterSupplyService : IService
    {
        private Core.Context _context;
        private Counter.ICounter _counter;

        public ColdWaterSupplyService(Core.Context context, Counter.ICounter counter)
        {
            _context = context;
            _counter = counter;
        }

        public float GetPrice()
        {
            if (_context != null && _counter != null)
            {
                return _counter.GetVolume(this) * _context.Settings.Rates.GetColdWaterSupply();
            }
            return 0;
        }

        public float GetStandart()
        {
            if (_context != null)
            {
                return _context.Settings.Standarts.GetColdWaterSupply();
            }
            return 0;
        }
    }
}
