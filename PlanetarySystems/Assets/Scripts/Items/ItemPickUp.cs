using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : Interactable
{
    public Item Item;

    public override void Interact() 
    {
        base.Interact();
        PickUp();
    }

    private void PickUp()
    {
        Debug.Log("Picking up " + Item.Name);
        bool BPickedUp = ZipComInventory.Instance.addItem(Item);

        if (BPickedUp)
        {
            Destroy(gameObject);
        }
    }
}
