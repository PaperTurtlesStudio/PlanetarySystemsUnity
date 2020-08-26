using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Items/Item")]
public class Item : ScriptableObject
{
    public string Name = "New Item";
    public Sprite Icon = null;
    public bool BIsDefaultItem = false;
    public bool BSpaceshipInventory = false;
    public GameObject ItemGameObject = null;
    public string CurrentInventory = "N/A";
    
    public virtual void Use()
    {
        Debug.Log("Using " + name);
    }

    public void RemoveFromInventory()
    {
        //Remove Item from inventory
        ZipComInventory.Instance.Remove(this);
    }
}
