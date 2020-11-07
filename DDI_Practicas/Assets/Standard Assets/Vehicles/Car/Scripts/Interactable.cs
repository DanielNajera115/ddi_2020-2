using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Vehicles.Car
{
    public class Interactable : MonoBehaviour
    {
        

        private bool inZoneCollider = false;
        
        // Start is called before the first frame update

        public virtual void Interact(){}
        
        public virtual void NotInteract(){}
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        { 
            if(inZoneCollider){
                Interact();
            }else{
                NotInteract();
            }   
        }

        void OnTriggerEnter(Collider other)
        {
            if(!other.CompareTag("Player"))
            {
            return;
            }
            inZoneCollider = true;   
        }

        void OnTriggerExit(Collider other)
        {
            if(!other.CompareTag("Player"))
            {
            return;
            }
            inZoneCollider = false;
        }
    }
}