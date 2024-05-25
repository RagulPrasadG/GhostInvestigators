using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;

public abstract class GhostController
{
    public GhostStatemachine ghostStatemachine;
    public GhostView ghostView;
    public float currentSpeed;
    public float modelFlickerTimer;
    public float totalFlickerTime;
    public Vector3 playerPosition;
    public bool isPlayerInFov;
    protected bool isPlayerInRange;
    protected bool isMoving = false;
    public bool canThrowItems = false;

    public GhostController(GhostView ghostView)
    {
        this.ghostView = ghostView;
        ghostView.SetController(this);
        this.currentSpeed = ghostView.ghostTrait.patrolSpeed;
        ghostView.navMeshAgent.speed = this.currentSpeed;
        ghostStatemachine = new GhostStatemachine(this);
        ghostStatemachine.ChangeState(States.IDLE);
        totalFlickerTime = Random.Range(0, ghostView.ghostTrait.modelFlickerTime);
    }

    public void Update()
    {
        ghostStatemachine.Update();
    }

    public Vector3 GetRandomRoamPosition()
    {
        Vector3 centerPoint = ghostView.transform.position + Random.insideUnitSphere * ghostView.ghostTrait.roamingRadius;
        NavMeshHit navMeshHit;

        if(NavMesh.SamplePosition(centerPoint,out navMeshHit,1.0f,NavMesh.AllAreas))
        {
            return navMeshHit.position;
        }
        return Vector3.zero;
    }

    public Vector3 GetPlayerPositionInNavMesh(Vector3 playerPosition)
    {
        NavMeshHit navMeshHit;
        if (NavMesh.SamplePosition(playerPosition, out navMeshHit, 1.0f, NavMesh.AllAreas))
        {
            return navMeshHit.position;
        }
        return Vector3.zero;
    }

    public bool GetFieldOfViewAngle(Vector3 from, Vector3 to, out float angle)
    {
        float angleY = Vector3.Angle(from, to);
        if (angleY < ghostView.ghostTrait.fieldOfView / 2 || angleY > -ghostView.ghostTrait.fieldOfView / 2)
        {
            angle = angleY;
            return true;
        }
        angle = 0f;
        return false;
    }

    public void FindPlayer()
    {
        
        Collider[] colliders = Physics.OverlapSphere(ghostView.transform.position, ghostView.LOSRange,ghostView.playerMask);
        foreach(var collider in colliders)
        {
            isPlayerInRange = true;
            Debug.Log("Player in Range!!!");
            Vector3 direction = (collider.transform.position - ghostView.LOSTransform.position);
            float fieldOfViewAngle;
            GetFieldOfViewAngle(ghostView.LOSTransform.forward, direction, out fieldOfViewAngle);

            if(fieldOfViewAngle < ghostView.ghostTrait.fieldOfView)
            {
                float distanceToPlayer = Vector3.Distance(ghostView.transform.position, collider.transform.position);
                if(!Physics.Raycast(ghostView.LOSTransform.position,direction,distanceToPlayer,ghostView.obstacleMask))
                {
                    isPlayerInFov = true;
                    playerPosition = GetPlayerPositionInNavMesh(collider.transform.position);
                    Debug.Log("Player in FOV!!!");
                    return;
                }
            }
        }
        isPlayerInRange = false;
    }

    public virtual void TryInteract()
    {
        if (!canThrowItems)
            return;
        
        
       

        Collider[] colliders = Physics.OverlapSphere(ghostView.transform.position, ghostView.LOSRange, ghostView.interactableMask);
        foreach (var collider in colliders)
        {
            int interactionValue = Random.Range(0, 100);
            if (interactionValue <= ghostView.ghostTrait.interactionRate)
            {

                IThrowable throwable;
                IInteractable interactable;
                collider.TryGetComponent<IThrowable>(out throwable);
                collider.TryGetComponent<IInteractable>(out interactable);
                if (throwable != null)
                {
                    throwable.Throw(ghostView.ghostTrait.throwforce);
                }
                if(interactable != null)
                {
                    interactable.Interact();
                }
                break;
            }
            else
            {
                continue;
            }
                
        }
        canThrowItems = false;

    }

    public Vector3 GetDirectionFromAngle(float angle)
    {
        angle += ghostView.LOSTransform.transform.eulerAngles.y;
        return new Vector3(Mathf.Sin(angle * Mathf.Deg2Rad), 0f, Mathf.Cos(angle * Mathf.Deg2Rad));
    }

    public bool HasReachedDestination() => ghostView.navMeshAgent.remainingDistance <= 0.1f;


    public abstract void Hunt(Vector3 position);
    public abstract void Roam(Vector3 position);
}
