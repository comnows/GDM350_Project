using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySystem : MonoBehaviour
{
    public GameObject coin;
    public Text itemText;
    public Text coinText;
    public List<GameObject> ItemsList = new List<GameObject>();
    public List<GameObject> CoinsList = new List<GameObject>();

    void Start() 
    {
        GameObject[] items = GameObject.FindGameObjectsWithTag("Item");
        GameObject[] coins = GameObject.FindGameObjectsWithTag("Coin");
        AddItemsListener(items);
        AddCoinsListener(coins);

        int checkpointCoin = PlayerPrefs.GetInt("coin");
        
        while(CoinsList.Count < checkpointCoin)
        {
            AddCoin(coin);
        }

        ShowItem();
    }

    void AddItemsListener(GameObject[] items)
    {
        foreach(GameObject item in items)
        {
            ItemPickUp doubleJumpItem = item.GetComponent<ItemPickUp>();
            doubleJumpItem.PickUpItemListener(OnPickUpItem);
        }
    }

    void AddCoinsListener(GameObject[] coins)
    {
        foreach(GameObject coin in coins)
        {
            CoinPickUp item = coin.GetComponent<CoinPickUp>();
            item.PickUpCoinListener(OnPickUpItem);
        }
    }

    void OnPickUpItem(GameObject item)
    {
        if(item.tag == "Item")
        {
            AddItem(item);
        }
        if(item.tag == "Coin")
        {
            AddCoin(item);
        }

        ShowItem();
    }

    void AddItem(GameObject item)
    {
        ItemsList.Add(item);
    }
    
    void AddCoin(GameObject coin)
    {
        CoinsList.Add(coin);
    }

    public void ShowItem()
    {
        //int itemCount; int coinCount;
        //if(ItemsList.Count == 0 && CoinsList.Count == 0) return;
        int itemCount = ItemsList.Count;
        int coinCount = CoinsList.Count;
        Debug.Log(coinCount);
        
        itemText.text = "Double Jump : " + itemCount;
        coinText.text = "Coins : " + coinCount;
    }
}
