namespace CalculationOfUtilities.Counter
{
    public class RegulatoryScopeCounter : ICounter
    {
        private uint _residents;

        public RegulatoryScopeCounter(uint residents)
        {
            _residents = residents;
        }

        public float GetVolume(Services.IService service)
        {
            if (service != null)
            {
                return _residents * service.GetStandart();
            }
            return 0;
        }
    }
}
