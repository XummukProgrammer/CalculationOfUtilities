namespace CalculationOfUtilities.States
{
    public class InitializationState : IState
    {
        public void OnEnter(Core.Context context)
        {
            ConsoleUI.ResidentsDialog residentsDialog = new ConsoleUI.ResidentsDialog();
            residentsDialog.Exec();
            context.Residents = residentsDialog.Residents;

            Factory.ServiceFactory serviceFactory = new Factory.ServiceFactory();
            context.ServicesManager.AddService(serviceFactory.MakeServiceWithDialog<ConsoleUI.ServiceDialog, Services.ColdWaterSupplyService>(context));
            context.ServicesManager.AddService(serviceFactory.MakeServiceWithDialog<ConsoleUI.ServiceDialog, Services.HotWaterSupplyHeatCarrierService>(context));
            context.ServicesManager.AddService(serviceFactory.MakeServiceWithDialog<ConsoleUI.ServiceDialog, Services.HotWaterSupplyThermalEnergyService>(context));
            context.ServicesManager.AddService(serviceFactory.MakeServiceWithDialog<ConsoleUI.ElectricityServiceDialog, Services.ElectricityService>(context));
        }

        public void OnExit(Core.Context context)
        {
        }

        public void OnUpdate(Core.Context context)
        {
            context.StatesManager.SetCurrentState<ShowResultsState>();
        }
    }
}
