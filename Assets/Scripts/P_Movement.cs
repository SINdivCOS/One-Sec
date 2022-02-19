using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_Movement : MonoBehaviour
{
    [Space]
    
    private Rigidbody2D _rigidbody2D;
    public float speed = 10;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector2 dir = new Vector2(x, y);
        
        Walk(dir);
        if (Input.GetKeyDown(KeyCode.X))
        {
            Dash(x,y);
        }
    }

    private void Walk(Vector2 dir)
    {
        _rigidbody2D.velocity = (new Vector2(dir.x * speed, _rigidbody2D.velocity.y));
    }

    private void Dash(float x, float y)
    {
        /*_rigidbody2D.velocity = Vector2.zero;
        _rigidbody2D.velocity += new Vector2(x, y).normalized * 30;*/
    }
}
