namespace CalculationOfUtilities.Counter
{
    public class ElectricityMeteringDeviceCounter : MeteringDeviceCounter
    {
        private Counter.MeteringDeviceSpan _nightSpan;

        public ElectricityMeteringDeviceCounter(Counter.MeteringDeviceSpan daySpan, MeteringDeviceSpan nightSpan) : base(daySpan)
        {
            _nightSpan = nightSpan;
        }

        public float GetNightVolume()
        {
            if (_nightSpan != null)
            {
                return _nightSpan.GetVolume();
            }
            return 0;
        }
    }
}
