using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public bool collided;

    private Rigidbody2D newPlatform;
    private Vector3 lastPosition = Vector3.negativeInfinity;

    private void Start()
    {
        newPlatform = GetComponent<Rigidbody2D>();
    }

    public void Release()
    {
        PathPoints.instance.Clear();
        StartCoroutine(CreatePathPoints());
    }
    

    IEnumerator CreatePathPoints()
    {
        while (true)
        {
            if (transform.position.y<lastPosition.y || collided)
            {
                newPlatform.constraints = RigidbodyConstraints2D.FreezeAll;
                newPlatform.transform.rotation= Quaternion.identity;
                break;
            }
            PathPoints.instance.CreateCurrentPathPoint(transform.position);
            lastPosition = transform.position;
            yield return new WaitForSeconds(PathPoints.instance.timeInterval);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collided = true;
    }
}
