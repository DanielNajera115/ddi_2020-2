using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ItemType{
    Food,
    Magic
}





[CreateAssetMenu(fileName = "Nuevo Item", menuName = "Inventario/Generic Item")]

public class Item : ScriptableObject
{
   public Sprite icon = null;
   public ItemType itemType = ItemType.Magic;

   public virtual void Use(){
       Debug.Log("Usando item:" + name);
       }
}
