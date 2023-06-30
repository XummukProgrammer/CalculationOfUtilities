using System.Collections.Generic;

namespace CalculationOfUtilities.Services
{
    public class ServicesCalculatedInfos
    {
        private List<ServiceCalculatedInfo> _infos = new List<ServiceCalculatedInfo>();
        public float TotalSum { set; get; }
        public IEnumerator<ServiceCalculatedInfo> Infos => _infos.GetEnumerator();

        public void AddInfo(ServiceCalculatedInfo info)
        {
            _infos.Add(info);
        }
    }
}
