using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacter : MonoBehaviour
{
    public Animator animator; 
    public Rigidbody2D mainCharacter;
    public float speed = 2.0f;


    void Start()
    {
        animator.GetComponent<Animator>();
    }
    void Update(){}
    public void FixedUpdate()
    {
        moveCharacter();
    }
    public void moveCharacter()
    {
        if (Input.GetKey(KeyCode.W))
            animator.SetBool("Jump", true);
        else
            animator.SetBool("Jump", false);    

    }
}
