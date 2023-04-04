using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulleyEnemyBombCOllision : MonoBehaviour
{
    public SpriteRenderer weight;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // collided = true;
        Debug.Log("Here123"+ collision.gameObject.tag);        
        if(collision.gameObject.CompareTag("bomb")){
            Debug.Log("collided with enemy");
            Destroy(collision.gameObject);
            gameObject.GetComponent<SpriteRenderer>().sprite = weight.gameObject.GetComponent<SpriteRenderer>().sprite;
        }

    }
}
