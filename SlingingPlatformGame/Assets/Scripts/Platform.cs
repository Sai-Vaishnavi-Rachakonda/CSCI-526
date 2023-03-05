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

    
    // public class PositionCords
    // {
    //     public float x { get; set; }
    //     public float y { get; set; }
    //     public PositionCords(){}
    //     public PositionCords(float x, float y)
    //     {
    //         x = x;
    //         y = y;
    //     }
    // }


    private void Start()
    {
        newPlatform = GetComponent<Rigidbody2D>(); // assign the platform to the var
    }

    private void Update()
    {
    }

    public void Release(string selectedPlatform)
    {
        PathPoints.instance.Clear();
        StartCoroutine(CreatePathPoints(selectedPlatform)); //create the points traveled by the platform
    }
    
    
    IEnumerator CreatePathPoints(string selectedPlatform)
    {
        while (true)
        {
             if (timer >= 0.018f ) //for runtime in unity
            //  if (timer >= 0.15f ) // for webGl
            // if (timer >= 0.05f ) //for runtime in unity (Pratik's PC)
            {
                newPlatform.constraints = RigidbodyConstraints2D.FreezeAll; // freeze all the varaibles of the platform
                newPlatform.transform.rotation= Quaternion.identity; // make rotation zero.
                // Instantiate(platformShape, transform.position, transform.rotation); //create the new big platform
                newPlatform.GetComponent<Renderer>().enabled = false; // make old small platform disappear
                // var pos = new PositionCords();
                var pos = "";
                pos += "x:"+transform.position.x.ToString();
                pos += ",y:"+transform.position.y.ToString();
                Debug.Log(""+pos);
                Buttonscript.dbObj.setPlatformCords(pos);
                Buttonscript.dbObj.platformCount +=1;
                Buttonscript.dbObj.setPlatformsShoot(selectedPlatform);
                Destroy(newPlatform);
                gameObject.SetActive(false);
                Destroy(this.gameObject);
                Instantiate(platformShape, transform.position, transform.rotation); //create the new big platform
                platformShape.constraints= RigidbodyConstraints2D.FreezeRotation;
                break;
            }
            timer += 0.87f * Time.deltaTime;
            PathPoints.instance.CreateCurrentPathPoint(transform.position);
            yield return new WaitForSeconds(PathPoints.instance.timeInterval);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collided = true;
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Transform collidedObject = collision.gameObject.transform;
        Transform otherObject = transform;
        int otherObjectZIndex = otherObject.GetSiblingIndex();
        collidedObject.SetSiblingIndex(otherObjectZIndex + 5);
    }
}
