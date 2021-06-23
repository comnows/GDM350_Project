using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class StageTrigger : MonoBehaviour
{
    public GameObject StageCompleteUI;
    InventorySystem inventory;
    //string json;

    private void Start() {
        inventory = FindObjectOfType<InventorySystem>();
        //LoadJson();
    }

    private void OnTriggerEnter(Collider col) 
    {
        if(col.tag == "Player")
        {
        StageCompleteUI.SetActive(true);
        PlayerPrefs.SetFloat("xPos", this.transform.position.x);
        PlayerPrefs.SetFloat("zPos", this.transform.position.z);
        PlayerPrefs.SetInt("coin",inventory.CoinsList.Count);
        PlayerPrefs.Save();
        }

    }

    /*void CreateJson()
    {
        CoinData coinData = new CoinData();
        coinData.coinlist = inventory.CoinsList;

        json = JsonUtility.ToJson(coinData);
        File.WriteAllText(Application.dataPath + "/StreamingAssets" + "/CoinData.json",json);

        RefreshEditorWindow();
    }

    void LoadJson()
    {
        try
        {
        string jsonFromFile = File.ReadAllText(Application.dataPath + "/StreamingAssets" + "/CoinData.json");
        CoinData coinData = JsonUtility.FromJson<CoinData>(jsonFromFile);

        inventory.CoinsList = coinData.coinlist;
        }
        catch(Exception ex){Debug.Log(ex.Message);}
    }

    [Serializable]
    public class CoinData
    {
        public List<GameObject> coinlist = new List<GameObject>();
    }

    void RefreshEditorWindow()
    {
        UnityEditor.AssetDatabase.Refresh();
    }*/
}
