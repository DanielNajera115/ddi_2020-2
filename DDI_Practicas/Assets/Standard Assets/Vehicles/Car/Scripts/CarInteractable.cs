using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Vehicles.Car
{
    public class CarInteractable : Interactable
    {
        private Text interactableLabel;

        private bool inZoneCollider1 = false;
        public CarUserControl rCar;
        private bool pauseTooggle=false;
        private Camera cameraFPCharacter;
        private Camera cameraCarCharacter;
        // Start is called before the first frame update

         
        void Awake()
        {
            interactableLabel = GameObject.Find("InteractableMessageLbl").GetComponent<Text>();
            rCar = GetComponent<CarUserControl>();
            cameraFPCharacter = GameObject.Find("MainCamera").GetComponent<Camera>();
            cameraCarCharacter = GameObject.Find("CarCamera").GetComponent<Camera>();
            cameraFPCharacter.enabled = true;
            cameraCarCharacter.enabled = false;
        }

        // Update is called once per frame
        void FixedUpdate()
        {
           
           if(inZoneCollider1){
                interactableLabel.text = "Presione i para interactuar";
                Debug.Log("Yoda");
                if (Input.GetKeyDown(KeyCode.I))
                {
                    if(!pauseTooggle){
                        pauseTooggle=true;
                        rCar.setCarOn();
                        cameraFPCharacter.enabled = false;
                        cameraCarCharacter.enabled = true;
                    }else{
                        pauseTooggle=false;
                        rCar.setCarOff();
                        cameraFPCharacter.enabled = true;
                        cameraCarCharacter.enabled = false;
                    }
                }
            }else{
                interactableLabel.text = "";
            }
            
        }
        public override void Interact()
        {
            base.Interact();
            Debug.Log("Holo");
            inZoneCollider1 = true;
            
            
        }

        public override void NotInteract()
        {
            base.NotInteract();
            inZoneCollider1 = false;
        }
        
    }
}