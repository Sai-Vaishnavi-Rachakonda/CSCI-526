using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // collided = true;
        if(collision.gameObject.CompareTag("bomb")){
            Destroy(collision.gameObject);
            Destroy(gameObject); 
        }

    }
}
