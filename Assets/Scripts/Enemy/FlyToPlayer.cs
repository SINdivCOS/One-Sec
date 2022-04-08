using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class FlyToPlayer : MonoBehaviour
{
    private GameObject player_obj;
    public Transform startingPoint;
    public Animator animator;

    private float horizontalMove;
    private float speed;
    public bool chase = false;

    void Start()
    {
        player_obj = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
       
        horizontalMove = startingPoint.transform.position.x;
        animator.SetFloat("RunX",Mathf.Abs(horizontalMove));

        speed = 2f;
        //Check Zone
        if (player_obj==null)
        {
            return;
        }
        if (chase==true)
        {
            Chase();
        }
        else
        {
            ReturnStartPoint();
        }
        
        //Chase();
        Flip();
    }
    
    /*public void SetHorizontalMovement(float x)
    {
        animator.SetFloat("Runx", Mathf.Abs(x));
        //anim.SetFloat("VerticalAxis", y);
        //anim.SetFloat("VerticalVelocity", yVel);
    }*/

    private void ReturnStartPoint()
    {
        animator.SetBool("isChase",false);
        transform.position = Vector2.MoveTowards(transform.position,
            startingPoint.position, speed * Time.deltaTime);
    }

    private void Chase()
    {
        animator.SetBool("isChase",true);
        speed += 2.85f;
        transform.position = Vector2.MoveTowards(transform.position,
            player_obj.transform.position, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position,player_obj.transform.position)>=0.8f)
        {
            //Atk
        }
    }

    private void Flip()
    {
        if (transform.position.x > player_obj.transform.position.x)
            transform.rotation = Quaternion.Euler(0, 0, 0);
        else
            transform.rotation=Quaternion.Euler(0,180,0);
    }
}
