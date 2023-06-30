namespace CalculationOfUtilities
{
    public class Program
    {
        static void Main(string[] args)
        {
            Core.Context context = new Core.Context();
            context.ServicesManager.AddService<Services.ColdWaterSupplyService>(context, new Counter.MeteringDeviceCounter(new Counter.MeteringDeviceSpan(26, 0)));
            context.ServicesManager.AddService<Services.HotWaterSupplyHeatCarrierService>(context, new Counter.MeteringDeviceCounter(new Counter.MeteringDeviceSpan(1, 0)));
            context.ServicesManager.AddService<Services.HotWaterSupplyThermalEnergyService>(context, new Counter.MeteringDeviceCounter(new Counter.MeteringDeviceSpan(1, 0)));
            context.ServicesManager.AddService<Services.ElectricityService>(context, new Counter.ElectricityMeteringDeviceCounter(new Counter.MeteringDeviceSpan(91, 0), new Counter.MeteringDeviceSpan(91, 0)));

            var servicesCalculatedInfos = context.ServicesManager.Calculate();
            var infos = servicesCalculatedInfos.Infos;

            while (infos.MoveNext())
            {
                var info = infos.Current;
                System.Console.WriteLine($"Name: {info.Name}, Price: {info.Price}");
            }

            System.Console.WriteLine($"Total Sum: {servicesCalculatedInfos.TotalSum}");
            System.Console.ReadKey();
        }
    }
}
