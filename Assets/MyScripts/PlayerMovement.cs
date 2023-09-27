using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 8f;
    private float horizontal;
    private float vertical;
    Animator animator;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        animator.SetInteger("PlayerState" , (int)AnimationStateEnum.Running);
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
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        rb.velocity = new Vector2(rb.velocity.x, vertical * speed);
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
}
