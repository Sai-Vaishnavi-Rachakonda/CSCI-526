using UnityEngine;

public class PlatformDropping : MonoBehaviour
{
    // public GameObject cubePrefab; // assign the cube prefab in the inspector
    private float dropRate = 0.2f; // rate at which the cube drops (in meters per second)
    
    private float timeSinceLastDrop = 0.0f;

    void Update()
    {
        timeSinceLastDrop += Time.deltaTime;
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector3(0.0f, -dropRate, 0.0f);
       
    }
}