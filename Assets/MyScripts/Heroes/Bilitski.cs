using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bilitski : Heroes
{
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
    public int Amplify(int points)
    {
        return points *= 2;
    }
}
