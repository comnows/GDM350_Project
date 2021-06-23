using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class Menu : MonoBehaviour
{
    InventorySystem inventory;

    public void PlayGame()
    {
        //PlayerPrefs.DeleteAll();
        PlayerPrefs.DeleteKey("Score");
        PlayerPrefs.DeleteKey("xPos");
        PlayerPrefs.DeleteKey("zPos");
        PlayerPrefs.SetInt("coin",0);

        //DeleteJson();

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    /*void DeleteJson()
    {
        string filePath = Application.dataPath + "/StreamingAssets" + "/CoinData.json";

        if(!File.Exists(filePath))
        {
            Debug.Log("File not found!!");
        }
        else
        {
            Debug.Log("File exists, deleting...");
        }

        File.Delete(filePath);

        RefreshEditorWindow();
    }

    void RefreshEditorWindow()
    {
        UnityEditor.AssetDatabase.Refresh();
    }*/
}
