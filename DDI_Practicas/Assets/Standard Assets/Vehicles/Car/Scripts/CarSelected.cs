using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Vehicles.Car
{
    public class CarSelected : MonoBehaviour
    {
        // Start is called before the first frame update
    private CarUserControl rCar;

    private bool pauseTooggle=false;
        void Start()
        {
            rCar = GetComponent<CarUserControl>();
            
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                if(!pauseTooggle){
                    pauseTooggle=true;
                    rCar.setCarOn();
                }else{
                    pauseTooggle=false;
                    rCar.setCarOff();
                }
            }
            
        }
    }
}
