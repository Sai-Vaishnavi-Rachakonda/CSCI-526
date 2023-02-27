using UnityEngine;

public class Deck : MonoBehaviour
{
    public int counter = 10;  // Initial value of counter
    private TextMesh textMesh;
    public Color highlightColor = Color.black;  // Color to use for highlight
    private Color originalColor;  // Original color of the game object
    private Renderer renderer;  // Renderer component of the game object
    public Slingshot script;
    public string platformType;


    void Start()
    {
        // Find the child TextMesh component of the game object
        textMesh = GetComponentInChildren<TextMesh>();
        if (textMesh == null)
        {
            Debug.LogError("Child TextMesh component not found!");
        }
        else
        {
            // Set the TextMesh text to the initial counter value
            textMesh.text = counter.ToString();
        }

        // Get the Renderer component of the game object
        renderer = GetComponent<Renderer>();
        // Save the original color of the game object
        originalColor = renderer.material.color;
    }

    void OnMouseDown()
    {
        if(counter > 0)
        {
            script.selectedPlatform = platformType;
            script.CreatePlatformFromIndex();
        }
    }

    public void DecreaseCount()
    {
        if (textMesh != null)
        {
            // Reduce the counter by 1 and update the TextMesh text
            if(counter > 0)
            {
                counter--;
                textMesh.text = counter.ToString();
            }
            if (counter == 0)
            {
                textMesh.text = "X";
                script.StopPlatform(platformType);
            }
        }
    }

    void OnMouseEnter()
    {
        // Change the color of the game object to the highlight color
        renderer.material.color = highlightColor;
    }

    void OnMouseExit()
    {
        // Restore the original color of the game object
        renderer.material.color = originalColor;
    }
}
