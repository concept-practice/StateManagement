using System;
using System.Collections.Generic;
using StateManagement.State.Events;

namespace StateManagement.State
{
    public class StateStore
    {
        private readonly Dictionary<Type, Action<IAction>> _actions;

        public InitialState State { get; } 

        public StateStore()
        {
            State = new InitialState();

            _actions = new Dictionary<Type, Action<IAction>>
            {
                { typeof(IncreaseCounter), action => UpdateState(state => ++state.Count) },
                { typeof(DecreaseCounter), action => UpdateState(state => --state.Count) },
                { typeof(CustomCounterAdjustment), action => UpdateState(state => state.Count = (action as CustomCounterAdjustment).Amount) },
            };
        }

        public void Publish(IAction action)
        {
            _actions[action.GetType()].Invoke(action);
        }

        private void UpdateState(Action<InitialState> stateAction)
        {
            stateAction.Invoke(State);
            ApplicationStateChangedHandler?.Invoke(this, new ApplicationStateChanged());
        }

        public event EventHandler<ApplicationStateChanged> ApplicationStateChangedHandler;
    }
}
