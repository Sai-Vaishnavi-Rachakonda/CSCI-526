using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public bool collided;

    // private Rigidbody2D newPlatform;
    private Rigidbody2D newPlatform; //create a new variable to access the new platform
    private Vector3 lastPosition = Vector3.negativeInfinity; //set the last poistion of the platform to  neg infinit
    public Rigidbody2D platformShape;// get the variable to create the new platform.

    private void Start()
    {
        newPlatform = GetComponent<Rigidbody2D>(); // assign the platform to the var
    }

    public void Release()
    {
        PathPoints.instance.Clear();
        StartCoroutine(CreatePathPoints()); //create the points traveled by the platform
    }
    

    IEnumerator CreatePathPoints()
    {
        while (true)
        {
            if (transform.position.y<lastPosition.y || collided) // when there is a collision or the y axis of the parabola decreases then freeze the platform
            {
                
                newPlatform.constraints = RigidbodyConstraints2D.FreezeAll; // freeze all the varaibles of the platform
                newPlatform.transform.rotation= Quaternion.identity; // make rotation zero.
                newPlatform.GetComponent<Renderer>().enabled = false; // make old small platform disappear
                Instantiate(platformShape, transform.position, transform.rotation); //create the new big platform
                platformShape.constraints= RigidbodyConstraints2D.FreezeRotation;
                
                break;
            }
            PathPoints.instance.CreateCurrentPathPoint(transform.position);
            lastPosition = transform.position; //store the latest position of the platform for comparision in the above if.
            yield return new WaitForSeconds(PathPoints.instance.timeInterval);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collided = true;
    }
}
