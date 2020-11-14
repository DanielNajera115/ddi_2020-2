using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Vehicles.Car;
using UnityStandardAssets.CrossPlatformInput;

public class FoodInteractable : Interactable
{

    public bool inZone;
    private Text interactableLabel;
    private Inventory inventory;
    public Item item;
    // Start is called before the first frame update
    void Start()
    {
        inZone = false;
        interactableLabel = GameObject.Find("InteractableMessageLbl").GetComponent<Text>();
        inventory = FindObjectOfType<Inventory>();
        if(inventory == null){
            Debug.LogWarning("No objects in inventory");
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(inZone){
            if (CrossPlatformInputManager.GetButtonDown("Fire1")){
                inventory.Add(item);
                Destroy(gameObject);
            }
        }else{
            interactableLabel.text = "";
        }
    }


    public override void Interact(){
        base.Interact();
        inZone = true;
        interactableLabel.text = "Presione i para interactuar";
    }

    public override void NotInteract(){
        base.NotInteract();
        inZone = false;
    }

}
