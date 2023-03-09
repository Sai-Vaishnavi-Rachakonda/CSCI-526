using UnityEngine;

public class PlatformMelting : MonoBehaviour
{
    public float duration = 8f;  // the duration in seconds for the scaling effect
    private float timer = 0f;   // the timer to keep track of the elapsed time

    private void Update()
    {
        // Check if the timer has reached the duration
        if (timer <= duration)
        {
            // Calculate the new scale value based on the elapsed time
            float scale = Mathf.Lerp(0.5f, 0f, timer / duration);

            // Update the scale of the cube object
            transform.localScale = new Vector3(3f, scale, 1f);

            // Increase the timer by the delta time
            timer += Time.deltaTime;
        }
    }
}

