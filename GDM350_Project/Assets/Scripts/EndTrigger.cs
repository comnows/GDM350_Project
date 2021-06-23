using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    public GameController gameController;
    InventorySystem inventory;

    private void Start() 
    {
        inventory = FindObjectOfType<InventorySystem>();
    }
    void OnTriggerEnter(Collider collider) 
    {
        if(collider.tag == "Player")
        {
        PlayerPrefs.DeleteKey("xPos");
        PlayerPrefs.DeleteKey("zPos");
        PlayerPrefs.SetInt("coin",inventory.CoinsList.Count);
        
        if(PlayerPrefs.HasKey("Score"))
        {
            PlayerPrefs.SetFloat("Score", PlayerPrefs.GetFloat("Score") + this.gameObject.transform.position.z);
            PlayerPrefs.Save();
            Debug.Log("save1");
        }
        else
        {
            PlayerPrefs.SetFloat("Score", this.gameObject.transform.position.z);
            PlayerPrefs.Save();
            Debug.Log("save2");
        }
        gameController.LevelComplete();
        }
    }
}
