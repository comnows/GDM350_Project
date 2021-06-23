using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CoinPickUp : MonoBehaviour
{
    ItemEvent pickUpGoldEvent = new ItemEvent();
    public void PickUpCoinListener(UnityAction<GameObject> listener)
    {
        pickUpGoldEvent.AddListener(listener);
    }

    private void OnTriggerEnter(Collider other) 
    {
        pickUpGoldEvent.Invoke(this.gameObject);
        gameObject.SetActive(false);
    }
}
