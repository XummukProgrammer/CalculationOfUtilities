namespace CalculationOfUtilities.Counter
{
    public class MeteringDeviceCounter : ICounter
    {
        private float _currentIndications;
        private float _prevIndications;

        public MeteringDeviceCounter(float currentIndications, float prevIndications)
        {
            _currentIndications = currentIndications;
            _prevIndications = prevIndications;
        }

        public float GetVolume()
        {
            return _currentIndications - _prevIndications;
        }
    }
}
