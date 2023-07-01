namespace CalculationOfUtilities
{
    public class Program
    {
        static void Main(string[] args)
        {
            Core.Application app = new Core.Application();
            app.Context.StatesManager.AddState<States.ExitState>();
            app.Context.StatesManager.AddState<States.InitializationState>();
            app.Context.StatesManager.AddState<States.ShowResultsState>();
            app.Context.StatesManager.AddState<States.SubmitState>();
            app.Context.StatesManager.SetCurrentState<States.InitializationState>();
            app.Exec();
        }
    }
}
