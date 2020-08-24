using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ZipComUI : MonoBehaviour
{
    public GameObject ZipCom;

    public Transform PersonalItemsParent;
    ZipComInventory Inventory;

    public ZipComInventorySlot[] PersonalInventorySlots;

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
        if (Input.GetKey(KeyCode.C))
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
    }
}
