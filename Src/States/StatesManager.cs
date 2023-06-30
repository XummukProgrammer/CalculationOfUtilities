using System.Collections.Generic;

namespace CalculationOfUtilities.States
{
    public class StatesManager
    {
        private List<IState> _states = new List<IState>();
        private IState _currentState;
        private IState _nextState;

        public void AddState<T>() where T : IState
        {
            _states.Add(System.Activator.CreateInstance<T>());
        }

        public void SetCurrentState<T>() where T : IState
        {
            var newState = GetState<T>();
            if (newState == null)
            {
                return;
            }

            _nextState = newState;
        }

        private T GetState<T>() where T : IState
        {
            foreach (var state in _states)
            {
                if (state is T castedState)
                {
                    return castedState;
                }
            }
            return default(T);
        }

        public void OnUpdate(Core.Context context)
        {
            TryChangeState(context);

            if (_currentState != null)
            {
                _currentState.OnUpdate(context);
            }
        }

        private void TryChangeState(Core.Context context)
        {
            if (_nextState != null)
            {
                if (_currentState != null)
                {
                    _currentState.OnExit(context);
                }

                _nextState.OnEnter(context);
                _currentState = _nextState;
                _nextState = null;
            }
        }
    }
}
