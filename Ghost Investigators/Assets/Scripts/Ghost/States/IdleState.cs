using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IState
{
    public GhostController Owner { get ; set; }
    private float idleTimer;

    public void OnStateEnter()
    {
        Owner.currentSpeed = 0;
        Owner.ghostView.animator.SetFloat("Speed", 0f);
    }

    public void OnStateExit()
    {
        idleTimer = 0;
    }

    public void Update()
    {
        Owner.ghostView.FlickerGhostModel();

        Owner.TryInteract();
        idleTimer += Time.deltaTime;
        if(idleTimer >= 3f)
        {
            Owner.canThrowItems = !Owner.canThrowItems;
            Owner.ghostStatemachine.ChangeState(States.IDLE);
        }

    }

}
