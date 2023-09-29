using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pirates : Enemies
{
    public Transform player; // Reference to the player object
    public float movementSpeed = 3.0f; // Speed at which the object chases the player
    
    PlayerMovement pm;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        pm = player.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            // Check if the player reference is set; if not, do nothing
            return;
        }
        if(pm.isFrozen)
        {

        }
        else
        {
            // Calculate the direction from this object to the player
            Vector2 direction = (player.position - transform.position).normalized;

            // Calculate the object's velocity
            Vector2 velocity = direction * movementSpeed * Time.deltaTime;

            // Move the object towards the player using the velocity
            transform.Translate(velocity);
        }
    }
    public override void Destroy()
    {
        base.Destroy();
    }
    

}
