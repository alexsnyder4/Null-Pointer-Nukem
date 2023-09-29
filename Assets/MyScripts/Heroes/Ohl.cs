using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ohl : Heroes
{
    public int numOhl = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void Destroy()
    {
        base.Destroy();
    }
    public void DestroyAllObjects(String tag)
    {
        // Find all active GameObjects in the scene
        
        GameObject[] objectsToDestroy = GameObject.FindGameObjectsWithTag(tag);
        // Iterate through the GameObjects and destroy them
        foreach (GameObject obj in objectsToDestroy)
        {
            Destroy(obj);
        }
        
    }
}
