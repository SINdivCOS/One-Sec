using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_collision : MonoBehaviour
{
    [Header("Layers")]
    public LayerMask groundLayer;

    [Space]

    public bool onGround;
    public bool onWall;
    public bool onRightWall;
    public bool onLeftWall;
    public int wallSide;

    [Space]
    
    [Header("collision")]
    public float collisionRadius = 0.25f; 
    public Vector2 Bottomoffset, Rightoffset, Leftoffset;

    private Color debugCollisionColor = Color.red;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        onGround = Physics2D.OverlapCircle((Vector2) transform.position + Bottomoffset, collisionRadius, groundLayer);
        onWall = Physics2D.OverlapCircle((Vector2) transform.position + Rightoffset, collisionRadius, groundLayer)
                 || Physics2D.OverlapCircle((Vector2) transform.position + Leftoffset, collisionRadius, groundLayer);
        
        onRightWall = Physics2D.OverlapCircle((Vector2)transform.position + Rightoffset, collisionRadius, groundLayer);
        onLeftWall = Physics2D.OverlapCircle((Vector2)transform.position + Leftoffset, collisionRadius, groundLayer);

        wallSide = onRightWall ? -1 : 1;
    }
    
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        var positions = new Vector2[] { Bottomoffset, Rightoffset, Leftoffset };

        Gizmos.DrawWireSphere((Vector2)transform.position  + Bottomoffset, collisionRadius);
        Gizmos.DrawWireSphere((Vector2)transform.position + Rightoffset, collisionRadius);
        Gizmos.DrawWireSphere((Vector2)transform.position + Leftoffset, collisionRadius);
    }
}
