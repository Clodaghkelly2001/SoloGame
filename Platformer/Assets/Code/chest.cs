using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chest : MonoBehaviour
{
    public Animator chestAnim;
    public Rigidbody2D MainCharacter;
    // Start is called before the first frame update
    void Start()
    {
        chestAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Collision(Collision2D collision)
    {
        if (collision.gameObject.name == "Main Character")
        {
            chestAnim.SetBool("chest", true);
        }
    }
}
