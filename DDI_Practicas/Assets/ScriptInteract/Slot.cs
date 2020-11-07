using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public Item item;
    public Image image;
    public Slider sliderHealth;
    public Slider sliderMagic;
    private Inventory inventory;
    // Start is called before the first frame update
    void Start()
    {
        inventory = FindObjectOfType<Inventory>();
        if(inventory == null){
            return;
        }
        if(item != null){
            image.sprite = item.icon;
        }
    }

    public void SetItem(Item item){
        this.item = item;
        image.sprite = item.icon;
    }

    public void Clear()
    {
        this.item = null;
        image.sprite = null;
    }

    public void RemoveFromInventory(){
        if(item != null){
            inventory.Remove(item);
        }
    }

    public void UseItem(){
        if(item != null)
        {
            if(item.itemType == 0 && sliderHealth.value < 1){
                sliderHealth.value += .15f; 
            }else{
                if(sliderMagic.value < 1)
                    sliderMagic.value += .15f; 
            }
            item.Use();
            RemoveFromInventory();
            
        }
    }
}
