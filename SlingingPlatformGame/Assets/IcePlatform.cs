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
    }

    IEnumerator myWaitCoroutine()
    {
        yield return new WaitForSeconds(5f); // Wait for one second

        GetComponent<Rigidbody2D>().GetComponent<Renderer>().enabled = false; // make old small platform disappear
        gameObject.SetActive(false);
        // Destroy(gameObject,50f);
    }
}