using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ZipComInventorySlot : MonoBehaviour
{
    public GameObject PlayerCharacter;
    Vector3 PlayerCharacterPosition = new Vector3(0.0f, 0.0f, 0.0f);
    Item Item;
    public Image InventoryIcon;
    public Image InactiveInventoryIcon;
    public Image ActiveInventoryIcon;
    public GameObject SelectOverlayIcon;
    public GameObject ItemOptionsText;
    public bool BIsItemSelected;
    public Text NameText;

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

    private void Update()
    {
        PlayerCharacterPosition = PlayerCharacter.transform.position;
        OnRemove();
        UseItem();
    }
}
