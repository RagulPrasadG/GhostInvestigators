using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericStateMachine<T> where T : GhostController
{
    protected T Owner;
    protected IState currentState;
    protected Dictionary<States, IState> states = new Dictionary<States, IState>();

    public GenericStateMachine(T Owner) => this.Owner = Owner;

    public void Update() => currentState?.Update();

    public void ChangeState(IState newState)
    {
        currentState?.OnStateExit();
        currentState = newState;
        currentState?.OnStateEnter();
    }

    public void ChangeState(States newState) => ChangeState(states[newState]);

    protected void SetOwner()
    {
        foreach (IState state in states.Values)
        {
            state.Owner = Owner;
        }
    }

}
