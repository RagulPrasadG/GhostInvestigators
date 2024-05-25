using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuntState : IState
{
    public GhostController Owner { get; set; }

    private bool isMoving = false;

    public void OnStateEnter()
    {
        Debug.Log("Starting Hunt!");
    }

    public void OnStateExit()
    {
       
    }

    public void Update()
    {
        if (isMoving) return;

        Owner.ghostView.FlickerGhostModel();
        Owner.ghostView.animator.SetFloat("Speed", 1f);


        if (Owner.playerPosition != Vector3.zero)
            Owner.Hunt(Owner.playerPosition);

        else
            Owner.ghostStatemachine.ChangeState(States.ROAM);
    }
}
