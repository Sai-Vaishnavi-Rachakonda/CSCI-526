using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcePlatform : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(myWaitCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        // gameObject.GetComponent<Renderer>().material.color = new Color(curColor.r, curColor.g, curColor.b, 1);

    }

    IEnumerator myWaitCoroutine()
    {
        yield return new WaitForSeconds(7f); // Wait for one second

        GetComponent<Rigidbody2D>().GetComponent<Renderer>().enabled = false; // make old small platform disappear
        gameObject.SetActive(false);
        // Destroy(gameObject,50f);
    }
}