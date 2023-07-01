using System.Collections.Generic;

namespace CalculationOfUtilities.Services
{
    public class ServicesManager
    {
        private List<Services.IService> _services = new List<Services.IService>();

        public void AddService(IService service)
        {
            _services.Add(service);
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

        public void Sumbit(Core.Context context)
        {
            int mountId = context.Database.CreateMount(context);
            if (mountId == -1)
            {
                return;
            }

            Factory.ServiceFactory serviceFactory = new Factory.ServiceFactory();

            foreach (var service in _services)
            {
                serviceFactory.SubmitServiceToDatabase(context, mountId, service);
            }
        }
    }
}
