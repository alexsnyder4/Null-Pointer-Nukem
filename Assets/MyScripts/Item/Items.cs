using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    public int numBrownies = 0;
    public int numPendant = 0;
    public int numCookbook = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public virtual void Destroy()
    {
        Debug.Log("Destroyed");
        Destroy(gameObject);
    }
}
