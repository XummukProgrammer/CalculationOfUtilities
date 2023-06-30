using System.Collections.Generic;

namespace CalculationOfUtilities.Services
{
    public class ServicesManager
    {
        private List<Services.IService> _services = new List<Services.IService>();

        public void AddService<T>(Counter.ICounter counter) where T : Services.IService
        {
            _services.Add((T)System.Activator.CreateInstance(typeof(T), counter));
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
