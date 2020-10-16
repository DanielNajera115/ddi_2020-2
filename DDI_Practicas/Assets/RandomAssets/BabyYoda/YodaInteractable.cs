using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;
using UnityEngine.UI;
using UnityEditor;


    public class YodaInteractable : MonoBehaviour
    {   
        // Start is called before the first frame update
        

        void Start()
        {
            
        }
        void Update()
        {
            
        }

        void OnTriggerEnter(Collider myCol)
        {
          Debug.Log("Holo");
        }

        void OnTriggerExit(Collider myCol)
        {
            

        }
    
    }
