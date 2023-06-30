using CalculationOfUtilities.Core;

namespace CalculationOfUtilities.States
{
    public class ExitState : IState
    {
        public void OnEnter(Context context)
        {
            context.IsExit = true;
        }

        public void OnExit(Context context)
        {
        }

        public void OnUpdate(Context context)
        {
        }
    }
}
