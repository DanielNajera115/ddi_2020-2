using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionPart : MonoBehaviour
{
    /// <summary>
    /// OnMouseDown is called when the user has pressed the mouse button while
    /// over the GUIElement or Collider.
    /// </summary>
    public MoleEngine moleEngine;
    void OnMouseDown(){
        Debug.Log("Examen");
        moleEngine.SetPressed(true);
    }
}
