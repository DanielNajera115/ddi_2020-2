using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Interactable : MonoBehaviour
{
    bool isInsideZone = false;

    public virtual void Interact()
    {
        
    }

    public virtual void NotInteract()
    {
        
    }    

    void OnTriggerEnter(Collider other)
    {  
        
        if (!other.CompareTag("Player"))
        {

            return;
        }
        Interact();
        
    }

    void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            return;
        }
        NotInteract();
    }


    
}
