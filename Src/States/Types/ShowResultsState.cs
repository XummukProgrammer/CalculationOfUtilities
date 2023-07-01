namespace CalculationOfUtilities.States
{
    public class ShowResultsState : IState
    {
        public void OnEnter(Core.Context context)
        {
            var servicesCalculatedInfos = context.ServicesManager.Calculate();
            var infos = servicesCalculatedInfos.Infos;

            while (infos.MoveNext())
            {
                var info = infos.Current;
                System.Console.WriteLine($"Name: {info.Name}, Price: {info.Price}");
            }

            System.Console.WriteLine($"Total Sum: {servicesCalculatedInfos.TotalSum}");
        }

        public void OnExit(Core.Context context)
        {
        }

        public void OnUpdate(Core.Context context)
        {
            System.Console.ReadKey();
            context.StatesManager.SetCurrentState<ExitState>();
        }
    }
}
