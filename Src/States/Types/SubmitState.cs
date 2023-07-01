using CalculationOfUtilities.Core;

namespace CalculationOfUtilities.States
{
    public class SubmitState : IState
    {
        public void OnEnter(Context context)
        {
            context.ServicesManager.Sumbit(context);
        }

        public void OnExit(Context context)
        {
        }

        public void OnUpdate(Context context)
        {
            context.StatesManager.SetCurrentState<ExitState>();
        }
    }
}
