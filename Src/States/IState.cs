namespace CalculationOfUtilities.States
{
    public interface IState
    {
        void OnEnter(Core.Context context);
        void OnExit(Core.Context context);

        void OnUpdate(Core.Context context);
    }
}
