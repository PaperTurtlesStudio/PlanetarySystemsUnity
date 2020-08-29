using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ZipComInventorySlot : MonoBehaviour
{
    public GameObject PlayerCharacter;
    public Image InventoryIcon;
    public Image InactiveInventoryIcon;
    public Image ActiveInventoryIcon;
    public GameObject SelectOverlayIcon;
    public GameObject ItemOptionsText;
    public Text NameText;

    Vector3 PlayerCharacterPosition = new Vector3(0.0f, 0.0f, 0.0f);
    Item Item;
    bool BIsItemSelected;

    public void AddItem(Item NewItem)
    {
        Item = NewItem;

        InventoryIcon.sprite = Item.Icon;
        NameText.text = Item.Name;
        InventoryIcon.enabled = true;

        ActiveInventoryIcon.gameObject.SetActive(true);
        InactiveInventoryIcon.gameObject.SetActive(false);
    }

    public void ClearSlot()
    {
        Item = null;
        InventoryIcon.sprite = null;
        InventoryIcon.enabled = false;

        ActiveInventoryIcon.gameObject.SetActive(false);
        InactiveInventoryIcon.gameObject.SetActive(true);
        SelectOverlayIcon.SetActive(false);
    }

    public void SelectItem()
    {
        BIsItemSelected = true;
        if (ActiveInventoryIcon.IsActive())
        {
            ItemOptionsText.SetActive(true);
            SelectOverlayIcon.SetActive(true);
        }
    }

    public void DeselectItem()
    {
        BIsItemSelected = false;
        ItemOptionsText.SetActive(false);
        SelectOverlayIcon.SetActive(false);
    }

    public void OnRemove()
    {
        if(BIsItemSelected && Input.GetKey(KeyCode.D))
        {
            //drop the item in front of player

            GameObject ItemName = Instantiate(Item.ItemGameObject);
            ItemName.transform.position = PlayerCharacterPosition;

            ZipComInventory.Instance.Remove(Item);

            ActiveInventoryIcon.gameObject.SetActive(false);
            InactiveInventoryIcon.gameObject.SetActive(true);
            SelectOverlayIcon.SetActive(false);
        }
    }

    public void UseItem()
    {
        if(BIsItemSelected && Input.GetKey(KeyCode.U))
        {
            if (Item != null)
            {
                Item.Use();
            }
        }
    }

    public void TransferItem()
    {
        //transfer to player inventory
        if (ZipComInventory.Instance.BSpaceshipInventory || (ZipComInventory.Instance.BSpaceshipInventory && ZipComInventory.Instance.BPlanetInventory))
        {
            if (BIsItemSelected && Input.GetKey(KeyCode.Alpha1))
            {
                if (Item != null)
                {
                    Debug.Log("Transferring");

                    ZipComInventory.Instance.TransferItem(Item, 1);

                    ClearSlot();
                }
            }
        }

        //transfer to Spaceship Inventory
        if (ZipComInventory.Instance.BSpaceshipInventory)
        {
            if (BIsItemSelected && Input.GetKey(KeyCode.Alpha2))
            {
                if(Item != null)
                {
                    Debug.Log("Transferring");

                    ZipComInventory.Instance.TransferItem(Item, 2);

                    ClearSlot();
                }
            }
        }

        //transfer to planet invetory
        if (ZipComInventory.Instance.BPlanetInventory)
        {
            if(BIsItemSelected && Input.GetKey(KeyCode.Alpha2))
            {
                if(Item != null)
                {
                    Debug.Log("Transferring");

                    ZipComInventory.Instance.TransferItem(Item, 3);

                    ClearSlot();
                }
            }
        }
    }


    private void Update()
    {
        PlayerCharacterPosition = PlayerCharacter.transform.position;
        OnRemove();
        UseItem();
        TransferItem();
    }
}
