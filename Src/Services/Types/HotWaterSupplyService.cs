namespace CalculationOfUtilities.Services
{
    public class HotWaterSupplyHeatCarrierService : IService
    {
        private Core.Context _context;
        private Counter.ICounter _counter;

        public HotWaterSupplyHeatCarrierService(Core.Context context, Counter.ICounter counter)
        {
            _context = context;
            _counter = counter;
        }

        public float GetPrice()
        {
            if (_context != null && _counter != null)
            {
                return GetVolume() * _context.Settings.Rates.GetHotWaterSupplyHeatCarrier();
            }
            return 0;
        }

        public float GetVolume()
        {
            return _counter.GetVolume(this);
        }

        public float GetStandart()
        {
            if (_context != null)
            {
                return _context.Settings.Standarts.GetHotWaterSupplyHeatCarrier();
            }
            return 0;
        }

        public Counter.ICounter GetCounter()
        {
            return _counter;
        }
    }

    public class HotWaterSupplyThermalEnergyService : IService
    {
        private Core.Context _context;
        private HotWaterSupplyHeatCarrierService _heatCarrierService;

        public HotWaterSupplyThermalEnergyService(Core.Context context, Counter.ICounter counter)
        {
            _context = context;

            if (_context != null)
            {
                _heatCarrierService = _context.ServicesManager.GetService<HotWaterSupplyHeatCarrierService>();
            }
        }

        public Counter.ICounter GetCounter()
        {
            if (_heatCarrierService != null)
            {
                return _heatCarrierService.GetCounter();
            }
            return null;
        }

        public float GetPrice()
        {
            if (_context != null && _heatCarrierService != null)
            {
                return _heatCarrierService.GetVolume() * _context.Settings.Rates.GetHotWaterSupplyThermalEnergy();
            }
            return 0;
        }

        public float GetStandart()
        {
            if (_context != null)
            {
                return _context.Settings.Standarts.GetHotWaterSupplyThermalEnergy();
            }
            return 0;
        }
    }
}
