using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterController : MonoBehaviour
{
    public Animator animator;
    private SpriteRenderer sp;
    private Scene scene;
    private Rigidbody2D mainCharacter;
    private BoxCollider2D collider;
    [SerializeField] private LayerMask jumpGround;
    public int points = 0;


    private float dirX =0f;
    [SerializeField] private float speed = 7f;
     private float Jumpforce = 8f;

    private enum movement { idle, run, jump };
    public int LivesLeft = 5;

    [SerializeField] private AudioSource coinsSoundEffect;


    void Start()
    {
        scene = SceneManager.GetActiveScene();
        mainCharacter = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sp = GetComponent<SpriteRenderer>();
        collider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");

        mainCharacter.velocity = new Vector2(dirX * speed, mainCharacter.velocity.y);

        if(Input.GetButtonDown("Jump") && IsGrounded())
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

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(collider.bounds.center, collider.bounds.size, 0f, Vector2.down, .1f, jumpGround);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coins"))
        {
            points += 50;
            coinsSoundEffect.Play();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("trap"))
        {
            LivesLeft -= 1;
            Destroy(gameObject);

            if (LivesLeft > 0)
            {
                SceneManager.LoadScene(scene.name);
            }

            if (LivesLeft == 0)
            {
                SceneManager.LoadScene("GAMEOVER");
            }
        }

        if (collision.gameObject.CompareTag("Chest"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        else
        {
            animator.SetBool("chest", false);
        }
    }

    public void OnGUI()
    {
        GUI.Box(new Rect(20, 20, 150, 75), " Points " + points + "\nLives: " + LivesLeft); ;
    }
}
