using System.Collections.Generic;
using System.Linq;

namespace CalculationOfUtilities.Services
{
    public class ServicesManager
    {
        private List<Services.IService> _services = new List<Services.IService>();

        public void AddService<T>() where T : Services.IService
        {
            _services.Add(System.Activator.CreateInstance<T>());
        }

        public T GetService<T>() where T : Services.IService
        {
            foreach (var service in _services)
            {
                if (service is T castedService)
                {
                    return castedService;
                }
            }
            return default(T);
        }
    }
}
