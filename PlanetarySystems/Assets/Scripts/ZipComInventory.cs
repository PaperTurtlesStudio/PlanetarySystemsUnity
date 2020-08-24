using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZipComInventory : MonoBehaviour
{
    #region Singleton
    public static ZipComInventory Instance;
    public void Awake()
    {
        if(Instance != null)
        {
            Debug.LogWarning("More than one instance of inventory found");
            return;
        }
        Instance = this;
    }
    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged OnItemChangedCallBack;

    public bool BPersonalInventory;
    public bool BSpaceshipInventory;
    public bool BPlanetInventory;

    public int Space = 20;
    public List<Item> PersonalItems = new List<Item>();
    public List<Item> SpaceshipItems = new List<Item>();
    public List<Item> PlanetItems = new List<Item>();

    public bool addItem(Item Item)
    {
        //check if item is default item (Always in inventory) -> i.e. helmet
        if (!Item.BIsDefaultItem)
        {
            //Check Which inventory is active and if item can be added to that inventory
            //check if there are any of the same item already in the inventory
                //check if there is enough room to include item in those slots (less than 64, 32, 16, 8, 4, 2, or 1)

            //check if there are enough slots available in the inventory if item not already in there
            if (PersonalItems.Count >= Space)
            {
                Debug.Log("Not enough room in Personal Inventory");
                return false;
            }
            PersonalItems.Add(Item);
            if(OnItemChangedCallBack != null) { OnItemChangedCallBack.Invoke(); }
        }
        return true;
    }

    public void Remove(Item Item)
    {
        //Remove selected item from the current inventory
        PersonalItems.Remove(Item);
        if(OnItemChangedCallBack != null) { OnItemChangedCallBack.Invoke(); }
    }
}