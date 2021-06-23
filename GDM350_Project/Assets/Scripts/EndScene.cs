using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;

public class EndScene : MonoBehaviour
{
    public Text ScoreText;
    public Text CoinScoreText;
    public Text TotalScore;
    int score;
    int coinAmount;
    InventorySystem inventory;
    private void Start() 
    {
        score = (int)PlayerPrefs.GetFloat("Score");
        coinAmount = PlayerPrefs.GetInt("coin");
        inventory = FindObjectOfType<InventorySystem>();
        //LoadJson();
        if(PlayerPrefs.HasKey("Score"))
        {
            ScoreText.text = "YOUR SCORE: " + score;
        }
        else
        {
            Debug.Log("key not found!");
        }
        CoinScoreText.text = "COIN SCORE (" + coinAmount + " * 100): " + coinAmount * 100;
        TotalScore.text = "TOTAL SCORE: " + (score + (coinAmount * 100));
    }
    public void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        /*Debug.Log("You quit!!");
        Application.Quit();*/
    }

    /*void LoadJson()
    {
        string jsonFromFile = File.ReadAllText(Application.dataPath + "/StreamingAssets" + "/CoinData.json");
        CoinData coinData = JsonUtility.FromJson<CoinData>(jsonFromFile);

        inventory.CoinsList = coinData.coinlist;
    }

    class CoinData
    {
        public List<GameObject> coinlist = new List<GameObject>();
    }*/
}
