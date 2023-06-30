namespace CalculationOfUtilities.Counter
{
    public class RegulatoryScopeCounter : ICounter
    {
        private uint _residents;
        private float _standart;

        public RegulatoryScopeCounter(uint residents, float standart)
        {
            _residents = residents;
            _standart = standart;
        }

        public float GetVolume()
        {
            return _residents * _standart;
        }
    }
}
