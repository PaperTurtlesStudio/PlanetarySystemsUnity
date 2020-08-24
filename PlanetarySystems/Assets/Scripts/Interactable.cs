using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float Radius = 3.0f;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, Radius);
    }
    
    public virtual void Interact()
    {
        Debug.Log("Interacting with " + gameObject.name);
    }
}
