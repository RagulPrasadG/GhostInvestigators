using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GhostView : MonoBehaviour
{
    [SerializeField] bool isActive;
    
    public NavMeshAgent navMeshAgent;
    public Animator animator;
    public Transform LOSTransform;

    [Range(0, 100)]
    public float LOSRange;
    public GhostTrait ghostTrait;
    public GameObject ghostModelTransform;

    public GhostController ghostController;
    public bool isGhostModelVisible;

    public LayerMask playerMask;
    public LayerMask obstacleMask;
    public LayerMask interactableMask;
    public void SetController(GhostController ghostcontroller)
    {
        this.ghostController = ghostcontroller;
    }

    public void Update()
    {
        if (!isActive)
            return;

        ghostController?.Update(); 
    }


    public void FlickerGhostModel()
    {
        StartCoroutine(FlickerGhostInterval());
    }
   
    private IEnumerator FlickerGhostInterval()
    {
        ghostModelTransform.SetActive(false);
        yield return new WaitForSeconds(ghostController.totalFlickerTime);
        ghostModelTransform.SetActive(true);
        ghostController.totalFlickerTime = Random.Range(ghostTrait.maxFlickerTime, ghostTrait.modelFlickerTime);
    }

    public bool IsInFieldOfView(Vector3 from,Vector3 to,out float angle)
    {
        float angleY = Vector3.Angle(from, to);
        if(angleY < ghostTrait.fieldOfView/2 || angleY > -ghostTrait.fieldOfView/2)
        {
            angle = angleY;
            return true;
        }
        angle = 0f;
        return false;
    }

    public void SetRandomGhostModel()
    {

    }

}
