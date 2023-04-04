using UnityEngine;
using UnityEngine.UI;

public class ZoomOutController : MonoBehaviour
{
    public Text zoomText;
    private bool isPaused;
    private bool hasPressedZ;

    private void Start()
    {
        Time.timeScale = 1f;
        isPaused = true;
        hasPressedZ = false;
        zoomText.gameObject.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && !isPaused && hasPressedZ)
        {
            Time.timeScale = 0f;
            isPaused = true;
        }
        else if (Input.GetKeyDown(KeyCode.Z) && isPaused)
        {
            Time.timeScale = 1f;
            isPaused = false;
            zoomText.gameObject.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.Z) && !hasPressedZ)
        {
            hasPressedZ = true;
            isPaused = false;
            Time.timeScale = 1f;
            zoomText.gameObject.SetActive(false);
        }
    }
}
