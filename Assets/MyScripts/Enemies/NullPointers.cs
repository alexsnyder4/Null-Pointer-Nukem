using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NullPointers : Enemies
{
    private Rigidbody2D rb;
    public float speed = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.transform.Rotate(0.0f, 0.0f, 90.0f, Space.Self);
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
