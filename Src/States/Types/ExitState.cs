namespace CalculationOfUtilities.States
{
    public class ExitState : IState
    {
        public void OnEnter(Core.Context context)
        {
            context.IsExit = true;

            context.Database.Disconnect();
        }

        public void OnExit(Core.Context context)
        {
        }

        public void OnUpdate(Core.Context context)
        {
        }
    }
}
