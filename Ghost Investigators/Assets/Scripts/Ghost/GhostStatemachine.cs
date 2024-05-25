using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostStatemachine : GenericStateMachine<GhostController>
{

    public GhostStatemachine(GhostController Owner) : base(Owner)
    {
        this.Owner = Owner;
        CreateStates();
        SetOwner();
    }

    private void CreateStates()
    {
        states.Add(States.ROAM, new RoamState());
        states.Add(States.IDLE, new IdleState());
        states.Add(States.HUNT, new HuntState());
    }

}
