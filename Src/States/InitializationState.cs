using CalculationOfUtilities.Core;

namespace CalculationOfUtilities.States
{
    public class InitializationState : IState
    {
        public void OnEnter(Context context)
        {
            context.ServicesManager.AddService<Services.ColdWaterSupplyService>(context, new Counter.MeteringDeviceCounter(new Counter.MeteringDeviceSpan(26, 0)));
            context.ServicesManager.AddService<Services.HotWaterSupplyHeatCarrierService>(context, new Counter.MeteringDeviceCounter(new Counter.MeteringDeviceSpan(1, 0)));
            context.ServicesManager.AddService<Services.HotWaterSupplyThermalEnergyService>(context, new Counter.MeteringDeviceCounter(new Counter.MeteringDeviceSpan(1, 0)));
            context.ServicesManager.AddService<Services.ElectricityService>(context, new Counter.ElectricityMeteringDeviceCounter(new Counter.MeteringDeviceSpan(91, 0), new Counter.MeteringDeviceSpan(91, 0)));
        }

        public void OnExit(Context context)
        {
        }

        public void OnUpdate(Context context)
        {
            context.StatesManager.SetCurrentState<ShowResultsState>();
        }
    }
}
