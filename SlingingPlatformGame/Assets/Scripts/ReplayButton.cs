using UnityEngine;
using UnityEngine.SceneManagement;

public class ReplayButton : MonoBehaviour
{
    public void OnClick()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;

        // Compare the current scene name with a string
        if (currentSceneName == "Level 0")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        else
        {
            SceneManager.LoadScene("Level 1");
        }
        }
    }
