using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public Light light;
    public Material squareMaterial;
    private Color[] colors= new Color[6];
    public GameObject sword;
    // Start is called before the first frame update
    void Start()
    {
        colors[0] = Color.cyan;
         colors[1] = Color.red;
         colors[2] = Color.green;
         colors[4] = Color.yellow;
         colors[5] = Color.magenta;
    }

    public void TurnLight(bool lightState){
        light.enabled=lightState;
    }

    public void ChangeColor(string colorCommand){
        if(colorCommand.Equals("color"))
            squareMaterial.color = colors[Random.Range(0,6)];
    }
    public void SpawnObject(string commandObject){
        if(commandObject.Equals("weapon")){
            sword.SetActive(true);
        }
    }
}
