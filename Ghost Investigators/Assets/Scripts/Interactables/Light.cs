using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light : MonoBehaviour, IInteractable
{
    [SerializeField] Light lightComponent;

   public int emfLevel { get ; set; }
   
    public void Interact()
    {
        ToggleLight();
    }

    public void ToggleLight()
    {
        lightComponent.ToggleLight();
    }

}
