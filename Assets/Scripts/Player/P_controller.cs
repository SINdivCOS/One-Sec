using UnityEngine;

public class P_controller : MonoBehaviour
{
    private float horizontal;
    public float speed = 8f;
    public float jumpingPower = 16f;

    private bool isFacingRight = true;
    //public bool canMove;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Animator animator;

    void Update()
    {
        /*anim.SetBool("onGround", coll.onGround);
        anim.SetBool("onWall", coll.onGround);
        anim.SetBool("onRightWall", coll.onRightWall);
        anim.SetBool("wallSlide", move.wallGrab);
        anim.SetBool("canMove", move.canMove);
        anim.SetBool("isDashing", move.isDashing);*/

        horizontal = Input.GetAxisRaw("Horizontal");
        if (OnGrounded())
        {
            SetHorizontalMovement(horizontal);
            animator.SetBool("isJump",false);
            animator.SetBool("canMove",true);
        }

        if (Input.GetButtonDown("Jump") && OnGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            animator.SetBool("onGround",true);
            animator.SetBool("isJump", true);
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        Flip();
    }
    
    public void SetHorizontalMovement(float x)
    {
        animator.SetFloat("Horizontal", Mathf.Abs(x));
        //anim.SetFloat("VerticalAxis", y);
        //anim.SetFloat("VerticalVelocity", yVel);
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private bool OnGrounded()
    {
        animator.SetBool("onGround", true);
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        { 
            isFacingRight = !isFacingRight;
            transform.Rotate(0f, 180f, 0f);
        }
    }
}