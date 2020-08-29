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

    public bool BOnHomePlanet;


    public delegate void OnItemChanged();
    public OnItemChanged OnItemChangedCallBack;

    public bool BPersonalInventory;
    public bool BSpaceshipInventory;
    public bool BPlanetInventory;

    public GameObject ReturnToSpaceshipScreen;
    public GameObject ReturnToPlanetScreen;

    public int Space = 20;
    public List<Item> PersonalItems = new List<Item>();
    public List<Item> SpaceshipItems = new List<Item>();
    public List<Item> PlanetItems = new List<Item>();

    public Transform PlayerCharacter;
    public Transform Spaceship;

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
            Item.CurrentInventory = "PersonalItems";
            if(OnItemChangedCallBack != null) { OnItemChangedCallBack.Invoke(); }
        }
        return true;
    }

    public void TransferItem(Item item, float InventoryNumber)
    {
        if(InventoryNumber == 1)
        {
            PersonalItems.Add(item);
            Remove(item);
            item.CurrentInventory = "PersonalItems";
            if (OnItemChangedCallBack != null) { OnItemChangedCallBack.Invoke(); }
        }
        else if(InventoryNumber == 2)
        {
            SpaceshipItems.Add(item);
            Remove(item);
            item.CurrentInventory = "SpaceshipItems";
            if (OnItemChangedCallBack != null) { OnItemChangedCallBack.Invoke(); }
        }
        else if(InventoryNumber == 3)
        {
            PlanetItems.Add(item);
            Remove(item);
            item.CurrentInventory = "PlanetItems";
            if (OnItemChangedCallBack != null) { OnItemChangedCallBack.Invoke(); }
        }

        
    }

    public void CheckInventories()
    {
        if (Vector3.Distance(PlayerCharacter.transform.position, Spaceship.transform.position) < 20.0f)
        {
            BSpaceshipInventory = true;
            ReturnToSpaceshipScreen.SetActive(false);
        }
        else
        {
            BSpaceshipInventory = false;
            ReturnToSpaceshipScreen.SetActive(true);
        }

        if (BOnHomePlanet)
        {
            BPlanetInventory = true;
            ReturnToPlanetScreen.SetActive(false);
        }
        else
        {
            BPlanetInventory = false;
            ReturnToPlanetScreen.SetActive(true);
        }
    }

    public void Remove(Item Item)
    {
        //Remove selected item from the current inventory
        if(Item.CurrentInventory == "PersonalItems")
        {
            PersonalItems.Remove(Item);
        }
        else if(Item.CurrentInventory == "SpaceshipItems")
        {
            SpaceshipItems.Remove(Item);
        }
        else if(Item.CurrentInventory == "PlanetItems")
        {
            PlanetItems.Remove(Item);
        }
        
        if(OnItemChangedCallBack != null) { OnItemChangedCallBack.Invoke(); }
    }

    private void Update()
    {
        CheckInventories();
    }
}