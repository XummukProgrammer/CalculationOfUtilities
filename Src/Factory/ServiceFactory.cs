namespace CalculationOfUtilities.Factory
{
    public class ServiceFactory
    {
        public TService MakeServiceWithDialog<TDialog, TService>(Core.Context context) where TDialog : ConsoleUI.ServiceDialog where TService : Services.IService
        {
            TDialog dialog = System.Activator.CreateInstance(typeof(TDialog), context, typeof(TService).Name) as TDialog;
            dialog.Exec();

            Counter.ICounter counter = null;
            if (dialog.HasAccountingDevice)
            {
                if (dialog is ConsoleUI.ElectricityServiceDialog electricityServiceDialog)
                {
                    counter = new Counter.ElectricityMeteringDeviceCounter(electricityServiceDialog.MeteringDeviceSpan, electricityServiceDialog.MeteringDeviceSpanNight);
                }
                else
                {
                    counter = new Counter.MeteringDeviceCounter(dialog.MeteringDeviceSpan);
                }
            }
            else
            {
                counter = new Counter.RegulatoryScopeCounter(context.Residents);
            }

            TService service = (TService)System.Activator.CreateInstance(typeof(TService), context, counter);
            return service;
        }

        public void SubmitServiceToDatabase(Core.Context context, int mountId, Services.IService service)
        {
            // TODO: По сути Price уже известен, можно бы было получать какую-либо готовую информацию
            int serviceId = context.Database.CreateService(context, mountId, service.GetType().Name, service.GetPrice());
            if (serviceId == -1)
            {
                return;
            }

            // TODO: Внутри Counter обращаться к Database, чтобы не узнавать тип данных
            var counter = service.GetCounter();
            if (counter is Counter.ElectricityMeteringDeviceCounter electricityMeteringDeviceCounter)
            {
                context.Database.CreateElectricityMeteringDevice(serviceId, electricityMeteringDeviceCounter.Span, electricityMeteringDeviceCounter.NightSpan);
            }
            else if (counter is Counter.MeteringDeviceCounter meteringDeviceCounter)
            {
                context.Database.CreateMeteringDevice(serviceId, meteringDeviceCounter.Span);
            }
        }
    }
}
