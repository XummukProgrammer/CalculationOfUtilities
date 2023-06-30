namespace CalculationOfUtilities.Core
{
    public class Application
    {
        public Context Context { private set; get; } = new Context();

        public void Exec()
        {
            while (!Context.IsExit)
            {
                Context.StatesManager.OnUpdate(Context);
            }
        }
    }
}
