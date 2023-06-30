namespace CalculationOfUtilities.Counter
{
    public class MeteringDeviceSpan
    {
        public float CurrentIndications { private set; get; }
        public float PrevIndications { private set; get; }

        public MeteringDeviceSpan(float currentIndications, float prevIndications)
        {
            CurrentIndications = currentIndications;
            PrevIndications = prevIndications;
        }

        public float GetVolume()
        {
            return CurrentIndications - PrevIndications;
        }
    }
}
