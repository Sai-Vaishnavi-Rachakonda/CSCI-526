using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public bool collided;

    // private Rigidbody2D newPlatform;
    private Rigidbody2D newPlatform; //create a new variable to access the new platform
    public Rigidbody2D platformShape;// get the variable to create the new platform.
    public float timer;
    GameObject Slingshot;



    private void Start()
    {
        newPlatform = GetComponent<Rigidbody2D>(); // assign the platform to the var
    }

    private void Update()
    {
    }

    public void Release()
    {
        // PathPoints.instance.Clear();
        StartCoroutine(CreatePathPoints()); //create the points traveled by the platform
    }
    
    
    IEnumerator CreatePathPoints()
    {
        while (true)
        {
            if (timer >= 0.012f ) //for runtime in unity
                // if (timer >= 0.10f ) // for webGl
            {
                newPlatform.constraints = RigidbodyConstraints2D.FreezeAll; // freeze all the varaibles of the platform
                newPlatform.transform.rotation= Quaternion.identity; // make rotation zero.
                // Instantiate(platformShape, transform.position, transform.rotation); //create the new big platform
                newPlatform.GetComponent<Renderer>().enabled = false; // make old small platform disappear
                Destroy(newPlatform);
                gameObject.SetActive(false);
                Destroy(this.gameObject);
                Instantiate(platformShape, transform.position, transform.rotation); //create the new big platform
                platformShape.constraints= RigidbodyConstraints2D.FreezeRotation;
                break;
            }
            timer += 0.90f * Time.deltaTime;
            PathPoints.instance.CreateCurrentPathPoint(transform.position);
            yield return new WaitForSeconds(PathPoints.instance.timeInterval);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collided = true;
    }
}
