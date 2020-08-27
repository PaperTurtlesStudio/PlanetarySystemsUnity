﻿using System.Collections;
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

    public GameObject PlayerPanel;
    public GameObject InventoryPanel;
    public GameObject MapPanel;
    public GameObject SpaceshipStatsPanel;
    public GameObject PlanetStatsPanel;

    // Start is called before the first frame update
    void Start()
    {
        InventorySetUp();
        Debug.Log(PlayerPanel.activeInHierarchy);
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
        if (Input.GetKeyDown(KeyCode.Z))
        {
            ZipCom.SetActive(true);


            PlayerPanel.SetActive(true);
            InventoryPanel.SetActive(false);
            MapPanel.SetActive(false);
            SpaceshipStatsPanel.SetActive(false);

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;


            Debug.Log(PlayerPanel.activeInHierarchy);
        }
        //input button pressed (I) display animation then Inventory Screen
        if (Input.GetKeyDown(KeyCode.I))
        {
            ZipCom.SetActive(true);

            PlayerPanel.SetActive(false);
            InventoryPanel.SetActive(true);
            MapPanel.SetActive(false);
            SpaceshipStatsPanel.SetActive(false);

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        //input button pressed (M) display animaion then Map Screen 
        if (Input.GetKeyDown(KeyCode.M))
        {
            ZipCom.SetActive(true);

            PlayerPanel.SetActive(false);
            InventoryPanel.SetActive(false);
            MapPanel.SetActive(true);
            SpaceshipStatsPanel.SetActive(false);

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
