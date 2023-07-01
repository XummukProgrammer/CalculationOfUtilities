namespace CalculationOfUtilities.Factory
{
    public class ServiceFactory
    {
        public TService MakeServiceWithDialog<TDialog, TService>(Core.Context context) where TDialog : ConsoleUI.ServiceDialog where TService : Services.IService
        {
            TDialog dialog = System.Activator.CreateInstance(typeof(TDialog), typeof(TService).Name) as TDialog;
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
    }
}
