using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public float jump;
    private float move;
    public bool isJumping;

    private Rigidbody2D rb;
    GameObject Slingshot, PositionStrip0, PositionStrip1, strip0, strip1;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Slingshot = GameObject.Find("Slingshot");
        PositionStrip0 = GameObject.Find("PositionStrip0");
        PositionStrip1 = GameObject.Find("PositionStrip1");
        strip0 = GameObject.Find("Strip0");
        strip1 = GameObject.Find("Strip1");
    }

    // Update is called once per frame
    void Update()
    {
        move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(speed * move, rb.velocity.y);
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            rb.AddForce(new Vector2(rb.velocity.x, jump));
        }

        if (Mathf.Abs(rb.velocity.x) < .5 && Mathf.Abs(rb.velocity.y) < .5 && !isJumping)
        {
            var slingShotpositionX = Slingshot.transform.position.x;
            var slingShotpositionY = Slingshot.transform.position.y;
            if (!(transform.position.x - 2 < slingShotpositionX && transform.position.x + 2 > slingShotpositionX))
            {
                Slingshot.transform.position = new Vector3(transform.position.x+1f, transform.position.y + 1.25f, 0);
            }
            else if (!(transform.position.y - 2 < slingShotpositionY && transform.position.y + 2 > slingShotpositionY))
            {
                Slingshot.transform.position = new Vector3(transform.position.x+1f, transform.position.y + 1.25f, 0);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
        // throw new NotImplementedException();
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = true;
        }
        // throw new NotImplementedException();
    }
}