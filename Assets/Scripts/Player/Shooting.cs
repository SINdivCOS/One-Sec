using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Shooting : MonoBehaviour
{
    public Transform BulletOut;
    public GameObject bulletPrefab;

    [SerializeField] private Animator animator;

    public int bulletValue = 10;
    public float bulletForce = 20f;

    /*private void Start()
    {
        animator = GetComponent<Animator>();
    }*/

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (bulletValue > 0)
            {
                Shoot();
                bulletValue--;
                //Debug.Log(bulletValue);
            }
        }

        /*
        if (Input.GetButtonUp("Fire1"))
        {
            animator.SetBool("isAtk2",false);
        }*/
    }

    void Shoot()
    {
        animator.SetTrigger("isAtk2");
        animator.SetBool("canAtk",true);
        
        GameObject bullet = Instantiate(bulletPrefab, BulletOut.position, BulletOut.rotation);
        Rigidbody2D _rigidbody2D = bullet.GetComponent<Rigidbody2D>();
        _rigidbody2D.AddForce(BulletOut.right * bulletForce, ForceMode2D.Impulse);
        Destroy(bullet,0.5f);
    }
}
