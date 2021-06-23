using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Movement : MonoBehaviour
{
    public Rigidbody playerRB;
    public float forwardForce = 1;
    public float sideForce = 5;
    public float jumpForce = 2;
    private bool IsOnGround = true;
    private bool IsKeyUp = true;
    InventorySystem inventory;
    string json;

    private void Awake() {
        CreateJson();
        LoadJson();
    }
    private void Start() {
        inventory = FindObjectOfType<InventorySystem>();
    }

    void FixedUpdate()
    {
        playerRB.AddForce(0, 0, forwardForce * Time.deltaTime);

        if(Input.GetKey(KeyCode.A))
        {
            playerRB.AddForce(-sideForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if(Input.GetKey(KeyCode.D))
        {
            playerRB.AddForce(sideForce * Time.deltaTime, 0 , 0, ForceMode.VelocityChange);
        }
        if(Input.GetKey(KeyCode.Space) && IsOnGround)
        {
            IsKeyUp = false;
            Debug.Log(this.transform.position.z);
            playerRB.AddForce(0, jumpForce * Time.deltaTime, 0, ForceMode.Impulse);
            IsOnGround = false;
        }
        if(Input.GetKeyDown(KeyCode.Space) && !IsOnGround && inventory.ItemsList.Count > 0 && IsKeyUp)
        {
            inventory.ItemsList.RemoveAt(inventory.ItemsList.Count - 1);
            Debug.Log("double jump");
            playerRB.AddForce(0, jumpForce * Time.deltaTime, 0, ForceMode.Impulse);
            inventory.ShowItem();
            IsOnGround = false;
        }
        if(Input.GetKeyUp(KeyCode.Space))
        {
            IsKeyUp = true;
        }

        if(playerRB.position.y < -1)
        {
            FindObjectOfType<GameController>().GameOver();
        }
    }

    private void OnCollisionEnter(Collision collision) 
    {
        if(collision.gameObject.name == "Ground")
        {
            IsOnGround = true;
        }
    }

    /*void UseItem()
    {
        int itemCount = inventory.ItemsList.Count;
        inventory.ItemsList.RemoveAt(itemCount - 1);
    }*/

    void CreateJson()
    {
        PlayerData playerData = new PlayerData();
        playerData.forwardForce = 4000;
        playerData.sideForce = 80;
        playerData.jumpForce = 500;

        json = JsonUtility.ToJson(playerData);
        File.WriteAllText(Application.dataPath + "/StreamingAssets" + "/PlayerData.json",json);

        RefreshEditorWindow();
    }

    void LoadJson()
    {
        string jsonFromFile = File.ReadAllText(Application.dataPath + "/StreamingAssets" + "/PlayerData.json");
        PlayerData playerData = JsonUtility.FromJson<PlayerData>(jsonFromFile);

        forwardForce = playerData.forwardForce;
        sideForce = playerData.sideForce;
        jumpForce = playerData.jumpForce;
    }

    class PlayerData
    {
        public float forwardForce;
        public float sideForce;
        public float jumpForce;
    }

    void RefreshEditorWindow()
    {
        UnityEditor.AssetDatabase.Refresh();
    }
}
