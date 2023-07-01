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
                System.Console.WriteLine(context.TranslationsManager.GetTranslationText("CALCULATED_SERVICE_INFO"), context.TranslationsManager.GetTranslationText(info.Name), info.Price);
            }

            System.Console.WriteLine(context.TranslationsManager.GetTranslationText("TOTAL_SUM"), servicesCalculatedInfos.TotalSum);
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
