using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemPickUp : MonoBehaviour
{
    ItemEvent pickUpItemEvent = new ItemEvent();
    public void PickUpItemListener(UnityAction<GameObject> listener)
    {
        pickUpItemEvent.AddListener(listener);
    }

    private void OnTriggerEnter(Collider other) 
    {
        pickUpItemEvent.Invoke(this.gameObject);
    }
}
