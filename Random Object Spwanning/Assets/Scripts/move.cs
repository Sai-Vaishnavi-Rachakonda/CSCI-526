using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody rb; 
    private float movespeed;
    private float dirX, dirZ;
    void Start()
    {
        movespeed = 3f;
        rb = GetComponent<Rigidbody>(); 
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxis("Horizontal")*movespeed;
        dirZ = Input.GetAxis("Vertical")*movespeed;
    }

    private void FixedUpdate(){
    	rb.velocity = new Vector3(dirX, rb.velocity.y, dirZ);
    }
}
