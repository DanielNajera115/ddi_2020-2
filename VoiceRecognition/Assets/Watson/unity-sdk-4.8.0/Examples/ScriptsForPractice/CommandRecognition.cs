using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandRecognition : MonoBehaviour
{
    string[] commandArray = {"change color","square disable","square enable"};
    // Start is called before the first frame update
    public Interactable interactable;
    private string[] commandSplitted;
    private bool lampLightState = false;
   
   public bool LampToggle(string lampState){
        if(lampState.Equals("on")){
            return true;
        }
        return false;
   }

    public void CommandRecognitionWithWatson(string finalString)
    {
        commandSplitted = finalString.Split(' ');
        switch(commandSplitted[0]){
            case "turn":
                lampLightState = LampToggle(commandSplitted[1]);
                interactable.TurnLight(lampLightState);
                break;
            case "change":
                interactable.ChangeColor(commandSplitted[1]);
                break;
            case "enable":
                interactable.SpawnObject(commandSplitted[1]);
                break;
            default:
                Debug.Log("Holo");
                break;
        }
    }
}
