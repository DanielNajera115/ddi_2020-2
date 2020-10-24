using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;
using UnityEngine.UI;
using UnityEditor;


    public class YodaInteractable : Interactable
    {
    // Start is called before the first frame update

    public override void Interact()
    {
        base.Interact();
        Debug.Log("Baby yoda");
    }


    
    }
