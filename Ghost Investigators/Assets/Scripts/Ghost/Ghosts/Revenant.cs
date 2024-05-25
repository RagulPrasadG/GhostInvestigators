using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Revenant : GhostController
{
    public Revenant(GhostView ghostView) : base(ghostView)  
    {
       
    }

    public override void Hunt(Vector3 playerPosition)
    {
        TryInteract();
        FindPlayer();
        if (isPlayerInFov)
        {
            ghostView.navMeshAgent.speed = ghostView.ghostTrait.LOSSpeed;
            ghostView.navMeshAgent.SetDestination(playerPosition);
        }

        if (ghostView.navMeshAgent.remainingDistance <= 0.2f && isPlayerInFov)
        {
            //Kill player
            ghostStatemachine.ChangeState(States.IDLE);
        }
    }

    public override void Roam(Vector3 randomPosition)
    {
        TryInteract();
        if (HasReachedDestination() && isMoving)
        {
            isMoving = false;
            ghostStatemachine.ChangeState(States.IDLE);
        }

        FindPlayer();

        if (randomPosition != Vector3.zero)
        {
            isMoving = true;
            ghostView.navMeshAgent.SetDestination(randomPosition);
        }
        else
        {
            ghostStatemachine.ChangeState(States.IDLE);
        }


    }
}
