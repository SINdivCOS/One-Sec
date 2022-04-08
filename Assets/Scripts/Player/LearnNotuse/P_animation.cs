using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_animation : MonoBehaviour
{
    private Animator anim;
    private P_movement move;
    private P_collision coll;
    [HideInInspector]
    public SpriteRenderer sr;

    void Start()
    {
        anim = GetComponent<Animator>();
        coll = GetComponentInParent<P_collision>();
        move = GetComponentInParent<P_movement>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        /*anim.SetBool("onGround", coll.onGround);
        anim.SetBool("onWall", coll.onGround);
        anim.SetBool("onRightWall", coll.onRightWall);
        anim.SetBool("wallSlide", move.wallGrab);
        anim.SetBool("canMove", move.canMove);
        anim.SetBool("isDashing", move.isDashing);*/

    }

    public void SetHorizontalMovement(float x,float y, float yVel)
    {
        //anim.SetFloat("HorizontalAxis", x);
        //anim.SetFloat("VerticalAxis", y);
        //anim.SetFloat("VerticalVelocity", yVel);
    }

    public void SetTrigger(string trigger)
    {
        anim.SetTrigger(trigger);
    }

    public void Flip(int side)
    {

        /*if (move.wallSlide)*/
        {
            if (side == -1 && sr.flipX)
                return;

            if (side == 1 && !sr.flipX)
            {
                return;
            }
        }

        bool state = (side == 1) ? false : true;
        sr.flipX = state;
    }
}
