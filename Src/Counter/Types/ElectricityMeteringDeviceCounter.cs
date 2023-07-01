namespace CalculationOfUtilities.Counter
{
    public class ElectricityMeteringDeviceCounter : MeteringDeviceCounter
    {
        public Counter.MeteringDeviceSpan NightSpan { private set; get; }

        public ElectricityMeteringDeviceCounter(Counter.MeteringDeviceSpan daySpan, MeteringDeviceSpan nightSpan) : base(daySpan)
        {
            NightSpan = nightSpan;
        }

        public float GetNightVolume()
        {
            if (NightSpan != null)
            {
                return NightSpan.GetVolume();
            }
            return 0;
        }
    }
}
