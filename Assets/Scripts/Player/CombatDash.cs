using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatDash : MonoBehaviour
{
    [SerializeField]private Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            animator.SetBool("canAtk",true);
            animator.SetTrigger("isAtk1");
        }
    }
}
