using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemOnWorld : MonoBehaviour
{

    public Item thisItem;//which inventory it belongs
    public Inventory PlayerInventory;//which bag it will go into
    // Start is called before the first frame update
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.GetComponent<Character>() != null)
        {
            AddNewItem();
            Destroy(gameObject);
        }
    }
    
    public void AddNewItem()
    {
        if(!PlayerInventory.itemList.Contains(thisItem))
        {
            int InventoryCount = PlayerPrefs.GetInt("InventoryCount");
            PlayerPrefs.SetInt("InventoryCount", InventoryCount+1);
            //PlayerInventory.itemList.Add(thisItem);
            //InvenManager.CreateNewItem(thisItem);
            //thisItem.itemHeld += 1;//default is 1, not 0
            for (int i = 0; i < PlayerInventory.itemList.Count; i++)
            {
                if(PlayerInventory.itemList[i] == null)
                {
                    PlayerInventory.itemList[i] = thisItem;
                    break;
                }
            }
        }
        else
        {
            thisItem.itemHeld += 1; 
        }
        InvenManager.RefreshItem();
    }
}
