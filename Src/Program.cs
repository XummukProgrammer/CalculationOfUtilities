namespace CalculationOfUtilities
{
    public class Program
    {
        static void Main(string[] args)
        {
            Core.Context context = new Core.Context();
            context.ServicesManager.AddService<Services.ColdWaterSupplyService>(context, new Counter.MeteringDeviceCounter(new Counter.MeteringDeviceSpan(1, 0)));
            context.ServicesManager.AddService<Services.HotWaterSupplyService>(context, new Counter.MeteringDeviceCounter(new Counter.MeteringDeviceSpan(1, 0)));
            context.ServicesManager.AddService<Services.ElectricityService>(context, new Counter.MeteringDeviceCounter(new Counter.MeteringDeviceSpan(1, 0)));
        }
    }
}
