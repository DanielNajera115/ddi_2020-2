using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Vehicles.Car
{
    public class CarInteractable : MonoBehaviour
    {
        private Text interactableLabel;

        private bool inZoneCollider = false;
        public CarUserControl rCar;
        private bool pauseTooggle=false;
        private Camera cameraFPCharacter;
        private Camera cameraCarCharacter;
        // Start is called before the first frame update

        public virtual void Interact()
        {
            
        } 
        void Start()
        {
            interactableLabel = GameObject.Find("InteractableMessageLbl").GetComponent<Text>();
            rCar = GetComponent<CarUserControl>();
            cameraFPCharacter = GameObject.Find("MainCamera").GetComponent<Camera>();
            cameraCarCharacter = GameObject.Find("CarCamera").GetComponent<Camera>();
            cameraFPCharacter.enabled = true;
            cameraCarCharacter.enabled = false;
        }

        // Update is called once per frame
        void Update()
        {
            
            if(inZoneCollider){
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
                Interact();
            }else{
                interactableLabel.text = "";
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