using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 15f;
    private float horizontal;
    private float vertical;
    public bool isFrozen = false;
    private LayerMask originalCollisionLayer;
    private PlayerUI ui;
    private int originalLayerMask;
    Animator animator;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        ui = GetComponent<PlayerUI>();
        animator.SetInteger("PlayerState" , (int)AnimationStateEnum.Running);
        originalCollisionLayer = this.gameObject.layer;
        originalLayerMask = this.gameObject.layer;
    }
    void Update()
    {
        
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);

        if(screenPos.x < 15)
        {
            print("Left bounds");
        }
    
        else if(screenPos.x > Screen.width - 15)
        {
            print("Right bounds");
        }
        
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");            
        SetAnimationState();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(isFrozen == true)
        {
            rb.velocity = new Vector2(0,0);
            rb.velocity = new Vector2(0,0);
        }
        else
        {
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
            rb.velocity = new Vector2(rb.velocity.x, vertical * speed);
        }
    }
    private enum AnimationStateEnum
    {
        Idle = 0,
        Running = 1
    }
    void SetAnimationState()
    {
        AnimationStateEnum playerAnimationState;
        if (horizontal == 0.0f && vertical == 0.0f)
        {
            playerAnimationState = AnimationStateEnum.Idle;
        }
        else
        {
            playerAnimationState = AnimationStateEnum.Running;
        }
        animator.SetInteger("PlayerState", (int)playerAnimationState);
    }
    public void FreezePlayerMovement()
    {
        // Store the player's original collision layers and mask

        isFrozen = true;
        ui.ToggleChat();
        Debug.Log("frozen");

        // Set the player's layer to the desired layer that should allow collisions
        this.gameObject.layer = LayerMask.NameToLayer("Frozen");

        // Call a coroutine to unfreeze player movement after 5 seconds
        StartCoroutine(UnfreezePlayerMovement());
    }

    public IEnumerator UnfreezePlayerMovement()
    {
        yield return new WaitForSeconds(5.0f);

        // Restore the player's original collision layers and mask
        this.gameObject.layer = originalCollisionLayer;
        isFrozen = false;
        ui.ToggleChat();
        Debug.Log("unfrozen");
    }
}
