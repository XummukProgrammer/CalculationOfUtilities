namespace CalculationOfUtilities.Counter
{
    public class MeteringDeviceCounter : ICounter
    {
        public Counter.MeteringDeviceSpan Span { private set; get; }

        public MeteringDeviceCounter(Counter.MeteringDeviceSpan span)
        {
            Span = span;
        }

        public float GetVolume(Services.IService service)
        {
            if (Span != null)
            {
                return Span.GetVolume();
            }
            return 0;
        }
    }
}
