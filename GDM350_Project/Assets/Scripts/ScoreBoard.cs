using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Linq;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    string path;
    string UserName;
    int coinAmount;

    int nCount;

    public Text[] PlaceNameText;
    public Text[] PlaceScoreText;

    List<PlayerScoreData> scoreList = new List<PlayerScoreData>();
    List<PlayerScoreData> OrderedScoreList = new List<PlayerScoreData>();
    // Start is called before the first frame update
    void Start()
    {
        path = Application.dataPath + "/StreamingAssets" + "/ScoreBoard.json";
        UserName = PlayerPrefs.GetString("PlayerName");
        coinAmount = PlayerPrefs.GetInt("coin");

        AddNewValue();

        nCount = 0;

        for(int n = 0; n < OrderedScoreList.Count; n++)
        {
            PlaceNameText[n].text = OrderedScoreList[n].userName;
            PlaceScoreText[n].text = OrderedScoreList[n].CoinCollected.ToString();
            //Debug.Log(OrderedScoreList[n].userName + OrderedScoreList[n].CoinCollected.ToString());
            nCount += 1;
        }

        for(int m = nCount; m < 5; m++)
        {
            PlaceNameText[m].text = "----------";
            PlaceScoreText[m].text = "--";
        }
    }

    public void Quit()
    {
        Debug.Log("You quit!!");
        Application.Quit();
    }

    [Serializable]
    public class PlayerScoreData
    {
        public string userName;
        public int CoinCollected;

        public PlayerScoreData(string name, int coin)
        {
            userName = name;
            CoinCollected = coin;
        }
    }

    void AddNewValue()
    {
        OrderedInt array = new OrderedInt();

        if(File.Exists(Application.dataPath + "/StreamingAssets" + "/ScoreBoard.json"))
        {
        scoreList = LoadJson<PlayerScoreData>();

        //Debug.Log(scoreList[0].CoinCollected);

            for(int i = 0; i < scoreList.Count; i++)
            {
                array.Add(scoreList[i].userName , scoreList[i].CoinCollected);
            }
        }

        array.Add(UserName, coinAmount);

        for(int j = 0; j < array.Count; j++)
        {
            OrderedScoreList.Add(new PlayerScoreData(array.itemsName[j],array.items[j]));
        }
        SaveJson<PlayerScoreData>(OrderedScoreList);
    }

    void SaveJson<T>(List<T> toSave)
    {
        string ContentToJson = JsonHelper.ToJson<T>(toSave.ToArray());

        
        File.WriteAllText(Application.dataPath + "/StreamingAssets" + "/ScoreBoard.json",ContentToJson);
    }

    List<T> LoadJson<T>()
    {    
        string ContentFromJson = File.ReadAllText(Application.dataPath + "/StreamingAssets" + "/ScoreBoard.json");

        if(string.IsNullOrEmpty(ContentFromJson) || ContentFromJson == "{}")
        {
            return new List<T>();
        }

        List<T> res = JsonHelper.FromJson<T>(ContentFromJson).ToList();

        return res;
    }
}

public static class JsonHelper
{
    public static T[] FromJson<T>(string json)
    {
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
        return wrapper.Items;
    }

    public static string ToJson<T>(T[] array)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.Items = array;
        return JsonUtility.ToJson(wrapper);
    }

    [Serializable]
    private class Wrapper<T>
    {
        public T[] Items;
    }
}
