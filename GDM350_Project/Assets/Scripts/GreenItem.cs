using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenItem : Item
{
    protected override void ChangeColor(MeshRenderer meshRenderer)
    {
        meshRenderer.material.color = Color.green;
    }

    protected override IEnumerator boostTime()
    {
        FindObjectOfType<Movement>().jumpForce = FindObjectOfType<Movement>().jumpForce + forceAdd;
        
        yield return new WaitForSeconds(delayTime);

        FindObjectOfType<Movement>().jumpForce = FindObjectOfType<Movement>().jumpForce - forceAdd;
    }
}
