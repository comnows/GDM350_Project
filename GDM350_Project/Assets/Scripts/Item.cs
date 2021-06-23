using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class Item : MonoBehaviour
{
    public float delayTime = 3f;
    public float forceAdd = 0f;
    public string ConfFileName = "itemsData.csv";
    Dictionary<string,ItemDat> items = new Dictionary<string, ItemDat>();

    void Awake() 
    {
        ReadData();
    }
    void Start() 
    {
        MeshRenderer meshrenderer = GetComponent<MeshRenderer>();
        ChangeColor(meshrenderer);

        string className = this.GetType().Name;
        delayTime = 3f;
        forceAdd = 0f;
        ItemDat itemData = new ItemDat (delayTime,forceAdd);
        switch(className)
        {
            case "GreenItem":
            itemData = items["GreenItem"];
            break;
            
            case "BlueItem":
            itemData = items["BlueItem"];
            break;
            
            default:
            break;
        }
        delayTime = itemData.Time;
        forceAdd = itemData.Force;
    }
    protected virtual void ChangeColor(MeshRenderer meshRenderer)
    {
        meshRenderer.material.color = Color.red;
    }

    private void OnTriggerEnter() 
    {
        Debug.Log("you got new item");
        StartCoroutine(boostTime());
    }

    protected virtual IEnumerator boostTime()
    {
        yield return new WaitForSeconds(delayTime);
    }

    private void ReadData()
    {
        StreamReader input = null;
        string path = "Assets/StreamingAssets";
        try
        {
            input = File.OpenText(Path.Combine(path,
                                        ConfFileName));
            string name = input.ReadLine();
            string values = input.ReadLine();
            while (values != null)
            {
                AssignData(values);
                values = input.ReadLine();
            }
        }
        catch (Exception ex) { Debug.Log(ex.Message); }
        finally { if (input != null) input.Close(); }
    }

    void AssignData(string values)
    {
        string[] data = values.Split(',');
        int no = int.Parse(data[0]);
        string itemName = data[1];
        float time = float.Parse(data[2]);
        float force = float.Parse(data[3]);
        ItemDat item = new ItemDat(time, force);
        items.Add(itemName, item);
    }
}
