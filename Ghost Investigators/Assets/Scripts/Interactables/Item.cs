using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour, IThrowable
{
    public bool canThrow { get; set; }
    public int  emfLevel { get; set; }
    public bool throwCoolDown { get; set; }

    private Rigidbody itemRigidbody;


    private void Awake()
    {
        itemRigidbody = GetComponent<Rigidbody>();
        canThrow = true;
    }
    
    public void Throw(float force)
    {

        itemRigidbody?.AddForce(Vector3.up + Vector3.right * force, ForceMode.Impulse);
        Debug.Log("Thrown!");
    }

}
