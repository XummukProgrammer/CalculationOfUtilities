namespace CalculationOfUtilities.Counter
{
    public class MeteringDeviceCounter : ICounter
    {
        private Counter.MeteringDeviceSpan _span;

        public MeteringDeviceCounter(Counter.MeteringDeviceSpan span)
        {
            _span = span;
        }

        public float GetVolume(Services.IService service)
        {
            if (_span != null)
            {
                return _span.GetVolume();
            }
            return 0;
        }
    }
}
