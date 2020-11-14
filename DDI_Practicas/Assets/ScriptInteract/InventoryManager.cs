using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class InventoryManager : MonoBehaviour
{
    public GameObject inventoryUIPanel;
    public Inventory inventory;
    // Start is called before the first frame update
    void Start()
    {
        inventoryUIPanel.SetActive(false);
        inventory.onChange += UpdateUI;
    }

    // Update is called once per frame
    void Update()
    {
        if (CrossPlatformInputManager.GetButtonDown("Fire2") )
        {
            inventoryUIPanel.SetActive(!inventoryUIPanel.activeSelf);
            UpdateUI();
        }
    }
    void UpdateUI(){
        Slot[] slot = GetComponentsInChildren<Slot>();
        for(int i = 0; i<slot.Length; i++){
            if(i < inventory.items.Count){
                slot[i].SetItem(inventory.items[i]);
            }else{
                slot[i].Clear();
            }
            

        }
    }
}
