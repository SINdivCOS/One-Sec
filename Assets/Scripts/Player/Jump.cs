using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    [Range(1, 30)] public float jumpVelocity;
    // Start is called before the first frame update

    private bool isGround;
    private void OnCollisionEnter2D(Collision2D hitObjs)
    {
        if (hitObjs.gameObject.tag == "Ground")
        {
            isGround = true;
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Jump")&&isGround)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpVelocity;
            isGround = false;
        }
    }
}
