using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public Animator animator;
    private SpriteRenderer sp;
    private Rigidbody2D mainCharacter;

    private float dirX =0f;
    [SerializeField] private float speed = 7f;
    [SerializeField] private float Jumpforce = 7f;

    private enum movement { idle, run, jump };
    

    void Start()
    {
        mainCharacter = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sp = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");

        mainCharacter.velocity = new Vector2(dirX * speed, mainCharacter.velocity.y);

        if(Input.GetButtonDown("Jump"))
        {
            mainCharacter.velocity = new Vector2(mainCharacter.velocity.x, Jumpforce);
        }

        Animations();
    }

    private void Animations()
    {
        movement state;
        if (dirX > 0f)
        {
            state = movement.run;
            sp.flipX = false;
        }
        else if (dirX < 0)
        {
            state = movement.run;
            sp.flipX = true;
        }
        else
        {
            state = movement.idle;
        }
        if(mainCharacter.velocity.y > 0.1f)
        {
            state = movement.jump;
        }
        else if (mainCharacter.velocity.y < -0.1f)
        {
            state = movement.idle;
        }

        animator.SetInteger("state", (int)state);
    }


}
