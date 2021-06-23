using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserName : MonoBehaviour
{
    [SerializeField] Text userNameText;
    // Start is called before the first frame update
    void Start()
    {
        LoadUserName();
    }

    void LoadUserName()
    {
        string playerName = PlayerPrefs.GetString("PlayerName");
        if(string.IsNullOrEmpty(playerName))
        {
            playerName = "Enter your name..";
        }

        InputField userNameField = userNameText.GetComponent<InputField>();
        userNameField.text = playerName;

        userNameField.onEndEdit.AddListener(SaveUserName);
    }

    void SaveUserName(string name)
    {
        PlayerPrefs.SetString("PlayerName", name);
        PlayerPrefs.Save();
    }
}
