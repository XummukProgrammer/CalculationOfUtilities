namespace CalculationOfUtilities
{
    public class Program
    {
        static void Main(string[] args)
        {
            Core.Context context = new Core.Context();
            context.ServicesManager.AddService<Services.ColdWaterSupplyService>();
            context.ServicesManager.AddService<Services.HotWaterSupplyService>();
            context.ServicesManager.AddService<Services.ElectricityService>();

            context.Counter = new Counter.BaseCounter();
        }
    }
}
