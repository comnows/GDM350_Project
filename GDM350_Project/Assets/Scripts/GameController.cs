using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    bool isGameOver = false;
    public float delayTime = 1f;

    public GameObject levelCompletedUI;
    public GameObject player;
    public Movement playerMovement;

    void Start() 
    {
        if(PlayerPrefs.HasKey("xPos") && PlayerPrefs.HasKey("zPos"))
        {
            player.SetActive(false);
            player.transform.position = new Vector3 (PlayerPrefs.GetFloat("xPos"), 1.2f, PlayerPrefs.GetFloat("zPos"));
            player.SetActive(true);
        }
    }
    public void LevelComplete()
    {
        levelCompletedUI.SetActive(true);
        playerMovement.enabled = false;
    }

    public void GameOver()
    {
        if(isGameOver == false)
        {
            isGameOver = true;
            Invoke("Restart", delayTime);
        }
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
