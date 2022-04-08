using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class old_P_movement : MonoBehaviour
{
    [Space]
    [SerializeField] private P_collision _collision;
    [SerializeField] private P_animation anim;
    [SerializeField] private Rigidbody2D rb;
    
    [SerializeField] private LayerMask groundLayer;
    
    [Space]
    [Header("Stats")]
    public float speed = 8f;
    public float jumpingPower = 16f;
    
    [Space]
    [Header("Check Bool")]
    public bool isFacingRight = true;
    public bool canMove;
    public bool wallJumped;
    public bool wallSlide;
    public bool isDashing;

    private Transform groundCheck;
    public float x = Input.GetAxis("Horizontal");
    private float y = Input.GetAxis("Vertical");
    private float xRaw = Input.GetAxisRaw("Horizontal");
    private float yRaw = Input.GetAxisRaw("Vertical");

    //private bool IsGrounded;
    private bool hasDashed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
        
        
        move();
        //anim.SetHorizontalMovement(x,y,rb.velocity.y);
        
        if (Input.GetButtonDown("Jump")&&IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
        x = Input.GetAxisRaw("Horizontal");
        Flip();
    }

    private void move()
    {
        rb.velocity = new Vector2(x * speed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        if (isFacingRight && x < 0f || !isFacingRight && x > 0f)
        {
            isFacingRight = !isFacingRight;

            transform.Rotate(0f, 180f, 0f);
        }
    }
}
