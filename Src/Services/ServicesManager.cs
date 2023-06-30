using System.Collections.Generic;

namespace CalculationOfUtilities.Services
{
    public class ServicesManager
    {
        private List<Services.IService> _services = new List<Services.IService>();

        public void AddService<T>(Core.Context context, Counter.ICounter counter) where T : Services.IService
        {
            _services.Add((T)System.Activator.CreateInstance(typeof(T), context, counter));
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

        public ServicesCalculatedInfos Calculate()
        {
            ServicesCalculatedInfos infos = new ServicesCalculatedInfos();
            float totalSum = 0;

            foreach (var service in _services)
            {
                ServiceCalculatedInfo info = new ServiceCalculatedInfo(service.GetType().Name, service.GetPrice());
                totalSum += info.Price;
                infos.AddInfo(info);
            }

            infos.TotalSum = totalSum;
            return infos;
        }
    }
}
