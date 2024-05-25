using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Door : MonoBehaviour, IInteractable
{

    [SerializeField] float doorOpenAngle;
    [Range(0, 360)]
    [SerializeField] float doorOpenPercentage;
    private float doorCloseAngle = 0;
    private bool isClosed = true;
    public int emfLevel { get; set; }

    public void Interact()
    {
        if (isClosed)
        {
            var openAngle = Quaternion.Euler(0, Mathf.Abs(doorOpenAngle - doorOpenPercentage), 0);
            transform.DORotateQuaternion(openAngle, 1f);
            Debug.Log("Door Opened!!");
        }
        else
        {
            var closeAngle = Quaternion.Euler(0, Mathf.Abs(doorCloseAngle - doorOpenPercentage), 0);
            transform.DORotateQuaternion(closeAngle, 1f);
            Debug.Log("Door Closed!!");

        }
        isClosed = !isClosed;
    }
}
