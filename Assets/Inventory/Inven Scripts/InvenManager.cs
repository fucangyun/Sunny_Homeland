using Mono.Cecil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvenManager : MonoBehaviour
{
    static InvenManager instance;//?

    public Inventory myBag;
    public GameObject slotGrid;
    //public Slot slotPrefab;
    public GameObject emptySlot;
    public Text itemInformation;

    public List<GameObject> slots = new List<GameObject>();

    private void Start()
    { 
        
        
        RefreshItem();
    }

    private void Update()
    {
        
    }

    void Awake()
    {
        if(instance != null)
            Destroy(this);
        instance = this; 
    }

    private void Onenable()
    {
        RefreshItem();
        instance.itemInformation.text = "";
    }

    public static void UpdateItemInfo(string itemDescription)
    {
        instance.itemInformation.text = itemDescription;
    }

    /*public static void CreateNewItem(Item item)
    {
        Slot newItem = Instantiate(instance.slotPrefab, instance.slotGrid.transform.position, Quaternion.identity);//type, position, rotation
        newItem.gameObject.transform.SetParent(instance.slotGrid.transform);
        newItem.slotItem = item;
        newItem.slotImage.sprite = item.itemImage;
        newItem.slotNum.text = item.itemHeld.ToString();
    }*/

     public static void RefreshItem()
    {
        for(int i = 0; i < instance.slotGrid.transform.childCount; i++)
        {
            if (instance.slotGrid.transform.childCount == 0)
                break;
            Destroy(instance.slotGrid.transform.GetChild(i).gameObject);
            instance.slots.Clear();
        }
        //Debug.Log(instance.myBag.itemList.Count);
        for (int i = 0; i< instance.myBag.itemList.Count; i++)
        {
            //CreateNewItem(instance.myBag.itemList[i]);
            instance.slots.Add(Instantiate(instance.emptySlot));
            instance.slots[i].transform.SetParent(instance.slotGrid.transform, false);//don't quite sure about the use of 'false'
            instance.slots[i].GetComponent<Slot>().SetupSlot(instance.myBag.itemList[i]);   
        }

    }


}
