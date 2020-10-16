using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Vehicles.Car;

public class ThirdPersonInteractable : MonoBehaviour
{
 
    private Text interactableLabel;

    private bool inZoneCollider = false;
    public CarUserControl rCar;
    private bool pauseTooggle=false;
    private Camera cameraFPCharacter;
    private Camera cameraCarCharacter;
    // Start is called before the first frame update
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
                if (Input.GetKeyDown(KeyCode.I))
                {
                    if(!pauseTooggle){
                        pauseTooggle=true;
                        rCar.setCarOn();
                        cameraFPCharacter.enabled = true;
                        cameraCarCharacter.enabled = false;
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
