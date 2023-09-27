using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;

public class Swarms : Enemies
{
    private Rigidbody2D rb;
    public float speed = -5f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(speed, 0.0f);
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void Destroy()
    {
        base.Destroy();
    }
}
