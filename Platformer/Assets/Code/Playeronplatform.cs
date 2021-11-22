using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playeronplatform : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "MainCharacter")
        {
            collision.gameObject.transform.SetParent(null);
        }
    }
}
