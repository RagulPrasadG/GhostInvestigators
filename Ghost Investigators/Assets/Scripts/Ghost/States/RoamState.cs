using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RoamState : IState
{
    public GhostController Owner { get; set; }
 
    private Vector3 randomPosition;
    private float modelFlickerRate;

    public void OnStateEnter()
    {
        Owner.currentSpeed = Owner.ghostView.ghostTrait.patrolSpeed;
        Owner.ghostView.animator.SetFloat("Speed", 1f);
        Debug.Log(Owner.ghostView.animator.GetFloat("Speed"));
        randomPosition = Owner.GetRandomRoamPosition();
    }

    public void OnStateExit()
    {

        
    }

    public void Update()
    {

        Owner.ghostView.FlickerGhostModel();
        Owner.Roam(randomPosition);
    }
   
   
   
}
