using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueItem : Item
{
    protected override void ChangeColor(MeshRenderer meshRenderer)
    {
        meshRenderer.material.color = Color.blue;
    }

    protected override IEnumerator boostTime()
    {
        FindObjectOfType<Movement>().forwardForce = FindObjectOfType<Movement>().forwardForce - forceAdd;
        
        yield return new WaitForSeconds(delayTime);

        FindObjectOfType<Movement>().forwardForce = FindObjectOfType<Movement>().forwardForce + forceAdd;
    }
}
