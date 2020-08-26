using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ZipComUI : MonoBehaviour
{
    public GameObject ZipCom;

    public Transform PersonalItemsParent;
    public Transform SpaceshipItemsParent;
    public Transform PlanetItemsParent;
    ZipComInventory Inventory;

    public ZipComInventorySlot[] PersonalInventorySlots;
    public ZipComInventorySlot[] SpaceshipInventorySlots;
    public ZipComInventorySlot[] PlanetInventorySlots;

    // Start is called before the first frame update
    void Start()
    {
        InventorySetUp();
    }

    // Update is called once per frame
    void Update()
    {
        DisplayZipCom();
        CloseZipCom();
    }

    void InventorySetUp()
    {
        Inventory = ZipComInventory.Instance;

        Inventory.OnItemChangedCallBack += UpdateUI;

        PersonalInventorySlots = PersonalItemsParent.GetComponentsInChildren<ZipComInventorySlot>();
        SpaceshipInventorySlots = SpaceshipItemsParent.GetComponentsInChildren<ZipComInventorySlot>();
        PlanetInventorySlots = PlanetItemsParent.GetComponentsInChildren<ZipComInventorySlot>();
    }

    void DisplayZipCom()
    {
        //input button pressed (Z) display animation then the main screen (That being the player stats one)
        if (Input.GetKey(KeyCode.Z))
        {
            ZipCom.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        //input button pressed (I) display animation then Inventory Screen
        if (Input.GetKey(KeyCode.I))
        {
            ZipCom.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        //input button pressed (M) display animaion then Map Screen 
        if (Input.GetKey(KeyCode.M))
        {
            ZipCom.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
    
    void CloseZipCom()
    {
        if (Input.GetKey(KeyCode.V))
        {
            ZipCom.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    void UpdateUI()
    {
        for (int i = 0; i < PersonalInventorySlots.Length; i++)
        {
            if(i < Inventory.PersonalItems.Count)
            {
                PersonalInventorySlots[i].AddItem(Inventory.PersonalItems[i]);
            }
            else
            {
                PersonalInventorySlots[i].ClearSlot();
            }
        }

        for (int i = 0; i < SpaceshipInventorySlots.Length; i++)
        {
            if(i < Inventory.SpaceshipItems.Count)
            {
                SpaceshipInventorySlots[i].AddItem(Inventory.SpaceshipItems[i]);
            }
            else
            {
                SpaceshipInventorySlots[i].ClearSlot();
            }
        }

        for (int i = 0; i < PlanetInventorySlots.Length; i++)
        {
            if (i < Inventory.PlanetItems.Count)
            {
                PlanetInventorySlots[i].AddItem(Inventory.PlanetItems[i]);
            }
            else
            {
                PlanetInventorySlots[i].ClearSlot();
            }
        }
    }
}
