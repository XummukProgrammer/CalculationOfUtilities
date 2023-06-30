namespace CalculationOfUtilities
{
    public class Program
    {
        static void Main(string[] args)
        {
            Core.Context context = new Core.Context();
            context.ServicesManager.AddService<Services.ColdWaterSupplyService>(new Counter.MeteringDeviceCounter(1, 0));
            context.ServicesManager.AddService<Services.HotWaterSupplyService>(new Counter.MeteringDeviceCounter(1, 0));
            context.ServicesManager.AddService<Services.ElectricityService>(new Counter.MeteringDeviceCounter(1, 0));
        }
    }
}
