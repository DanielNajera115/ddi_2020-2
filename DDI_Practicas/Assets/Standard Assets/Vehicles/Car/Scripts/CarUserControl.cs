using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Vehicles.Car
{
    [RequireComponent(typeof (CarController))]
    public class CarUserControl : MonoBehaviour
    {
        
        private CarController m_Car; // the car controller we want to use
        public bool carControllerIfItIsChoosed = true;

        private void Awake()
        {
            // get the car controller
            m_Car = GetComponent<CarController>();
        }
        public void setCarOn(){
            carControllerIfItIsChoosed = true;
        }

        public void setCarOff(){
            carControllerIfItIsChoosed = false;
            float h = CrossPlatformInputManager.GetAxis("Horizontal");
            float v = CrossPlatformInputManager.GetAxis("Vertical");
            float handbrake = CrossPlatformInputManager.GetAxis("Jump");
            m_Car.Move(h, v, v, handbrake,carControllerIfItIsChoosed);
        }
        
        private void FixedUpdate()
        {
            // pass the input to the car!
            
                float h = CrossPlatformInputManager.GetAxis("Horizontal");
                float v = CrossPlatformInputManager.GetAxis("Vertical");
                float handbrake = CrossPlatformInputManager.GetAxis("Jump");

                if(!carControllerIfItIsChoosed){
                    m_Car.Move(0, 0, 0, handbrake,true);
                    
                }
                
                
    #if !MOBILE_INPUT
                
                m_Car.Move(h, v, v, handbrake,carControllerIfItIsChoosed);
    #else
                m_Car.Move(h, v, v, 0f, carControllerIfItIsChoosed);
    #endif
            
                
        }
    }
}
